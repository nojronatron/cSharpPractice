using System;

namespace CustomEnumerator
{
    class Car
    {
        //  constant for maximum speed
        public const int MAXSPEED = 100;

        //  car props
        public int CurrentSpeed { get; set; } = 0;
        public string PetName { get; set; } = "";

        //  is the car still operational?
        private bool carIsDead;

        //  a car has-a radio
        private Radio theMusicBox = new Radio();

        // constructors
        public Car() { }
        public Car(string name, int speed)
        {
            CurrentSpeed = speed;
            PetName = name;
        }

        public void CrankTunes(bool state)
        {
            //  delegate request to inner object
            theMusicBox.TurnOn(state);
        }

        //  see if car has overheated
        public void Accelerate(int delta)
        {   //  create and configure an exception if the user attempts to speed above MAXSPEED and send that exception back to the caller
            if (carIsDead)
            {
                Console.WriteLine($"{PetName} is out of order...");
            }
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed > MAXSPEED)
                {
                    //  Console.WriteLine($"{PetName} has overheated!");
                    CurrentSpeed = 0;
                    carIsDead = true;

                    //  use the throw keyword to raise an exception
                    //throw new Exception($"{PetName} has overheated!");  //   the executable will write the exception text to the default output/console

                    //  define the HelpLink
                    Exception ex = new Exception($"{PetName} has overheated!");
                    ex.HelpLink = "http://www.google.com";
                    //  custom data re: the error
                    ex.Data.Add("Timestamp", $"The car exploded at {DateTime.Now}");
                    ex.Data.Add("Cause", "You have a lead foot.");
                    throw ex;
                }
                else
                {
                    Console.WriteLine($"=> CurrentSpeed = {CurrentSpeed}");
                }
            }
        }
    }
}
