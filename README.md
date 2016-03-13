# DataAccess
This project will support SQL and Oracle database access 

1. Create New .NET C# solution
2. Right click on Solution and click ADD New project
3. Select Visual C# --> Windows option and select Class Library project and remname it "DataAccess"
4. Add the attached C# files to the project.
5. DatabaseAbstract.cs 
6. DatabaseBuilder.cs
7. DatabaseType.cs
8. OracleDatabase.cs
9. SqlDatabase.cs
10. Now add the reference dlls "System.Data.OracleClient" to the project for Oracle database connection
11. Now add the reference dlls "System.Configuration" to the project to read the connection string from configuration files.
12. Build the DataAccess Solution.
13. Now you cann use DataAccess dll in your web or windows project to connect the database.
14. Below is code to connect the select database.
15. DatabaseAbstract dbA;
            DatabaseType dt = DatabaseType.SqlServer;
            dbA = DatabaseBuilder.CreateDatabase(dt);
            // int id= 0;

            using (IDbConnection connection = dbA.CreateOpenConnection())
            {
                using (IDbCommand command = dbA.CreateStoredProcCommand("StoredProcedure_Name", connection))
                {
                    command.Parameters.Add(dbA.CreateParameter("@Tablename", tablename));
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                        }
                    }
                }
            }

