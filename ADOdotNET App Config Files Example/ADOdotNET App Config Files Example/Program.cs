using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using static System.Console;

namespace ADOdotNET_App_Config_Files_Example
{
    enum DataProvider { SqlServer, Oledb, Odbc, None };
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("***** Very Simple Connection Factory *****\n");
            // read the provider key from the .config xml file
            string dataProviderString = ConfigurationManager.AppSettings["provider"];
            WriteLine($"dataProviderString: {dataProviderString}");
            Console.ReadLine();

            // transform string to enum
            DataProvider dataProvider = DataProvider.None;
            if (Enum.IsDefined(typeof(DataProvider), dataProviderString))
            {
                dataProvider = (DataProvider)Enum.Parse(typeof(DataProvider), dataProviderString);
            }
            else
            {
                WriteLine("Sorry, no Data Provider exists!");
                ReadLine();
                return;
            }
            // Get a specific connection
            IDbConnection myConnection = GetConnection(dataProvider);
            WriteLine($"Your connection is a {myConnection?.GetType().Name ?? "unrecognized type"}");

            // open, use, and close the connection...


            ReadLine();
        }
        static IDbConnection GetConnection(DataProvider dataProvider)
        {
            IDbConnection connection = null;
            switch (dataProvider)
            {
                case DataProvider.SqlServer:
                    {
                        connection = new SqlConnection();
                        break;
                    }
                case DataProvider.Oledb:
                    {
                        connection = new OleDbConnection();
                        break;
                    }
                case DataProvider.Odbc:
                    {
                        connection = new OdbcConnection();
                        break;
                    }
            }
            return connection;
        }
    }
}
