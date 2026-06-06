using AutoMapper;
using Beanz.Core.BeanzRoutes;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common; 

//using Beanz.Models.BeanzModel;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Beanz.Data.Services.BeanzRoutes
{

	public class BeanzRepository : IBeanzRepository
    {

		private readonly IMapper _mapper;
        
        public BeanzRepository(IMapper mapper)
		{
			_mapper = mapper;
		}

        public async Task<List<dynamic>> GetAsync(BeanzRoutesRequestDTO dto)
        {
           
            string sp = GetProcedure(dto.system, dto.area, dto.module, "Get");
            var parameters = GetCommonParameters(dto);

            using var con = new SqlConnection(Utilities.Configuration.ConnectionString);
            var data = await con.QueryAsync<dynamic>(
                sp,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return data.ToList();
        }

        public async Task<BeanzRoutesResponseDTO> SetAsync(BeanzRoutesRequestDTO dto)
        {
     
            string sp = GetProcedure(dto.system, dto.area, dto.module, "Set");
            var parameters = GetCommonParameters(dto);
            //var parameters = new DynamicParameters();
            //parameters.Add("@CompanyID", dto.CompanyID);
            //parameters.Add("@UserID", dto.UserID);
            //parameters.Add("@Type", dto.Type);
            //parameters.Add("@PrimaryKeyID", dto.PrimaryKeyID);
            //parameters.Add("@Json", dto.Json);

            parameters.Add("@ResponseID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@ResponseCode", dbType: DbType.String, direction: ParameterDirection.Output);
            parameters.Add("@ResponseMessage", dbType: DbType.String,  direction: ParameterDirection.Output);
            parameters.Add("@ErrorCode", dbType: DbType.String,  direction: ParameterDirection.Output);
            parameters.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output);

            using var con = new SqlConnection(Utilities.Configuration.ConnectionString);

            await con.ExecuteAsync(
                sp,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return new BeanzRoutesResponseDTO
            {
                ResponseID = parameters.Get<int?>("@ResponseID"),
                ResponseCode = parameters.Get<string>("@ResponseCode"),
                ResponseMessage = parameters.Get<string>("@ResponseMessage") ?? "",
                ErrorCode = parameters.Get<string>("@ErrorCode") ?? "",
                ErrorMessage = parameters.Get<string>("@ErrorMessage") ?? ""
            };
            //return parameters.Get<string>("@ReturnValue") ?? "";
        }

        public async Task<BeanzRoutesResponseDTO> PostAsync(BeanzRoutesRequestDTO dto)
        {
 
            string sp = GetProcedure(dto.system, dto.area, dto.module, "Post");
            //var parameters = new DynamicParameters();
            var parameters = GetCommonParameters(dto);
            //parameters.Add("@CompanyID", dto.CompanyID);
            //parameters.Add("@UserID", dto.UserID);
            //parameters.Add("@Type", dto.Type);
            //parameters.Add("@PrimaryKeyID", dto.PrimaryKeyID);
            //parameters.Add("@Json", dto.Json);
            //parameters.Add("@ReturnValue", dbType: DbType.String, size: 500, direction: ParameterDirection.Output);

            parameters.Add("@ResponseID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@ResponseCode", dbType: DbType.String, direction: ParameterDirection.Output);
            parameters.Add("@ResponseMessage", dbType: DbType.String, direction: ParameterDirection.Output);
            parameters.Add("@ErrorCode", dbType: DbType.String, direction: ParameterDirection.Output);
            parameters.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output);


            using var con = new SqlConnection(Utilities.Configuration.ConnectionString);

            await con.ExecuteAsync(
                sp,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return new BeanzRoutesResponseDTO
            {
                ResponseID = parameters.Get<int?>("@ResponseID"),
                ResponseCode = parameters.Get<string>("@ResponseCode"),
                ResponseMessage = parameters.Get<string>("@ResponseMessage") ?? "",
                ErrorCode = parameters.Get<string>("@ErrorCode") ?? "",
                ErrorMessage = parameters.Get<string>("@ErrorMessage") ?? ""
            };

            //return parameters.Get<string>("@ReturnValue") ?? "";
        }

        public async Task<BeanzRoutesResponseDTO> DelAsync(BeanzRoutesRequestDTO dto)
        {
            

            string sp = GetProcedure(dto.system, dto.area, dto.module, "Del");
            //var parameters = new DynamicParameters();
            var parameters = GetCommonParameters(dto);
            //parameters.Add("@CompanyID", dto.CompanyID);
            //parameters.Add("@UserID", dto.UserID);
            //parameters.Add("@Type", dto.Type);
            //parameters.Add("@PrimaryKeyID", dto.PrimaryKeyID);
            //parameters.Add("@ReturnValue", dbType: DbType.String, size: 500, direction: ParameterDirection.Output);

            parameters.Add("@ResponseID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@ResponseCode", dbType: DbType.String, direction: ParameterDirection.Output);
            parameters.Add("@ResponseMessage", dbType: DbType.String, direction: ParameterDirection.Output);
            parameters.Add("@ErrorCode", dbType: DbType.String, direction: ParameterDirection.Output);
            parameters.Add("@ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output);


            using var con = new SqlConnection(Utilities.Configuration.ConnectionString);

            await con.ExecuteAsync(
                sp,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return new BeanzRoutesResponseDTO
            {
                ResponseID = parameters.Get<int?>("@ResponseID"),
                ResponseCode = parameters.Get<string>("@ResponseCode"),
                ResponseMessage = parameters.Get<string>("@ResponseMessage") ?? "",
                ErrorCode = parameters.Get<string>("@ErrorCode") ?? "",
                ErrorMessage = parameters.Get<string>("@ErrorMessage") ?? ""
            };
        }

        public async Task<List<BeanzlookupDTO>> LookupAsync(BeanzRoutesRequestDTO dto)
        {
            
            string sp = GetProcedure(dto.system, dto.area, dto.module, "Lookup");
            var parameters = GetCommonParameters(dto);

            using var con = new SqlConnection(Utilities.Configuration.ConnectionString);

            var data = await con.QueryAsync<BeanzlookupDTO>(
                sp,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return data.ToList();
        }
        
        public async Task<dynamic> GetInfoAsync(BeanzRoutesRequestDTO dto)
        {
            string sp = GetProcedure(dto.system, dto.area, dto.module, "GetInfo");
            var parameters = GetCommonParameters(dto);

            using var con = new SqlConnection(Utilities.Configuration.ConnectionString);

            using var multi = await con.QueryMultipleAsync(
                sp,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            var result = new Dictionary<string, object>();

            while (!multi.IsConsumed)
            {
                var rows = (await multi.ReadAsync<dynamic>()).ToList();

                if (rows.Count == 0)
                    continue;

                var firstRow = (IDictionary<string, object>)rows.First();

                string tableName = firstRow.ContainsKey("TableName")
                    ? firstRow["TableName"]?.ToString() ?? "Table"
                    : "Table";

                result[tableName] = rows;
            }

            return result;
        }

        public async Task<dynamic> PrintAsync(BeanzRoutesRequestDTO dto)
        {
            string sp = GetProcedure(dto.system, dto.area, dto.module, "Print");
            var parameters = GetCommonParameters(dto);

            using var con = new SqlConnection(Utilities.Configuration.ConnectionString);

            using var multi = await con.QueryMultipleAsync(
                sp,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            var result = new Dictionary<string, object>();

            while (!multi.IsConsumed)
            {
                var rows = (await multi.ReadAsync<dynamic>()).ToList();

                if (rows.Count == 0)
                    continue;

                var firstRow = (IDictionary<string, object>)rows.First();

                string tableName = firstRow.ContainsKey("TableName")
                    ? firstRow["TableName"]?.ToString() ?? "Table"
                    : "Table";

                result[tableName] = rows;
            }

            return result;
        }

         
        private DynamicParameters GetCommonParameters(BeanzRoutesRequestDTO dto)
        {
            var parameters = new DynamicParameters();
            
            parameters.Add("@CompanyID", dto.CompanyID);
            parameters.Add("@UserID", dto.UserID);
            parameters.Add("@Type", dto.Type);
            parameters.Add("@LanguageID", dto.LanguageID);
            parameters.Add("@PrimaryKeyID", dto.PrimaryKeyID);
            parameters.Add("@Json", dto.Json);

            return parameters;
        }
        public class ModuleConfigDTO
        {
            public string system { get; set; } = "";
            public string? area { get; set; }
            public string module { get; set; } = "";
            public string tableName { get; set; } = "";
            public string schema { get; set; } = "dbo";
        }
        private string GetProcedure(string system, string? area, string module, string action)
        {

            string path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "Config",
                           "beanz-modules.json"
                       );
            string json = File.ReadAllText(path);
            //if (!_allowedModules.ContainsKey(module))
            //    throw new Exception($"Invalid module: {module}");

            var modules = JsonSerializer.Deserialize<List<ModuleConfigDTO>>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );

                    var config = modules?.FirstOrDefault(x =>
                        x.system.Equals(system, StringComparison.OrdinalIgnoreCase) &&
                        x.module.Equals(module, StringComparison.OrdinalIgnoreCase) &&
                        (
                            string.IsNullOrEmpty(area) ||
                            string.IsNullOrEmpty(x.area) ||
                            x.area.Equals(area, StringComparison.OrdinalIgnoreCase)
                        )
                    );

            if (config == null)
                throw new Exception($"Invalid module: {system}/{area}/{module}");

            return action switch
            {
                "Get" => $"{config.schema}.Get{config.tableName}",
                "Set" => $"{config.schema}.Set{config.tableName}",
                "Del" => $"{config.schema}.Del{config.tableName}",
                "Lookup" => $"{config.schema}.Lookup{config.tableName}",
                "GetInfo" => $"{config.schema}.GetInfo{config.tableName}",
                "Print" => $"{config.schema}.Print{config.tableName}",
                "Post" => $"{config.schema}.Post{config.tableName}",
                _ => throw new Exception($"Invalid action: {action}")
            };
            
        }
        
    }
}
