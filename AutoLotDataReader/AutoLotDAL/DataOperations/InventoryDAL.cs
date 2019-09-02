using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AutoLotDAL.Models;
using static System.Console;

namespace AutoLotDAL.DataOperations
{
    public class InventoryDAL
    {
        private readonly string _connectionString;
        public InventoryDAL() : this(@"Data Source = BLUE-PC;Integrated Security=true;Initial Catalog=AutoLot") { }
        public InventoryDAL(string connectionString) => _connectionString = connectionString;
        private SqlConnection _sqlConnection = null;
        private void OpenConnection()
        {
            _sqlConnection = new SqlConnection { ConnectionString = _connectionString };
            _sqlConnection.Open();
        }
        private void CloseConnection()
        {
            try // custom try-catch added by me
            {
                if (_sqlConnection?.State != ConnectionState.Closed) // if _sqlConnection != null then if != ConnectionState.Closed
                {
                    _sqlConnection?.Close(); // if _sqlConnection != null then _sqlConnection.Close()
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected Exception was thrown in InventoryDAL.CloseConnection()");
                Console.WriteLine(ex.Message);
            }
        }
        public List<Car> GetAllInventory()
        {
            OpenConnection();
            // This will hold the records
            List<Car> inventory = new List<Car>();

            // prep command object
            string sql = "Select * From Inventory";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    inventory.Add(new Car
                    {
                        CarId = (int)dataReader["CarId"],
                        Color = (string)dataReader["Color"],
                        Make = (string)dataReader["Make"],
                        PetName = (string)dataReader["PetName"]
                    });
                }
                dataReader.Close();
            }
            return inventory;
        }
        public Car GetCar(int id)
        {
            OpenConnection();
            Car car = null;
            string sql = $"Select * From Inventory where CarId = {id}";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    car = new Car
                    {
                        CarId = (int)dataReader["CarId"],
                        Color = (string)dataReader["Color"],
                        Make = (string)dataReader["Make"],
                        PetName = (string)dataReader["PetName"]
                    };
                }
                dataReader.Close();
            }
            return car;
        }
        public void InsertAuto(string color, string make, string petname)
        {
            OpenConnection();
            // format and execute SQL statement
            string sql = $"Inset Into Inventory (Make, Color, PetName) Values ('{make}','{color}','{petname}')";
            // execute using our connection
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"InsertAuto() method executed. {rowsAffected} rows affected.");
            }
            CloseConnection();
        }
        public void InsertAuto(Car car)
        {
            OpenConnection();
            // format and execute SQL statement
            string sql = "Insert Into Inventory " +
                         "(Make, Color, PetName) Values " +
                         "(@Make, @Color, @PetName)"; // safer way using internal Parameters 
                                                      // vulnerable way: $"('{car.Make}','{car.Color}','{car.PetName}')";
                                                      // execute using our connection - now with super Params
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@Make",
                    Value = car.Make,
                    SqlDbType = SqlDbType.Char,
                    Size = 10
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@Color",
                    Value = car.Color,
                    SqlDbType = SqlDbType.Char,
                    Size = 10
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@PetName",
                    Value = car.PetName,
                    SqlDbType = SqlDbType.Char,
                    Size = 10
                };
                command.Parameters.Add(parameter);
                // command.CommandType = CommandType.Text; now using Super Params (tm)
                // although Params require more code, the Parameter Objects support a number of overloaded CTORs
                //   that allow setting values of various properties, they allow tweaking SQL statements
                //   programmatically, are more performant, and can be used to trigger a stored procedure

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"InsertAuto<Car> method executed. {rowsAffected} rows affected.");
            }
            CloseConnection();
        }
        public void DeleteCar(int id)
        {
            OpenConnection();
            // get ID of car to delete then do so
            string sql = $"Delete from Inventory where CarId = '{id}'";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                try
                {
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Sorry! That car is on order!", ex);
                    throw error;
                }
            }
            CloseConnection();
        }
        public void UpdateCarPetName(int id, string newPetName)
        {
            OpenConnection();
            // get ID of car to modify the pet name
            string sql = $"Update Inventory Set PetName = '{newPetName}' Where CarId = '{id}'";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }
        public string LookupPetName(int carId)
        {
            OpenConnection();
            string carPetName;

            // establish name of stored procedure
            using (SqlCommand command = new SqlCommand("GetPetName", _sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                // input parameter
                SqlParameter param = new SqlParameter
                {
                    ParameterName = "@carId",
                    SqlDbType = SqlDbType.Int,
                    Value = carId,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(param);

                // output parameter
                param = new SqlParameter
                {
                    ParameterName = "@petName",
                    SqlDbType = SqlDbType.Char,
                    Size = 10,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(param);

                // execute the SP
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"LookupPetName() with Stored Procedure affected {rowsAffected} rows.");

                // return the output param
                carPetName = (string)command.Parameters["@petName"].Value;
                CloseConnection();
            }
            return carPetName;
        }
        public void ProcessCreditRisk(bool throwEx, int custId)
        {
            OpenConnection();
            // first look up current name based on customer ID
            string fName = "";
            string lName = "";
            string sqlCommandText =
                $"SELECT * FROM [Customers] WHERE [CustID] = {custId}";
            // $"SELECT [CustID],[FirstName],[LastName] FROM[dbo].[Customers] WHERE[CustID] = {custId}";
            var cmdSelect = new SqlCommand(sqlCommandText, _sqlConnection);
            //var cmdSelect = new SqlCommand($"Select * from Customers where CustId = {custId}", _sqlConnection);
            using (var dataReader = cmdSelect.ExecuteReader())
            {
                if (dataReader.HasRows)
                {
                    try
                    {   // added try/catch due to session collision issues
                        // if no other sessions exist from this exe then dataReader will have data
                        // if other sessions exist from this exe then dataReader comes back empty
                        // go to ssms to fix dead session(s) from visual studio/InventoryDAL to preempt issues
                        dataReader.Read();
                        fName = (string)dataReader["FirstName"];
                        lName = (string)dataReader["LastName"];
                    }
                    catch (Exception ex)
                    {
                        WriteLine($"Something went wrong:\n{ex}\n\nClosing Connection...");
                        CloseConnection();
                    }
                }
                else
                {
                    CloseConnection();
                    return;
                }
            }

            // create comand objects that represent each step of the operation
            var cmdRemove = new SqlCommand(
                $"Delete from Customers where CustId = {custId}", _sqlConnection);
            var cmdInsert = new SqlCommand(
                $"Insert into CreditRisks table (FirstName, LastName) Values('{fName}', '{lName}')", _sqlConnection);

            // get this from the connection object
            SqlTransaction tx = null;
            try
            {
                tx = _sqlConnection.BeginTransaction();

                // enlist the commands into this transaction
                cmdInsert.Transaction = tx;
                cmdRemove.Transaction = tx;

                // execute the commands
                cmdInsert.ExecuteNonQuery();
                cmdRemove.ExecuteNonQuery();

                // simulate error
                if (throwEx)
                {
                    throw new Exception("Sorry! DB error; TX failed. . .");
                }

                // commit it
                tx.Commit();
            }
            catch (Exception ex)
            {
                // WriteLine("\nEntered catch block via throwEx=true logic....");
                WriteLine(ex.Message);
                // any error will roll back transaction
                // use the new conditional access operator to check for null
                tx?.Rollback();
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
