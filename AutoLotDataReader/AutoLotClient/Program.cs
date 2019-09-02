using System;
using static System.Console;
using System.Collections.Generic;
using AutoLotDAL.DataOperations;
using AutoLotDAL.Models;
using System.Linq;
using AutoLotDAL.BulkImport;

namespace AutoLotClient
{
    class Program
    {
        static void Main(string[] args)
        {
            InventoryDAL dal = new InventoryDAL();
            var list = dal.GetAllInventory();
            WriteLine("***** Get All Inventory *****");
            DisplayCars(list);
            WriteLine();
            Car car = dal.GetCar(list.OrderBy(x => x.Color).Select(x => x.CarId).First()); // ..OrderBy is a Linq thing
            WriteLine("*** First Car By Color***");
            WriteLine($"{car.CarId}\t{car.Make}\t{car.Color}\t{car.PetName}");

            try
            {
                dal.DeleteCar(5);
                WriteLine("Car 5 deleted.");
            }
            catch (Exception ex)
            {
                WriteLine($"An exception occurred: {ex.Message}");
            }

            dal.InsertAuto(new Car { Color = "Blue", Make = "Pilot", PetName = "TowMonster" });
            list = dal.GetAllInventory();
            Car newCar = list.First(x => x.PetName == "TowMonster");
            WriteLine("*** New Car ***");
            WriteLine("CarId\tMake\tColor\tPetName");
            WriteLine($"{newCar.CarId}\t{newCar.Make}\t{newCar.Color}\t{newCar.PetName}");
            dal.DeleteCar(newCar.CarId);
            string petName = dal.LookupPetName(car.CarId);
            WriteLine("*** New Car ***");
            WriteLine($"Car pet name: {petName}");
            WriteLine();

            WriteLine("\n***** All Cars Currently in DB *****");
            list = dal.GetAllInventory();
            DisplayCars(list);

            // WriteLine("\n*** Move Customer Example Using Transactions ***");
            // MoveCustomer();

            // DoBulkCopy example
            DoBulkCopy();

            WriteLine("\n\nPress <Enter> to Continue. . .");
            ReadLine();
        }
        public static void DoBulkCopy()
        {
            WriteLine("******* Do Bulk Copy *******");
            var cars = new List<Car>
            {
                new Car() { Color = "Blue", Make = "Honda", PetName = "BulkCar1"},
                new Car() { Color = "Red", Make = "Subaru", PetName = "BulkCar2"},
                new Car() { Color="White", Make="VW", PetName="BulkCar3"},
                new Car() { Color = "Yellow", Make="Toyota", PetName = "BlukCar4"}
            };

            ProcessBulkImport.ExecuteBulkImport(cars, "Inventory");
            Console.WriteLine("Bulk copy completed.");
            InventoryDAL dal = new InventoryDAL();
            var list = dal.GetAllInventory();
            Console.WriteLine(" ************** Display All Cars ************** ");
            Console.WriteLine("CarId\tMake\tColor\tPet Name");
            foreach (var item in list)
            {
                Console.WriteLine($"{item.CarId}\t{item.Make}\t{item.Color}\t{item.PetName}");
            }
            WriteLine();
        }
        public static void DisplayCars(List<Car> listOfCars)
        {
            WriteLine("CarId\tMake\tColor\tPet Name");
            foreach (Car c in listOfCars)
            {
                WriteLine($"{c.CarId}\t{c.Make}\t{c.Color}\t{c.PetName}");
            }
        }
        public static void MoveCustomer()
        {
            WriteLine("*** Simple Transation Example ***");

            // a simple way to allow the tx to succeed or not
            bool throwEx = false;

            Write("Do you want to throw an exception (y or n): ");
            var userAnswer = ReadLine();
            if (userAnswer?.ToLower() == "y")
            {
                throwEx = true;
            }

            var dal = new InventoryDAL();
            // process customer 1 - enter the id for the customer to move
            dal.ProcessCreditRisk(throwEx, 1);
            WriteLine("Check CreditRisk table for results.");
            ReadLine();
        }
    }
}
