using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;      // ADO.NET types used by all data providers including common interfaces and numerous types representing diconencted layer [DataSet; DataTable]
using System.Data.Common;   // contains types shared between all ADO.NET data providers including common abstract base classes
using System.Data.Sql;  // allow discovery of SQL Server instances on current local network
using System.Data.SqlClient;    // collection of classes used to access SQL Server in the managed space
using System.Data.OleDb;    // allow access to data supported by COM-based OLE DB protocol
using System.Data.Odbc;     // allow access via COM objects to enable access to DBMS's lacking a dotNET 3rdPart/custom interface
//  3rd Party ADO.NET providers can be found via the 3rd party providers' websites or via reference from docs.microsoft.com
using static System.Console;    // no more CW[tab][tab] just use WriteLine() instead


namespace ADONET_Connectivity_Factory_Example1
{
    // console app that allows you to obtain specific connection object based on the value of  acustom enumeration
    // Ref: Pro C#7 Chpt 21, pp.813-814
    enum DataProvider
    {
        // list of possible providers (depends on using statements above)
        SqlServer, OldeDb, Odbc, None
    }
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("***** Very Simple Connection Factory *****\n");
            //  Get a specific connection
            IDbConnection myConnection = GetConnection(DataProvider.SqlServer);
            WriteLine($"Your connection is a {myConnection.GetType().Name}");
            // Open, use and close connection...


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
                case DataProvider.OldeDb:
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
