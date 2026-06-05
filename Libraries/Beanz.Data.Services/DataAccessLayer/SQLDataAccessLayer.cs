using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
 

namespace Beanz.Data.Services.DataAccessLayer
{

    public static class SQLDataAccessLayer
    {


        private static string ConnectionString => Utilities.Configuration.ConnectionString;

        // 1. List of Records using SP
        public static async Task<IEnumerable<T>> ListBySpAsync<T>(
            string procedureName,
            object? parameters = null)
        {
            using var connection = new SqlConnection(ConnectionString);

            return await connection.QueryAsync<T>(
                procedureName,
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        // 2. List of Records using SQL Statement
        public static async Task<IEnumerable<T>> ListBySqlAsync<T>(
            string sqlText,
            object? parameters = null)
        {
            using var connection = new SqlConnection(ConnectionString);

            return await connection.QueryAsync<T>(
                sqlText,
                parameters,
                commandType: CommandType.Text);
        }

        // 3. Single Record using SP
        public static async Task<T?> SingleBySpAsync<T>(
            string procedureName,
            object? parameters = null)
        {
            using var connection = new SqlConnection(ConnectionString);

            return await connection.QueryFirstOrDefaultAsync<T>(
                procedureName,
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        // 4. Single Record using SQL Statement
        public static async Task<T?> SingleBySqlAsync<T>(
            string sqlText,
            object? parameters = null)
        {
            using var connection = new SqlConnection(ConnectionString);

            return await connection.QueryFirstOrDefaultAsync<T>(
                sqlText,
                parameters,
                commandType: CommandType.Text);
        }

        // 5. Multiple Output using SP - strongly typed DTO
        public static async Task<T> MultipleOutputBySpAsync<T>(
            string procedureName,
            IDataParameter[] parameters)
            where T : class, new()
        {
            var outputNames = GetOutputParameterNames(parameters);
            var dynamicParameters = BuildDynamicParameters(parameters);

            using var connection = new SqlConnection(ConnectionString);

            await connection.ExecuteAsync(
                procedureName,
                dynamicParameters,
                commandType: CommandType.StoredProcedure);

            return MapOutputToObject<T>(dynamicParameters, outputNames);
        }

        // 6. Multiple Output using SQL Statement - strongly typed DTO
        public static async Task<T> MultipleOutputBySqlAsync<T>(
            string sqlText,
            IDataParameter[] parameters)
            where T : class, new()
        {
            var outputNames = GetOutputParameterNames(parameters);
            var dynamicParameters = BuildDynamicParameters(parameters);

            using var connection = new SqlConnection(ConnectionString);

            await connection.ExecuteAsync(
                sqlText,
                dynamicParameters,
                commandType: CommandType.Text);

            return MapOutputToObject<T>(dynamicParameters, outputNames);
        }

        // 7. Single Output using SP
        public static async Task<T?> SingleOutputBySpAsync<T>(
            string procedureName,
            IDataParameter[] parameters,
            string outputParameterName)
        {
            var dynamicParameters = BuildDynamicParameters(parameters);

            using var connection = new SqlConnection(ConnectionString);

            await connection.ExecuteAsync(
                procedureName,
                dynamicParameters,
                commandType: CommandType.StoredProcedure);

            return dynamicParameters.Get<T>(outputParameterName);
        }

        // 8. Single Output using SQL Statement
        public static async Task<T?> SingleOutputBySqlAsync<T>(            string sqlText,            IDataParameter[] parameters,            string outputParameterName)
        {
            var dynamicParameters = BuildDynamicParameters(parameters);

            using var connection = new SqlConnection(ConnectionString);

            await connection.ExecuteAsync(
                sqlText,
                dynamicParameters,
                commandType: CommandType.Text);

            return dynamicParameters.Get<T>(outputParameterName);
        }

         
        
        // 9. Dynamic Output using SP
        public static async Task<dynamic> DynamicOutputBySpAsync(
            string procedureName,
            IDataParameter[] parameters)
        {
            var outputNames = GetOutputParameterNames(parameters);
            var dynamicParameters = BuildDynamicParameters(parameters);

            using var connection = new SqlConnection(ConnectionString);

            await connection.ExecuteAsync(
                procedureName,
                dynamicParameters,
                commandType: CommandType.StoredProcedure);

            return MapOutputToDynamic(dynamicParameters, outputNames);
        }

        // 10. Dynamic Output using SQL Statement
        public static async Task<dynamic> DynamicOutputBySqlAsync(
            string sqlText,
            IDataParameter[] parameters)
        {
            var outputNames = GetOutputParameterNames(parameters);
            var dynamicParameters = BuildDynamicParameters(parameters);

            using var connection = new SqlConnection(ConnectionString);

            await connection.ExecuteAsync(
                sqlText,
                dynamicParameters,
                commandType: CommandType.Text);

            return MapOutputToDynamic(dynamicParameters, outputNames);
        }


        // Scalar using SP
        public static async Task<T?> ScalarBySpAsync<T>(
            string procedureName,
            object? parameters = null)
        {
            using var connection = new SqlConnection(ConnectionString);

            return await connection.ExecuteScalarAsync<T>(
                procedureName,
                parameters,
                commandType: CommandType.StoredProcedure);
        }




        // Scalar using SQL
        public static async Task<T?> ScalarBySqlAsync<T>(
            string sqlText,
            object? parameters = null)
        {
            using var connection = new SqlConnection(ConnectionString);

            return await connection.ExecuteScalarAsync<T>(
                sqlText,
                parameters,
                commandType: CommandType.Text);
        }



        public static async Task<long> ExecuteScalarSqlAsync(string sqlText, object parameters = null)
        {
            using var connection = new SqlConnection(Utilities.Configuration.ConnectionString);

            return await connection.ExecuteScalarAsync<long>(
                sqlText,
                parameters,
                commandType: CommandType.Text
            );
        }


        // Private Methods

        private static IEnumerable<string> GetOutputParameterNames(
       IEnumerable<IDataParameter> parameters)
        {
            return parameters
                .Where(p =>
                    p.Direction == ParameterDirection.Output ||
                    p.Direction == ParameterDirection.InputOutput ||
                    p.Direction == ParameterDirection.ReturnValue)
                .Select(p => p.ParameterName)
                .ToArray();
        }
        private static DynamicParameters BuildDynamicParameters(       IEnumerable<IDataParameter> parameters)
        {
            var dynamicParameters = new DynamicParameters();

            foreach (var parameter in parameters)
            {
                var direction = parameter.Direction == 0
                    ? ParameterDirection.Input
                    : parameter.Direction;

                var value = direction == ParameterDirection.Output
                    ? null
                    : NormalizeDbNull(parameter.Value);

                var dbParameter = parameter as IDbDataParameter;
                var size = ResolveSize(dbParameter, direction);

                dynamicParameters.Add(
                    parameter.ParameterName,
                    value,
                    parameter.DbType,
                    direction,
                    size);
            }

            return dynamicParameters;
        }

        private static object? NormalizeDbNull(object? value)
        {
            return value == DBNull.Value ? null : value;
        }

        private static int? ResolveSize(      IDbDataParameter? parameter,      ParameterDirection direction)
        {
            if (parameter != null && parameter.Size > 0)
                return parameter.Size;

            bool isOutput =
                direction == ParameterDirection.Output ||
                direction == ParameterDirection.InputOutput ||
                direction == ParameterDirection.ReturnValue;

            if (isOutput && parameter?.DbType == DbType.String)
                return 4000;

            return null;
        }


        private static T MapOutputToObject<T>(        DynamicParameters dynamicParameters,        IEnumerable<string> outputNames)
        where T : class, new()
        {
            var result = new T();

            var properties = typeof(T)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.CanWrite)
                .ToArray();

            foreach (var outputName in outputNames)
            {
                var propertyName = outputName.TrimStart('@');

                var property = properties.FirstOrDefault(p =>
                    string.Equals(p.Name, propertyName, StringComparison.OrdinalIgnoreCase));

                if (property == null)
                    continue;

                var value = dynamicParameters.Get<dynamic>(outputName);

                SetPropertyValue(result, property, value);
            }

            return result;
        }

        private static dynamic MapOutputToDynamic(        DynamicParameters dynamicParameters,        IEnumerable<string> outputNames)
        {
            IDictionary<string, object?> result = new ExpandoObject();

            foreach (var outputName in outputNames)
            {
                result[outputName.TrimStart('@')] =
                    dynamicParameters.Get<dynamic>(outputName);
            }

            return result;
        }

        private static void SetPropertyValue<T>(            T target,            PropertyInfo property,            object? value)
        {
            if (value == null || value == DBNull.Value)
            {
                property.SetValue(target, null);
                return;
            }

            var targetType =
                Nullable.GetUnderlyingType(property.PropertyType) ??
                property.PropertyType;

            var convertedValue = Convert.ChangeType(value, targetType);

            property.SetValue(target, convertedValue);
        }


        ////0573187279
        //public static async Task<T> ExecuteSqlWithMultipleOutputParametersAsync<T>(string sqlText, IDataParameter[] parameters)
        // where T : class, new()
        //{
        //    var outputParameterNames = GetOutputParameterNames(parameters);
        //    var dynamicParameters = BuildDynamicParameters(parameters);

        //    using var connection = new SqlConnection(Utilities.Configuration.ConnectionString);

        //    await connection.ExecuteAsync(
        //        sqlText,
        //        dynamicParameters,
        //        commandType: CommandType.Text
        //    );

        //    var result = new T();

        //    var writableProperties = typeof(T)
        //        .GetProperties(BindingFlags.Instance | BindingFlags.Public)
        //        .Where(p => p.CanWrite)
        //        .ToArray();

        //    foreach (var outputParameterName in outputParameterNames)
        //    {
        //        var property = writableProperties.FirstOrDefault(p =>
        //            string.Equals(
        //                p.Name,
        //                outputParameterName.TrimStart('@'),
        //                StringComparison.OrdinalIgnoreCase));

        //        if (property == null)
        //            continue;

        //        var value = dynamicParameters.Get<dynamic>(outputParameterName);
        //        SetPropertyValue(result, property, value);
        //    }

        //    return result;
        //}

        //public static async Task<long> ExecuteScalarSqlAsync(string sqlText, object parameters = null)
        //{
        //    using var connection = new SqlConnection(Utilities.Configuration.ConnectionString);

        //    return await connection.ExecuteScalarAsync<long>(
        //        sqlText,
        //        parameters,
        //        commandType: CommandType.Text
        //    );
        //}


        //public static async Task<T> QueryFirstOrDefaultAsync<T>(string sqlText, object parameters = null)
        //{
        //    using var connection = new SqlConnection(Utilities.Configuration.ConnectionString);

        //    return await connection.QueryFirstOrDefaultAsync<T>(
        //        sqlText,
        //        parameters,
        //        commandType: CommandType.Text
        //    );
        //}

        //private static IEnumerable<string> GetOutputParameterNames(IEnumerable<IDataParameter> parameters)
        //{
        //    return parameters
        //        .Where(parameter =>
        //            parameter.Direction == ParameterDirection.Output ||
        //            parameter.Direction == ParameterDirection.InputOutput ||
        //            parameter.Direction == ParameterDirection.ReturnValue)
        //        .Select(parameter => parameter.ParameterName)
        //        .ToArray();
        //}

        //private static void SetPropertyValue<T>(T target, PropertyInfo property, object? value)
        //{
        //    if (value is null)
        //    {
        //        property.SetValue(target, null);
        //        return;
        //    }

        //    var targetType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
        //    var convertedValue = Convert.ChangeType(value, targetType);
        //    property.SetValue(target, convertedValue);
        //}

        //private static DynamicParameters BuildDynamicParameters(IEnumerable<IDataParameter> parameters)
        //{
        //    var dynamicParameters = new DynamicParameters();

        //    foreach (var parameter in parameters)
        //    {
        //        var direction = parameter.Direction == 0 ? ParameterDirection.Input : parameter.Direction;
        //        var value = direction == ParameterDirection.Output ? null : NormalizeDbNull(parameter.Value);
        //        var size = ResolveSize(parameter as IDbDataParameter, direction);
        //        dynamicParameters.Add(
        //            parameter.ParameterName,
        //            value,
        //            parameter.DbType,
        //            direction,
        //            size);
        //    }

        //    return dynamicParameters;
        //}

        //private static int? ResolveSize(IDbDataParameter? parameter, ParameterDirection direction)
        //{
        //    if (parameter is not null && parameter.Size > 0)
        //    {
        //        return parameter.Size;
        //    }

        //    var isOutputLike = direction == ParameterDirection.Output ||
        //        direction == ParameterDirection.InputOutput ||
        //        direction == ParameterDirection.ReturnValue;

        //    if (isOutputLike && parameter.DbType == DbType.String)
        //    {
        //        return 4000;
        //    }

        //    return null;
        //}

        //private static object? NormalizeDbNull(object? value)
        //{
        //    return value == DBNull.Value ? null : value;
        //}


        //public static async Task<dynamic> ExecuteSetWithMultipleOutputParametersAsync(string procedureName, IDataParameter[] parameters)
        //{
        //    var outputParameterNames = GetOutputParameterNames(parameters);
        //    var dynamicParameters = BuildDynamicParameters(parameters);

        //    await ExecuteProcedureAsync(procedureName, dynamicParameters);

        //    IDictionary<string, object?> result = new ExpandoObject();
        //    foreach (var outputParameterName in outputParameterNames)
        //    {
        //        result[outputParameterName] = dynamicParameters.Get<dynamic>(outputParameterName);
        //    }

        //    return (ExpandoObject)result;
        //}
        //public static async Task<T> ExecuteSetWithMultipleOutputParametersAsync<T>(string procedureName, IDataParameter[] parameters)
        //where T : class, new()
        //{
        //    var outputParameterNames = GetOutputParameterNames(parameters);
        //    var dynamicParameters = BuildDynamicParameters(parameters);

        //    await ExecuteProcedureAsync(procedureName, dynamicParameters);

        //    var result = new T();
        //    var writableProperties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public)
        //        .Where(property => property.CanWrite)
        //        .ToArray();

        //    foreach (var outputParameterName in outputParameterNames)
        //    {
        //        var property = writableProperties.FirstOrDefault(p =>
        //            string.Equals(p.Name, outputParameterName.TrimStart('@'), StringComparison.OrdinalIgnoreCase));

        //        if (property is null)
        //        {
        //            continue;
        //        }

        //        var value = dynamicParameters.Get<dynamic>(outputParameterName);
        //        SetPropertyValue(result, property, value);
        //    }

        //    return result;
        //}
        //private static async Task ExecuteProcedureAsync(string procedureName, DynamicParameters dynamicParameters)
        //{
        //    await using SqlConnection sqlConnection = new SqlConnection(Utilities.Configuration.ConnectionString);
        //    await SqlMapper.ExecuteAsync(sqlConnection, procedureName, dynamicParameters, commandType: CommandType.StoredProcedure);
        //}
    }
}
