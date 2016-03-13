using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{

    public class DatabaseBuilder
    {
        public static DatabaseAbstract CreateDatabase(DatabaseType databaseType)
        {
            switch (databaseType)
            {
                case DatabaseType.SqlServer:
                    return new SqlServerDatabase();

                case DatabaseType.OleDb:
                    return new OracleDatabase();
                default: return new SqlServerDatabase();
            }
        }
    }

}


