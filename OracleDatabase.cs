using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataAccess
{
    public class OracleDatabase : DatabaseAbstract
    {
        private OracleConnection _connection = null;
        private OracleCommand _command = null;

        public override IDbConnection CreateConnection()
        {
            if (_connection == null)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;
                _connection = new OracleConnection(connectionString);
            }
            return _connection;
           // return new OracleConnection(connectionString);
        }

        //public override IDbConnection CreateConnection(string providerType)
        //{
        //    return new OracleConnection(connectionString);
        //}

        public override IDbCommand CreateCommand()
        {
            return new OracleCommand();
        }

        public override IDbConnection CreateOpenConnection()
        {
            OracleConnection connection = (OracleConnection)CreateConnection();
            connection.Open();

            return connection;
        }

        public override IDbCommand CreateCommand(string commandText, IDbConnection connection)
        {
            OracleCommand command = (OracleCommand)CreateCommand();

            command.CommandText = commandText;
            command.Connection = (OracleConnection)connection;
            command.CommandType = CommandType.Text;

            return command;
        }

        public override IDbCommand CreateStoredProcCommand(string procName, IDbConnection connection)
        {
            OracleCommand command = (OracleCommand)CreateCommand();

            command.CommandText = procName;
            command.Connection = (OracleConnection)connection;
            command.CommandType = CommandType.StoredProcedure;

            return command;
        }

        public override IDataParameter CreateParameter(string parameterName, object parameterValue)
        {
            return new OracleParameter(parameterName, parameterValue);
        }
    }
}
