using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEvents_AnonymousMethod
{
    public class Car
    {
        //  this car can send these events
        public event EventHandler<CarEventArgs> Exploded;
        public event EventHandler<CarEventArgs> AboutToBlow;

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

        public void Accelerate(int delta)
        {
            if (carIsDead)
            {
                //  if this car is dead send dead message
                Exploded?.Invoke(this, new CarEventArgs("Sorry, this car is dead..."));
            }
            //  is this car almost dead
            else if (10 == MaxSpeed - CurrentSpeed)
            {
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
