using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Configuration;
using System.Data;

namespace DataAccess
{
  

    public sealed class DatabaseFactory
    {
       // public static DatabaseFactorySectionHandler sectionHandler = (DatabaseFactorySectionHandler)ConfigurationManager.GetSection("DatabaseFactoryConfiguration");

        private string providerName { get; set; }

        private DatabaseFactory() { this.providerName = string.Empty; }

        public static DatabaseAbstract CreateDatabase(string providerName)
        {
            // Verify a DatabaseFactoryConfiguration line exists in the web.config.
            if (providerName.Length == 0)
            {
                throw new Exception("Database name not defined in DatabaseFactoryConfiguration section of web.config.");
            }

            try
            {
                // Find the class
                Type database = Type.GetType(providerName);

                // Get it's constructor
                ConstructorInfo constructor = database.GetConstructor(new Type[] { });

                // Invoke it's constructor, which returns an instance.
                DatabaseAbstract createdObject = (DatabaseAbstract)constructor.Invoke(null);

                // Initialize the connection string property for the database.
               // createdObject.connectionString = sectionHandler.ConnectionString;

                // Pass back the instance as a Database
                return createdObject;
            }
            catch (Exception excep)
            {
                throw new Exception("Error instantiating database " + "sectionHandler.Name" + ". " + excep.Message);
            }
        }
    }
}
