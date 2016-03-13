﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DataAccess
{
    class SqlServerDatabase : DatabaseAbstract
    {
        private SqlConnection _connection = null;
        private SqlCommand _command = null;

        public override IDbConnection CreateConnection()
        {
            if (_connection == null)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
                _connection = new SqlConnection(connectionString);
            }
            return _connection;
            // return new SqlConnection(connectionString);
        }

        ////public override IDbConnection CreateConnection(string providerType)
        ////{
        ////    return new SqlConnection(connectionString);
        ////}

        public override IDbCommand CreateCommand()
        {
            return new SqlCommand();
        }

        public override IDbConnection CreateOpenConnection()
        {
            SqlConnection connection = (SqlConnection)CreateConnection();
            connection.Open();

            return connection;
        }

        public override IDbCommand CreateCommand(string commandText, IDbConnection connection)
        {
            SqlCommand command = (SqlCommand)CreateCommand();

            command.CommandText = commandText;
            command.Connection = (SqlConnection)connection;
            command.CommandType = CommandType.Text;

            return command;
        }

        public override IDbCommand CreateStoredProcCommand(string procName, IDbConnection connection)
        {
            SqlCommand command = (SqlCommand)CreateCommand();

            command.CommandText = procName;
            command.Connection = (SqlConnection)connection;
            command.CommandType = CommandType.StoredProcedure;

            return command;
        }

        public override IDataParameter CreateParameter(string parameterName, object parameterValue)
        {
            return new SqlParameter(parameterName, parameterValue);
        }

    }

}
