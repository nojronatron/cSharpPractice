using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEvents
{
    public class Car
    {
        //  this Delegate works in conjunction with the Car's events
        public delegate void CarEngineHandler(string msg);

        //  this car can send these events
        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;


        //  internal state data
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; } = 100;
        public string PetName { get; set; }
        //  is the car alive or dead
        private bool carIsDead;
        //  ctors
        public Car() { }
        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }
        //  define a delegate type
        //public delegate void CarEngineHandler(string msgForCaller);
        //  define a member variable of this delegate
        //private CarEngineHandler listOfHandlers;
        //  add registration function for the caller
        //public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        //{
        //    listOfHandlers = methodToCall;
        //}
        //  implement the Accelerate() method to invoke the delegate's invocation list under the correct circumstances
        public void Accelerate(int delta)
        {
            //  if this car is dead send dead message
            if (carIsDead)
            {
                //  if (listOfHandlers != null) //   if listOfHandlers is null then nullReferenceException - so must Register Handlers
                if (Exploded != null)
                {
                    //  listOfHandlers("Sorry, this car is dead.");
                    Exploded("Sorry, this car is dead.");
                }
            }
            else
            {
                CurrentSpeed += delta;
                //  is this car almost dead
                //  if (15 >= (MaxSpeed - CurrentSpeed) && listOfHandlers != null)
                if (10 == MaxSpeed - CurrentSpeed && AboutToBlow != null)
                {
                    //listOfHandlers("Careful buddy the engine is gonna blow!");
                    AboutToBlow("Careful buddy! Gonna blow!");
                }
                if (CurrentSpeed >= MaxSpeed)
                {
                    carIsDead = true;
                }
                else
                {
                    Console.WriteLine($"Current Speed = { CurrentSpeed }.");
                }
            }
        }
    }
}
