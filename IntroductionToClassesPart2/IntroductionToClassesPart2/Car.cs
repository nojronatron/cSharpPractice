using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToClassesPart2
{
    public class Car
    {
        // Create Fields, keep them private
        private string make;
        private string model;
        private int year;
        private int mileage;
        private decimal price;

        // custom Constructor:
        public Car(string make, string model, int year, int mileage, decimal price)
        {
            // initialize the Fields, without giving direct access to them
            this.make = make;
            this.model = model;
            this.year = year;
            this.mileage = mileage;
            this.price = price;
        }

        // default Constructor:
        //     Every Constructor MUST have the same name as the Class
        //     Provide Default Values for Fields if Class is created without adding them
        //     Is a Constructor without any parameters
        public Car()
        {
            this.make = "Subaru";
            this.model = "Impreza";
            this.year = 1953;
            this.mileage = 0;
            this.price = 0;
        }

        // Accessors:
        // Made up of Properties
        // Get and Set Methods (a.k.a. Getter/Setters) used to access Private Fields
        // 
        // In Jave it looks like this:
        // public string GetMake() { return this.make; }
        //
        // Usually there is a Property for every Field you need access to
        // As a property: Should start with a Capital Letter, named the same as the Private Field
        // Purpose: Provide controlled access to a private field
        // Two options: Get by itself (Read only); use both Get and Set together (Read and Write)
        public string Make{get{return this.make;}}
        public string Model{get{return this.model;}}
        public int Year{get{return this.year;}}
        public int Mileage{get{return this.mileage;}}
        public decimal Price{get{return this.price;}}

    }
}
