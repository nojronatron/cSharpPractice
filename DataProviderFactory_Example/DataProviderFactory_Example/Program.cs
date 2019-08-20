using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Configuration;
using static System.Console;

namespace DataProviderFactory_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // obtain the specific DbProviderFacotry object of the speicified darta provider by
            //  specifying a string name that represents the .NET namespace containing the provider's functionality
            DbProviderFactory sqlFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");

            WriteLine("***** Fun with Data Provider Factories *****\n");
            // Get connection string/provider from *.config
            string dataProvider = ConfigurationManager.AppSettings["provider"];
            string connectionString = ConfigurationManager.AppSettings["connectionString"];

            // Get the factory provider
            DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);

            // Now get the connection object
            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    ShowError("Connection");
                    return;
                }
                WriteLine($"Your connection object is a: {connection.GetType().Name}");
                connection.ConnectionString = connectionString;
                connection.Open();

                // Make command object
                DbCommand command = factory.CreateCommand();
                if (command == null)
                {
                    ShowError("Command");
                    return;
                }
                WriteLine($"Your command object is a: {command.GetType().Name}");
                command.Connection = connection;
                command.CommandText = "Select * From Inventory";

                // Print out data with data reader
                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    WriteLine($"Your data reader object is a: {dataReader.GetType().Name}");
                    WriteLine("\n***** Current Inventory *****");
                    while (dataReader.Read())
                    {
                        WriteLine($"-> Car #{dataReader["CarId"]} is a {dataReader["Make"]}.");
                    }
                }
            }
            ReadLine();
        }
        private static void ShowError(string objectName)
        {
            WriteLine($"There was an issue creating the {objectName}");
            ReadLine();
        }
    }
}
