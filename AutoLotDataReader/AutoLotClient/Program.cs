using System;
using static System.Console;
using System.Collections.Generic;
using AutoLotDAL.DataOperations;
using AutoLotDAL.Models;
using System.Linq;

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

            WriteLine("Press <Enter> to Continue. . .");
            ReadLine();
        }
        static void DisplayCars(List<Car> listOfCars)
        {
            WriteLine("CarId\tMake\tColor\tPet Name");
            foreach (Car c in listOfCars)
            {
                WriteLine($"{c.CarId}\t{c.Make}\t{c.Color}\t{c.PetName}");
            }
        }
    }
}
