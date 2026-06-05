using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.Data.Services.DataAccessLayer
{
    public abstract class DataAccessLayer : IDisposable
    {

        private string _result;
        private int _commandTimeout;
        private string _connectionString;
        private SqlConnection _sqlConnection;

        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }


        public DataAccessLayer(string connectionString)
        {
            _connectionString = connectionString;
            _sqlConnection = new SqlConnection(connectionString);
            _commandTimeout = 120;
        }

        public virtual void Dispose()
        {
            try
            {
                if (_sqlConnection.State != ConnectionState.Closed)
                {
                    _sqlConnection.Close();
                }
            }
            finally
            {
                _sqlConnection.Dispose();
                _sqlConnection = null;
                GC.Collect();
            }
        }


        private SqlCommand BuildIntCommand(string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = BuildSqlCommand(storedProcName, parameters);
            command.CommandTimeout = _commandTimeout;
            command.Parameters.Add(new SqlParameter("@ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }

        private SqlCommand BuildSqlCommand(string procedureName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(procedureName, _sqlConnection);
            command.CommandTimeout = _commandTimeout;
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            return command;
        }

        private SqlCommand BuildSqlCommand(string procedureName, IDataParameter[] parameters, string[] outputParameters)
        {
            SqlCommand command = BuildSqlCommand(procedureName, parameters);
            command.CommandTimeout = _commandTimeout;
            foreach (string parameter in outputParameters)
            {
                command.Parameters.Add(new SqlParameter(parameter, SqlDbType.Variant, 50, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            }
            return command;
        }

        protected SqlDataReader RunProcedure(string query)
        {
            _sqlConnection.ConnectionString = ConnectionString;
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
            //this._sqlConnection.Open();
            SqlCommand command = new SqlCommand(query, _sqlConnection);
            command.CommandTimeout = _commandTimeout;
            command.CommandType = CommandType.Text;
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        protected SqlDataReader RunProcedure(string procedureName, IDataParameter[] parameters)
        {
            _sqlConnection.ConnectionString = ConnectionString;
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
            //this._sqlConnection.Open();
            return BuildSqlCommand(procedureName, parameters).ExecuteReader(CommandBehavior.CloseConnection);
        }

        protected string GetOneResult(string query)
        {
            _result = string.Empty;
            _sqlConnection.ConnectionString = ConnectionString;
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
            try
            {
                SqlCommand command = new SqlCommand(query, _sqlConnection);
                command.CommandTimeout = _commandTimeout;
                command.CommandType = CommandType.Text;
                _result = command.ExecuteScalar().ToString();
            }
            finally
            {
                _sqlConnection.Close();
            }
            return _result;
        }

        protected string GetOneResult(string procedureName, IDataParameter[] parameters)
        {
            _result = string.Empty;
            _sqlConnection.ConnectionString = ConnectionString;
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
            try
            {
                SqlCommand command = BuildSqlCommand(procedureName, parameters);
                command.CommandTimeout = _commandTimeout;
                _result = command.ExecuteScalar().ToString();
                command.Dispose();
            }
            finally
            {
                _sqlConnection.Close();
            }
            return _result;
        }

        protected void RunProcedure(string procedureName, IDataParameter[] parameters, out int affectedRow)
        {
            _sqlConnection.ConnectionString = ConnectionString;
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
            try
            {
                SqlCommand command = BuildIntCommand(procedureName, parameters);
                command.CommandTimeout = _commandTimeout;
                affectedRow = command.ExecuteNonQuery();
            }
            finally
            {
                if (_sqlConnection.State != ConnectionState.Closed)
                {
                    _sqlConnection.Close();
                }
                //this._sqlConnection.Close();
            }
        }

        protected DataSet RunProcedure(string procedureName, IDataParameter[] parameters, string tableName)
        {
            DataSet dataSet = new DataSet();
            _sqlConnection.ConnectionString = ConnectionString;
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
            try
            {
                new SqlDataAdapter(BuildSqlCommand(procedureName, parameters)).Fill(dataSet, tableName);
            }
            finally
            {
                if (_sqlConnection.State != ConnectionState.Closed)
                {
                    _sqlConnection.Close();
                }
                //this._sqlConnection.Close();
            }
            return dataSet;
        }

        protected DataSet RunProcedure(string procedureName, IDataParameter[] parameters, bool isTables)
        {
            DataSet dataSet = new DataSet();
            _sqlConnection.ConnectionString = ConnectionString;
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
            try
            {
                new SqlDataAdapter(BuildSqlCommand(procedureName, parameters)).Fill(dataSet);
            }
            catch { }
            finally
            {
                if (_sqlConnection.State != ConnectionState.Closed)
                {
                    _sqlConnection.Close();
                }
                //this._sqlConnection.Close();
            }
            return dataSet;
        }



        protected DataSet RunProcedure(string procedureName, bool isTables)
        {
            DataSet dataSet = new DataSet();
            _sqlConnection.ConnectionString = ConnectionString;
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
            try
            {
                SqlCommand selectCommand = new SqlCommand(procedureName, _sqlConnection);
                selectCommand.CommandTimeout = _commandTimeout;
                selectCommand.CommandType = CommandType.Text;
                new SqlDataAdapter(selectCommand).Fill(dataSet);
            }
            finally
            {
                if (_sqlConnection.State != ConnectionState.Closed)
                {
                    _sqlConnection.Close();
                }
                //this._sqlConnection.Close();
            }
            return dataSet;
        }



        protected DataSet RunProcedure(string query, string tableName)
        {
            DataSet dataSet = new DataSet();
            _sqlConnection.ConnectionString = ConnectionString;
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
            try
            {
                SqlCommand selectCommand = new SqlCommand(query, _sqlConnection);
                selectCommand.CommandTimeout = _commandTimeout;
                selectCommand.CommandType = CommandType.Text;
                new SqlDataAdapter(selectCommand).Fill(dataSet, tableName);
            }
            finally
            {
                if (_sqlConnection.State != ConnectionState.Closed)
                {
                    _sqlConnection.Close();
                }
                //this._sqlConnection.Close();
            }
            return dataSet;
        }

        protected DataSet RunProcedure(string procedureName, string outputParameter, IDataParameter[] parameters, string tableName, out int affectedRow)
        {
            DataSet dataSet = new DataSet();
            _sqlConnection.ConnectionString = ConnectionString;
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
            try
            {
                SqlCommand command = BuildSqlCommand(procedureName, parameters);
                command.CommandTimeout = _commandTimeout;
                new SqlDataAdapter(command).Fill(dataSet, tableName);
                affectedRow = (int)command.Parameters[outputParameter].Value;
            }
            finally
            {
                if (_sqlConnection.State != ConnectionState.Closed)
                {
                    _sqlConnection.Close();
                }
                //this._sqlConnection.Close();
            }
            return dataSet;
        }

        protected object RunProcedure(string procedureName, string outputParameter, IDataParameter[] parameters)
        {
            _sqlConnection.ConnectionString = ConnectionString;
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
            try
            {
                SqlCommand command = BuildIntCommand(procedureName, parameters);
                command.CommandTimeout = _commandTimeout;
                command.ExecuteNonQuery();
                return command.Parameters[outputParameter].Value;
            }
            catch (Exception ex) { return null; }
            finally
            {
                if (_sqlConnection.State != ConnectionState.Closed)
                {
                    _sqlConnection.Close();
                }
                //this._sqlConnection.Close();
            }
        }

        protected System.Collections.ArrayList RunProcedure(string procedureName, string[] outputParameters, IDataParameter[] parameters)
        {
            _sqlConnection.ConnectionString = ConnectionString;
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
            try
            {
                System.Collections.ArrayList arrayList = new System.Collections.ArrayList();
                SqlCommand command = BuildSqlCommand(procedureName, parameters, outputParameters);
                command.CommandTimeout = _commandTimeout;
                command.ExecuteNonQuery();
                foreach (string parameter in outputParameters)
                {
                    arrayList.Add(command.Parameters[parameter].Value);
                }
                return arrayList;
            }
            finally
            {
                if (_sqlConnection.State != ConnectionState.Closed)
                {
                    _sqlConnection.Close();
                }
                //this._sqlConnection.Close();
            }
        }

        protected void ManuplateTable(string query)
        {
            _sqlConnection.ConnectionString = ConnectionString;
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
            try
            {
                SqlCommand command = new SqlCommand(query, _sqlConnection);
                command.CommandTimeout = _commandTimeout;
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                command.Dispose();
            }
            finally
            {
                if (_sqlConnection.State != ConnectionState.Closed)
                {
                    _sqlConnection.Close();
                }
                //this._sqlConnection.Close();
            }
        }

        protected void ManuplateTable(string procedureName, IDataParameter[] parameters)
        {
            _sqlConnection.ConnectionString = ConnectionString;
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
            try
            {
                SqlCommand command = BuildSqlCommand(procedureName, parameters);
                command.CommandTimeout = _commandTimeout;
                command.ExecuteNonQuery();
                command.Dispose();
            }
            finally
            {
                if (_sqlConnection.State != ConnectionState.Closed)
                {
                    _sqlConnection.Close();
                }
                //this._sqlConnection.Close();
            }
        }

        protected Task<DataSet> RunProcedureAsync1(string procedureName, IDataParameter[] parameters)
        {
            return Task.Run(() =>
            {
                DataSet dataSet = new DataSet();
                _sqlConnection.ConnectionString = ConnectionString;
                if (_sqlConnection.State == ConnectionState.Closed)
                {
                    _sqlConnection.Open();
                }
                try
                {
                    new SqlDataAdapter(BuildSqlCommand(procedureName, parameters)).Fill(dataSet);
                }
                catch { }
                finally
                {
                    if (_sqlConnection.State != ConnectionState.Closed)
                    {
                        _sqlConnection.Close();
                    }
                    //this._sqlConnection.Close();
                }
                return dataSet;
            });
        }
        protected Task<DataSet> RunProcedureAsync(string procedureName)
        {
            return Task.Run(() =>
            {
                DataSet dataSet = new DataSet();
                _sqlConnection.ConnectionString = ConnectionString;
                if (_sqlConnection.State == ConnectionState.Closed)
                {
                    _sqlConnection.Open();
                }
                try
                {
                    SqlCommand selectCommand = new SqlCommand(procedureName, _sqlConnection);
                    selectCommand.CommandTimeout = _commandTimeout;
                    selectCommand.CommandType = CommandType.Text;
                    new SqlDataAdapter(selectCommand).Fill(dataSet);
                }
                finally
                {
                    if (_sqlConnection.State != ConnectionState.Closed)
                    {
                        _sqlConnection.Close();
                    }
                    //this._sqlConnection.Close();
                }
                return dataSet;
            });
        }
        protected Task<object> RunProcedureAsync(string procedureName, string outputParameter, IDataParameter[] parameters)
        {
            return Task.Run(() =>
            {
                _sqlConnection.ConnectionString = ConnectionString;
                if (_sqlConnection.State == ConnectionState.Closed)
                {
                    _sqlConnection.Open();
                }
                try
                {
                    SqlCommand command = BuildIntCommand(procedureName, parameters);
                    command.CommandTimeout = _commandTimeout;
                    command.ExecuteNonQuery();
                    return command.Parameters[outputParameter].Value;
                }
                catch (Exception ex) { return null; }
                finally
                {
                    if (_sqlConnection.State != ConnectionState.Closed)
                    {
                        _sqlConnection.Close();
                    }
                    //this._sqlConnection.Close();
                }
            });
        }

        public Task<DataSet> RunProcedureAsync(string procedureName, IDataParameter[] parameters)
        {
            return Task.Run(() =>
            {

                using (var Connection = new SqlConnection(ConnectionString))
                using (var command = new SqlCommand(procedureName, _sqlConnection))
                {
                    try
                    {
                        if (Connection.State == ConnectionState.Closed)
                        {
                            Connection.Open();
                        }
                        command.CommandTimeout = _commandTimeout;
                        command.CommandType = CommandType.StoredProcedure;
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                        SqlDataAdapter sqldataAdapter = new SqlDataAdapter(command);
                        DataSet dataSet = new DataSet();
                        sqldataAdapter.Fill(dataSet);
                        return dataSet;
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }


                }
            });
        }

    }
}
