using AutoMapper;
using Beanz.Core.BeanzRoutes;
using Beanz.DTOs.BeanzRoutes;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
//using Beanz.Data.Services.HumanResourceManagementSystem.Dashboards.Payrolls;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Beanz.Data.Services.BeanzRoutes
{

	public class BeanzScriptRepository : IBeanzScriptRepository 
    {
        private readonly IConfiguration _configuration;
        public BeanzScriptRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<ScriptResponseDTO> ExecuteScriptAsync(ScriptParameterDTO dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.DataSource))
                    return new ScriptResponseDTO { Success = false, Message = "DataSource is required." };

                if (string.IsNullOrWhiteSpace(dto.InitialCatalog))
                    return new ScriptResponseDTO { Success = false, Message = "InitialCatalog is required." };

                if (string.IsNullOrWhiteSpace(dto.Script))
                    return new ScriptResponseDTO { Success = false, Message = "Script is required." };

                var builder = new SqlConnectionStringBuilder
                {
                    DataSource = dto.DataSource,
                    UserID = dto.UserId,
                    Password = dto.Password,
                    InitialCatalog = dto.InitialCatalog,
                    TrustServerCertificate = true,
                    Encrypt = false,
                    MultipleActiveResultSets = true
                };

                using var con = new SqlConnection(builder.ConnectionString);

                //var cs = _configuration.GetConnectionString("SqlConnectionString");
                //using var con = new SqlConnection(cs);

                await con.OpenAsync();

                var batches = Regex.Split(
                    dto.Script,
                    @"^\s*GO\s*$",
                    RegexOptions.Multiline | RegexOptions.IgnoreCase
                );

                using var tran = con.BeginTransaction();

                try
                {
                    foreach (var batch in batches)
                    {
                        if (string.IsNullOrWhiteSpace(batch))
                            continue;

                        using var cmd = new SqlCommand(batch, con, tran);
                        cmd.CommandTimeout = 300;

                        await cmd.ExecuteNonQueryAsync();
                    }

                    tran.Commit();

                    return new ScriptResponseDTO
                    {
                        Success = true,
                        Message = "Script executed successfully."
                    };
                }
                catch (Exception ex)
                {
                    tran.Rollback();

                    return new ScriptResponseDTO
                    {
                        Success = false,
                        Message = "Script execution failed.",
                        Error = ex.Message
                    };
                }
            }
            catch (Exception ex)
            {
                return new ScriptResponseDTO
                {
                    Success = false,
                    Message = "Connection failed.",
                    Error = ex.Message
                };
            }
        }

        public async Task<ScriptDefinitionResponseDTO> ExecuteDefinitionScriptAsync(ScriptDefinitionParameterDTO dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.DataSource))
                    return new ScriptDefinitionResponseDTO { Success = false, Message = "DataSource is required." };
                if (string.IsNullOrWhiteSpace(dto.InitialCatalog))
                    return new ScriptDefinitionResponseDTO { Success = false, Message = "InitialCatalog is required." };
                if (string.IsNullOrWhiteSpace(dto.Script))
                    return new ScriptDefinitionResponseDTO { Success = false, Message = "Script is required." };

                var builder = new SqlConnectionStringBuilder
                {
                    DataSource = dto.DataSource,
                    UserID = dto.UserId,
                    Password = dto.Password,
                    InitialCatalog = dto.InitialCatalog,
                    TrustServerCertificate = true,
                    Encrypt = false,
                    MultipleActiveResultSets = true
                };

                using var con = new SqlConnection(builder.ConnectionString);
                //var cs = _configuration.GetConnectionString("SqlConnectionString");
                //using var con = new SqlConnection(cs);

                await con.OpenAsync();

                var batches = Regex.Split(dto.Script, @"^\s*GO\s*$",
                    RegexOptions.Multiline | RegexOptions.IgnoreCase);

                using var tran = con.BeginTransaction();
                var allTables = new List<List<Dictionary<string, object>>>();
                int totalRowsAffected = 0;

                try
                {
                    foreach (var batch in batches)
                    {
                        if (string.IsNullOrWhiteSpace(batch)) continue;

                        using var cmd = new SqlCommand(batch, con, tran) { CommandTimeout = 300 };
                        using var reader = await cmd.ExecuteReaderAsync();

                        do
                        {
                            if (reader.FieldCount == 0)
                            {
                                if (reader.RecordsAffected > 0) totalRowsAffected += reader.RecordsAffected;
                                continue;
                            }
                            var table = new List<Dictionary<string, object>>();
                            while (await reader.ReadAsync())
                            {
                                var row = new Dictionary<string, object>(reader.FieldCount);
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    var val = reader.GetValue(i);
                                    row[reader.GetName(i)] = val is DBNull ? null : val;
                                }
                                table.Add(row);
                            }
                            allTables.Add(table);
                        } while (await reader.NextResultAsync());
                    }

                    tran.Commit();

                    return new ScriptDefinitionResponseDTO
                    {
                        Success = true,
                        Message = "Script executed successfully.",
                        RowsAffected = totalRowsAffected,
                        Tables = allTables,            // List<List<Dictionary<string,object>>>
                        Data = allTables.FirstOrDefault() ?? new List<Dictionary<string, object>>()
                    };
                }
                catch (Exception ex)
                {
                    try { tran.Rollback(); } catch { }
                    return new ScriptDefinitionResponseDTO { Success = false, Message = "Script execution failed.", Error = ex.Message };
                }
            }
            catch (Exception ex)
            {
                return new ScriptDefinitionResponseDTO { Success = false, Message = "Connection failed.", Error = ex.Message };
            }
        }

        public async Task<dynamic> GetDatabaseObjectsAsync(ScriptParameterDTO dto)
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = dto.DataSource,
                UserID = dto.UserId,
                Password = dto.Password,
                InitialCatalog = dto.InitialCatalog,
                TrustServerCertificate = true,
                Encrypt = false
            };

            using var con = new SqlConnection(builder.ConnectionString);
            //var cs = _configuration.GetConnectionString("SqlConnectionString");
            //using var con = new SqlConnection(cs);

            await con.OpenAsync();

            string sql = @"

                        -- Tables
                        SELECT 
                            'Table' AS ObjectType,
                            s.name AS SchemaName,
                            t.name AS ObjectName
                        FROM sys.tables t
                        INNER JOIN sys.schemas s 
                            ON t.schema_id = s.schema_id

                        UNION ALL

                        -- Procedures
                        SELECT 
                            'Procedure' AS ObjectType,
                            s.name AS SchemaName,
                            p.name AS ObjectName
                        FROM sys.procedures p
                        INNER JOIN sys.schemas s 
                            ON p.schema_id = s.schema_id

                        UNION ALL

                        -- Functions
                        SELECT 
                            'Function' AS ObjectType,
                            s.name AS SchemaName,
                            o.name AS ObjectName
                        FROM sys.objects o
                        INNER JOIN sys.schemas s 
                            ON o.schema_id = s.schema_id
                        WHERE o.type IN ('FN', 'IF', 'TF')

                        ORDER BY ObjectType, SchemaName, ObjectName
                        ";

                                var data = await con.QueryAsync<dynamic>(sql);

                                return data.ToList();
                            }

        public async Task<dynamic> GetDatabaseTableDetailsAsync(ScriptParameterDTO dto)
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = dto.DataSource,
                UserID = dto.UserId,
                Password = dto.Password,
                InitialCatalog = dto.InitialCatalog,
                TrustServerCertificate = true,
                Encrypt = false
            };
            using var con = new SqlConnection(builder.ConnectionString);

            //var cs = _configuration.GetConnectionString("SqlConnectionString");

            //using var con = new SqlConnection(cs);

            await con.OpenAsync();

            string sql = @"
    SELECT
        s.name AS SchemaName,
        t.name AS TableName,
        c.column_id AS ColumnOrder,
        c.name AS ColumnName,
        ty.name AS DataType,
        c.max_length AS MaxLength,
        c.precision AS PrecisionValue,
        c.scale AS ScaleValue,
        c.is_nullable AS IsNullable,
        c.is_identity AS IsIdentity,
        CASE WHEN pk.column_id IS NOT NULL THEN 1 ELSE 0 END AS IsPrimaryKey,
        fk.name AS ForeignKeyName,
        OBJECT_SCHEMA_NAME(fkc.referenced_object_id) AS ReferencedSchema,
        OBJECT_NAME(fkc.referenced_object_id) AS ReferencedTable,
        COL_NAME(fkc.referenced_object_id, fkc.referenced_column_id) AS ReferencedColumn
    FROM sys.tables t
    INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
    INNER JOIN sys.columns c ON t.object_id = c.object_id
    INNER JOIN sys.types ty ON c.user_type_id = ty.user_type_id
    LEFT JOIN
    (
        SELECT ic.object_id, ic.column_id
        FROM sys.indexes i
        INNER JOIN sys.index_columns ic
            ON i.object_id = ic.object_id
            AND i.index_id = ic.index_id
        WHERE i.is_primary_key = 1
    ) pk
        ON c.object_id = pk.object_id
        AND c.column_id = pk.column_id
    LEFT JOIN sys.foreign_key_columns fkc
        ON c.object_id = fkc.parent_object_id
        AND c.column_id = fkc.parent_column_id
    LEFT JOIN sys.foreign_keys fk
        ON fkc.constraint_object_id = fk.object_id
    WHERE
        s.name = @SchemaName
        AND t.name = @TableName
    ORDER BY c.column_id;
    ";

            var data = await con.QueryAsync<dynamic>(
                sql,
                new
                {
                    dto.SchemaName,
                    dto.TableName
                }
            );

            return data.ToList();
        }

        public async Task<ScriptResult> ExecuteSPAsync(ScriptParameterDTO script)
        {

            var result = new ScriptResult();
            //var cs = new SqlConnectionStringBuilder
            //{
            //    DataSource = script.DataSource,
            //    UserID = script.UserId,
            //    Password = script.Password,
            //    InitialCatalog = script.InitialCatalog,
            //    TrustServerCertificate = true,
            //    Encrypt = false
            //}.ConnectionString;

            var cs = _configuration.GetConnectionString("SqlConnectionString");


            try
            {
                await using var conn = new SqlConnection(cs);
                await conn.OpenAsync();

                await using var cmd = new SqlCommand(script.Script, conn)
                {
                    CommandType = CommandType.Text,
                    CommandTimeout = 120
                };

                var allResultSets = new List<List<Dictionary<string, object>>>();

                await using (var reader = await cmd.ExecuteReaderAsync())
                {
                    do
                    {
                        var set = new List<Dictionary<string, object>>();
                        while (await reader.ReadAsync())
                        {
                            var row = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                var name = reader.GetName(i);
                                if (string.IsNullOrWhiteSpace(name)) name = $"Column{i}";
                                row[name] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                            }
                            set.Add(row);
                        }
                        allResultSets.Add(set);
                        result.RowsAffected += reader.RecordsAffected > 0 ? reader.RecordsAffected : 0;
                    }
                    while (await reader.NextResultAsync());
                }

                //// Flatten everything into Rows (back-compat)
                //foreach (var s in allResultSets) result.Rows.AddRange(s);

                // The last result set is the SELECT @ResponseID, ... — map it
                var last = allResultSets.LastOrDefault()?.FirstOrDefault();
                if (last != null)
                {
                    result.Response = new SpResponse
                    {
                        ResponseID = TryGetInt(last, "ResponseID", 0),
                        ResponseCode = TryGetString(last, "ResponseCode", 1),
                        ResponseMessage = TryGetString(last, "ResponseMessage", 2),
                        ErrorCode = TryGetString(last, "ErrorCode", 3),
                        ErrorMessage = TryGetString(last, "ErrorMessage", 4),
                    };
                }

                // Treat ErrorCode/ErrorMessage as failure
                if (!string.IsNullOrWhiteSpace(result.Response?.ErrorCode) ||
                    !string.IsNullOrWhiteSpace(result.Response?.ErrorMessage))
                {
                    result.Success = false;
                    result.Message = result.Response?.ErrorMessage ?? "Stored procedure returned an error.";
                }
                else
                {
                    result.Success = true;
                    result.Message = result.Response?.ResponseMessage ?? "Executed successfully.";
                }

                return result;
            }
            catch (SqlException ex)
            {
                return new ScriptResult { Success = false, Message = $"SQL Error {ex.Number}: {ex.Message}" };
            }
            catch (Exception ex)
            {
                return new ScriptResult { Success = false, Message = ex.Message };
            }
        }

        // Helpers — read by alias name if present, else by positional fallback
        private static string TryGetString(Dictionary<string, object> row, string name, int index)
        {
            if (row.TryGetValue(name, out var v) && v != null) return v.ToString();
            var key = row.Keys.ElementAtOrDefault(index);
            return key != null && row[key] != null ? row[key].ToString() : null;
        }

        private static int? TryGetInt(Dictionary<string, object> row, string name, int index)
        {
            object v = null;
            if (!row.TryGetValue(name, out v))
            {
                var key = row.Keys.ElementAtOrDefault(index);
                if (key != null) v = row[key];
            }
            if (v == null) return null;
            return int.TryParse(v.ToString(), out var n) ? n : (int?)null;
        }

        //public async Task<ScriptResult> ExecuteSPAsync(ScriptParameterDTO script)
        //{
        //    var result = new ScriptResult();

        //    var cs = new SqlConnectionStringBuilder
        //    {
        //        DataSource = script.DataSource,
        //        UserID = script.UserId,
        //        Password = script.Password,
        //        InitialCatalog = script.InitialCatalog,
        //        TrustServerCertificate = true,
        //        Encrypt = false
        //    }.ConnectionString;

        //    try
        //    {
        //        await using var conn = new SqlConnection(cs);
        //        await conn.OpenAsync();

        //        await using var cmd = new SqlCommand(script.Script, conn)
        //        {
        //            CommandType = CommandType.Text,
        //            CommandTimeout = 120
        //        };

        //        var allResultSets = new List<List<Dictionary<string, object>>>();

        //        await using (var reader = await cmd.ExecuteReaderAsync())
        //        {
        //            do
        //            {
        //                var set = new List<Dictionary<string, object>>();
        //                while (await reader.ReadAsync())
        //                {
        //                    var row = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        //                    for (int i = 0; i < reader.FieldCount; i++)
        //                    {
        //                        var name = reader.GetName(i);
        //                        if (string.IsNullOrWhiteSpace(name)) name = $"Column{i}";
        //                        row[name] = reader.IsDBNull(i) ? null : reader.GetValue(i);
        //                    }
        //                    set.Add(row);
        //                }
        //                allResultSets.Add(set);
        //                if (reader.RecordsAffected > 0) result.RowsAffected += reader.RecordsAffected;
        //            }
        //            while (await reader.NextResultAsync());
        //        }

        //        // Flatten all rows (back-compat)
        //        foreach (var s in allResultSets) result.Rows.AddRange(s);

        //        // Last result set's first row = the SP response (dynamic)
        //        result.Response = allResultSets.LastOrDefault()?.FirstOrDefault();

        //        // Decide success based on ErrorCode / ErrorMessage if present
        //        var errCode = GetValue(result.Response, "ErrorCode");
        //        var errMsg = GetValue(result.Response, "ErrorMessage");

        //        if (!string.IsNullOrWhiteSpace(errCode?.ToString()) ||
        //            !string.IsNullOrWhiteSpace(errMsg?.ToString()))
        //        {
        //            result.Success = false;
        //            result.Message = errMsg?.ToString() ?? "Stored procedure returned an error.";
        //        }
        //        else
        //        {
        //            result.Success = true;
        //            result.Message = GetValue(result.Response, "ResponseMessage")?.ToString()
        //                             ?? "Executed successfully.";
        //        }

        //        return result;
        //    }
        //    catch (SqlException ex)
        //    {
        //        return new ScriptResult { Success = false, Message = $"SQL Error {ex.Number}: {ex.Message}" };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ScriptResult { Success = false, Message = ex.Message };
        //    }
        //}

        //private static object GetValue(Dictionary<string, object> row, string key)
        //{
        //    if (row == null) return null;
        //    return row.TryGetValue(key, out var v) ? v : null;
        //}



        //public async Task<ScriptResult> ExecuteSPAsync(ScriptParameterDTO dto)
        //{
        //    var result = new ScriptResult();
        //    var connStr = new SqlConnectionStringBuilder
        //    {
        //        DataSource = dto.DataSource,
        //        UserID = dto.UserId,
        //        Password = dto.Password,
        //        InitialCatalog = dto.InitialCatalog,
        //        TrustServerCertificate = true,
        //        Encrypt = false,
        //    }.ConnectionString;

        //    try
        //    {
        //        using var conn = new SqlConnection(connStr);
        //        await conn.OpenAsync();

        //        using var cmd = new SqlCommand(dto.Script, conn)
        //        {
        //            CommandType = CommandType.Text,   // script contains DECLARE + EXEC ... OUTPUT + SELECT
        //            CommandTimeout = 120,
        //        };

        //        using var reader = await cmd.ExecuteReaderAsync();
        //        do
        //        {
        //            while (await reader.ReadAsync())
        //            {
        //                var row = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        //                for (int i = 0; i < reader.FieldCount; i++)
        //                    row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
        //                result.Rows.Add(row);
        //            }
        //        } while (await reader.NextResultAsync());

        //        result.RowsAffected = result.Rows.Count;
        //        result.Success = true;
        //        result.Message = "OK";
        //    }
        //    catch (SqlException ex)
        //    {
        //        result.Success = false;
        //        result.Message = ex.Message;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Success = false;
        //        result.Message = ex.Message;
        //    }

        //    return result;
        //}

    }
}
