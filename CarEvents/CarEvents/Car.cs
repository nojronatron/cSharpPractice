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
        //public delegate void CarEngineHandler(string msg);    //  commented out for leveraging CarEventArgs class
        public delegate void CarEngineHandler(object sender, CarEventArgs e);

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
            carIsDead = false;
        }

        //  implement the Accelerate() method to invoke the delegate's invocation list under the correct circumstances
        public void Accelerate(int delta)
        {
            if (carIsDead)
            {
                //  if this car is dead send dead message
                //Exploded?.Invoke("Sorry, this car is dead."); //  use Custom Event Args instead
                Exploded?.Invoke(this, new CarEventArgs("Sorry, this car is dead..."));
            }
            //  is this car almost dead
            else if (10 == MaxSpeed - CurrentSpeed)
            {
                //AboutToBlow?.Invoke("Careful buddy! Gonna blow!");    //  use Custom Event Args instead
                AboutToBlow?.Invoke(this, new CarEventArgs("Careful buddy! Gonna blow!"));
            }
            else if (CurrentSpeed >= MaxSpeed)
            {
                carIsDead = true;
            }
            else
            {
                Console.WriteLine($"Current Speed = { CurrentSpeed }.");
            }
            CurrentSpeed += delta;
        }
    }
}
