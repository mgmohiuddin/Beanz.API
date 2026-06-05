using Beanz.DTOs.Common;
using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Beanz.Data.Services.DataAccessLayer.DAL
{
    public static class DAL
    {

        #region ExecuteSetWithTwoOutputParmaters

        public static SetResultDTO ExecuteSetWithTwoOutputParmaters(string procedureName, string[] outputParameters, IDataParameter[] parameters)
        {
            // To ensure that connections are always closed, open the connection inside of a using block
            // Using block ensures that the connection is automatically closed when the code exits the block.
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                DynamicParameters p = new DynamicParameters();
                foreach (var param in parameters)
                {
                    p.Add(param.ParameterName, param.Value, param.DbType);

                }
                foreach (string parameter in outputParameters)
                {
                    p.Add(parameter, dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                }
                _sqlConnection.Execute(procedureName, p, commandType: CommandType.StoredProcedure);
                string value = p.Get<string>("@ReturnValue");
                string uniqueID = p.Get<string>("@UniqueID");
                SetResultDTO setresult = new SetResultDTO
                {
                    UniqueID= Convert.ToInt64(uniqueID),
                    ReturnValue= value

                };
                return setresult;
            }
        }

        //Async
        public static async Task<SetResultDTO> ExecuteSetWithTwoOutputParmatersAsync(string procedureName, string[] outputParameters, IDataParameter[] parameters)
        {
            // To ensure that connections are always closed, open the connection inside of a using block
            // Using block ensures that the connection is automatically closed when the code exits the block.
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                DynamicParameters p = new DynamicParameters();
                foreach (var param in parameters)
                {
                    p.Add(param.ParameterName, param.Value, param.DbType);

                }
                foreach (string parameter in outputParameters)
                {
                    p.Add(parameter, dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                }
                var result = await _sqlConnection.ExecuteAsync(procedureName, p, commandType: CommandType.StoredProcedure);
                Console.WriteLine("result =" + result.ToString());
                string value = p.Get<string>("@ReturnValue");
                string uniqueID = p.Get<string>("@UniqueID");

                SetResultDTO setresult = new SetResultDTO
                {
                    UniqueID = Convert.ToInt64(uniqueID),
                    ReturnValue = value

                };
                return setresult;
            }
        }

        #endregion

        #region ExecuteSetWithSingleOutputParameters

        public static string ExecuteSetWithSingleOutputParameters(string procedureName, string outputParameter, IDataParameter[] parameters)
        {
            // To ensure that connections are always closed, open the connection inside of a using block
            // Using block ensures that the connection is automatically closed when the code exits the block.
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                DynamicParameters p = new DynamicParameters();
                foreach (var param in parameters)
                {
                    p.Add(param.ParameterName, param.Value, param.DbType);

                }
                p.Add(outputParameter, dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);

                _sqlConnection.Execute(procedureName, p, commandType: CommandType.StoredProcedure);

                var value = p.Get<string>("@ReturnValue");
                return value.ToString();
            }
        }

        //Async
        public static async Task<string> ExecuteSetWithSingleOutputParametersAsync(string procedureName, string outputParameter, IDataParameter[] parameters)
        {
            try
            {
                using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
                {
                    DynamicParameters p = new DynamicParameters();
                    foreach (var param in parameters)
                    {
                        p.Add(param.ParameterName, param.Value, param.DbType);

                    }
                    p.Add(outputParameter, dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);

                    var result = await _sqlConnection.ExecuteAsync(procedureName, p, commandType: CommandType.StoredProcedure);

                    var value = p.Get<string>("@ReturnValue");
                    return value.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
            // To ensure that connections are always closed, open the connection inside of a using block
            // Using block ensures that the connection is automatically closed when the code exits the block.
            
        }

        #endregion

        #region GetSingleObjectWithParameters

        public static T GetSingleObjectWithParameters<T>(string spName, IDataParameter[] parameters)
        {
            // To ensure that connections are always closed, open the connection inside of a using block
            // Using block ensures that the connection is automatically closed when the code exits the block.
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                DynamicParameters p = new DynamicParameters();
                foreach (var param in parameters)
                {
                    p.Add(param.ParameterName, param.Value, param.DbType);
                }

                var objRecord = _sqlConnection.Query<T>(spName, p, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return objRecord;
            }
        }

        //Async
        public static async Task<T> GetSingleObjectWithParametersAsync<T>(string spName, IDataParameter[] parameters)
        {
            // To ensure that connections are always closed, open the connection inside of a using block
            // Using block ensures that the connection is automatically closed when the code exits the block.
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                DynamicParameters p = new DynamicParameters();
                foreach (var param in parameters)
                {
                    p.Add(param.ParameterName, param.Value, param.DbType);
                }

                var objRecord = (await _sqlConnection.QueryAsync<T>(spName, p, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                return objRecord;
            }
        }

        #endregion

        #region GetSingleObject 

        public static T GetSingleObject<T>(string spName)
        {
            // To ensure that connections are always closed, open the connection inside of a using block
            // Using block ensures that the connection is automatically closed when the code exits the block.
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                var objRecord = _sqlConnection.Query<T>(spName, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return objRecord;
            }
        }

        //Async
        public static async Task<T> GetSingleObjectAsync<T>(string spName, IDataParameter[] parameters)
        {
            // To ensure that connections are always closed, open the connection inside of a using block
            // Using block ensures that the connection is automatically closed when the code exits the block.
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                DynamicParameters p = new DynamicParameters();
                foreach (var param in parameters)
                {
                    p.Add(param.ParameterName, param.Value, param.DbType);
                }

                var objRecord = (await _sqlConnection.QueryAsync<T>(spName, p, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                return objRecord;
            }
        }
        #endregion

        #region GetObjectListWithParameters

        public static List<T> GetObjectListWithParameters<T>(string spName, IDataParameter[] parameters)
        {
            // To ensure that connections are always closed, open the connection inside of a using block
            // Using block ensures that the connection is automatically closed when the code exits the block.
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                DynamicParameters p = new DynamicParameters();
                foreach (var param in parameters)
                {
                    p.Add(param.ParameterName, param.Value, param.DbType);
                }

                var recordList = _sqlConnection.Query<T>(spName, p, commandType: CommandType.StoredProcedure).ToList();

                return recordList;
            }
        }

        //Async
        public static async Task<List<T>> GetObjectListWithParametersAsync<T>(string spName, IDataParameter[] parameters)
        {
            // To ensure that connections are always closed, open the connection inside of a using block
            // Using block ensures that the connection is automatically closed when the code exits the block.
            try
            {
                using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
                {
                    DynamicParameters p = new DynamicParameters();
                    foreach (var param in parameters)
                    {
                        p.Add(param.ParameterName, param.Value, param.DbType);
                    }

                   

                    var recordList = (await _sqlConnection.QueryAsync<T>(spName, p, commandType: CommandType.StoredProcedure)).ToList();

                    //SqlConnection connection = new SqlConnection(Utilities.Configuration.ConnectionString);
                    //connection.Open();
                    //SqlCommand command = new SqlCommand("scm.GetMS_Items", connection);
                    //command.CommandType = CommandType.StoredProcedure;
                    //foreach (SqlParameter parameter in parameters)
                    //{
                    //    command.Parameters.Add(parameter);
                    //}
                    //SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    //DataSet dataSet = new DataSet();
                    //dataAdapter.Fill(dataSet);
                    //connection.Close();

                    return recordList;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        #endregion

        #region GetObjectList

        public static List<T> GetObjectList<T>(string spName)
        {
            // To ensure that connections are always closed, open the connection inside of a using block
            // Using block ensures that the connection is automatically closed when the code exits the block.
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                var recordList = _sqlConnection.Query<T>(spName, commandType: CommandType.StoredProcedure).ToList();

                return recordList;
            }
        }

        //Async
        public static async Task<List<T>> GetObjectListAsync<T>(string spName)
        {
            // To ensure that connections are always closed, open the connection inside of a using block
            // Using block ensures that the connection is automatically closed when the code exits the block.
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                var recordList = (await _sqlConnection.QueryAsync<T>(spName, commandType: CommandType.StoredProcedure)).ToList();

                return recordList;
            }
        }

        #endregion

        #region GetQueryMultiple

        public static GridReader GetQueryMultiple(string spName, DynamicParameters p)
        {
            // To ensure that connections are always closed, open the connection inside of a using block
            // Using block ensures that the connection is automatically closed when the code exits the block.
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                var objRecord = _sqlConnection.QueryMultiple(spName, p, commandType: CommandType.StoredProcedure);

                return objRecord;
            }
        }

        //Async
        public static async Task<GridReader> GetQueryMultipleAsync(string spName, DynamicParameters p)
        {
            // To ensure that connections are always closed, open the connection inside of a using block
            // Using block ensures that the connection is automatically closed when the code exits the block.
            using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
            {
                var objRecord = await _sqlConnection.QueryMultipleAsync(spName, p, commandType: CommandType.StoredProcedure);

                return objRecord;
            }
        }

        #endregion

        #region Function

        public async static Task<dynamic> GetFunction(string spName, IDataParameter[] parameters)
        {
            try
            {
                using (SqlConnection _sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString))
                {
                    DynamicParameters p = new DynamicParameters();
                    foreach (var param in parameters)
                    {
                        p.Add(param.ParameterName, param.Value);
                    }

                    var recordList = await _sqlConnection.QueryAsync<dynamic>("SELECT * FROM dbo.Function(@Parameter)", p, commandType: CommandType.StoredProcedure);
                    return "";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        #endregion
    }
}
