using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AutoLotDataReader
{
    class Program
    {
        public enum ConnectionState
        {   // various connection states (read-only except Open (and Closed?) )
            Broken,
            Closed, // Closed state connection can always be Closed again safely
            Connecting,
            Executing,
            Fetching,
            Open
        }   // only Open, Connecting, and Closed are currently valid (rest are reserved for future-use)
        
        public enum CommandType
        {   // Derived from DbCommand, SqlCommand types supported are:
            StoredProcedure,
            TableDirect,
            Text // default value
        }
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Data Readers *****");
            Console.WriteLine("DataReader objects are foward-only, read-only.");
            Console.WriteLine("Remember, DataReader can only query a database with SELECT statements it cannot " + 
                "INSERT, UPDATE, or DELETE.");
            Console.WriteLine("However, multiple Queries can be submitted (like T-SQL) separated by semi-colons.");
            // Create a connection string via the builder object pg833:
            var cnStringBuilder = new SqlConnectionStringBuilder
            {
                InitialCatalog = "AutoLot",
                DataSource = @"BLUE-PC",//                @"(localdb)\mssqllocaldb",
                ConnectTimeout = 30,
                IntegratedSecurity = true
            };  // Data Source=BLUE-PC;Initial Catalog=AutoLot;Integrated Security=True
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = cnStringBuilder.ConnectionString;
                connection.Open();
                ShowConnectionStatus(connection);
                //    Console.ReadLine();
                //    connection.Close();
                //}

                //// Create an open connection
                //using (SqlConnection connection = new SqlConnection())
                //{
                //    connection.ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Integrated Security=true;Initial Catalog=Autolot";
                //    connection.Open();

                // Create a SQL command object
                string sql = "Select * from Inventory";
                SqlCommand myCommand = new SqlCommand(sql, connection);

                // obtain a data reader a la ExecuteReader()
                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {
                    // loop over the results
                    while (myDataReader.Read())
                    {
                        //Console.WriteLine($"-> Make: {myDataReader["Make"]}, PenName: {myDataReader["PetName"]}," +
                        //                  $" Color: {myDataReader["Color"]}.");
                        // Better way:
                        for (int i = 0; i < myDataReader.FieldCount; i++)
                        {
                            Console.WriteLine($"{myDataReader.GetName(i)} = {myDataReader.GetValue(i)}");
                        }
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Press <Enter> to exit. . .");
            Console.ReadLine();
        }
        static void ShowConnectionStatus(SqlConnection connection)
        {
            Console.WriteLine("*** Info about your connection ***");
            Console.WriteLine($"Database Location {connection.DataSource}");
            Console.WriteLine($"Database name: {connection.Database}");
            Console.WriteLine($"Timeout: {connection.ConnectionTimeout}");
            Console.WriteLine($"Connection State: {connection.State}\n");
        }
    }
}
