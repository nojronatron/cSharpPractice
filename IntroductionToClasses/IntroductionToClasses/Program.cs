using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToClasses
{
    // define a Car class -- a Blueprint or Template for creating Objects
    public class Car
    {
        // define fields
        public string make;
        public string model;
        public int year;
        public int mileage;
        public decimal price;

        // define constructor(s)

        // define properties

        // define methods

    }

    public class Employee
    {
        // Goal: Make the Fields private
        private string firstname;
        private string lastname;
        private int id;
        private decimal salary;

        // Goal: Create a Constructor to initialize the private Fields
        // Constructor is a special Method
        // Constructor MUST have SAME NAME as the Class
        // Constructor has NO return type (no void, etc)
        // In general, the Constructor should have some Parameters (to init the Fields)
        // Should be PUBLIC
        public Employee(string firstname, string lastname, int id, decimal salary)
        {
            // The Constructor is just a bunch of assignments [Field = Parameter]
            this.firstname = firstname; // keyword "this", like self (Python et al.)
            this.lastname = lastname;
            this.id = id;
            this.salary = salary;
        }

        public void Display()
        {
            // Provide a METHOD to display the Employee Object Fields
            // Make it public so it can be accessed from 'outside'
            Console.WriteLine("***** Employee Info *****");
            Console.WriteLine($"Employee Name: {lastname}, {firstname}"); // this (self) is optional (outside of the Constructor)
            Console.WriteLine($"Employee ID: {this.id}");
            Console.WriteLine($"{this.firstname} {this.lastname}'s salary: {this.salary:c0}");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();
            myCar.make = "Subaru";
            myCar.model = "Impreza";
            myCar.year = 2015;
            myCar.mileage = 21_315;
            myCar.price = 37_995;

            Console.Clear(); // Object.Method() ==> Clears the Console Window of contents

            Display(myCar);

            Console.WriteLine();

            // data hiding is happening because Fields are private (data hiding)
            // Employee myEmployee = new Employee();
            // cannot do this: myEmployee.firstname;
            Employee myEmployee = new Employee("John", "Anon", 123456789, 78000);
            myEmployee.Display();

            // Stop program execution before exit
            Console.ReadLine();
        }
    static void Display(Car c)
    {
        Console.WriteLine($"Make: {c.make}; Model {c.model}; Year: {c.year}; Mileage: {c.mileage:n0}; Price: {c.price:c0}.");
    }
    }

}
