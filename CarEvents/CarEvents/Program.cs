﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Retrofit CarEvents using Lambda expressions
            Console.WriteLine("***** More Fun with Lambdas (and Events) *****");
            Car myCar = new Car("SlugBug", 100, 10);

            //  hook into events with Lambdas
            //  myCar.AboutToBlow += CarIsAlmostDoomed;
            myCar.AboutToBlow += (sender, e) => { Console.WriteLine(e.msg); };
            //  myCar.AboutToBlow += CarAboutToBlow;
            myCar.Exploded += (sender, e) => { Console.WriteLine(e.msg); };

            ////  attach/register with an event with +=
            //EventHandler<CarEventArgs> dead = new EventHandler<CarEventArgs>(CarExploded);
            //myCar.Exploded += dead; //  registering CarEngineHandler 'dead' with the event

            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i <= 6; i++)
            {
                myCar.Accelerate(20);
            }

            ////  detach from a source of events with -=
            //myCar.Exploded -= dead;

            //Console.WriteLine("\n***** Speeding up *****");
            //for (int i=0; i<6; i++)
            //{
            //    myCar.Accelerate(20);
            //}

            ////  add it back and see what happens
            //myCar.Exploded += dead;

            //Console.WriteLine("\n***** Speeding up *****");
            //for (int i = 0; i <= 6; i++)
            //{
            //    myCar.Accelerate(20);
            //}


            Console.WriteLine("\nPress <Enter> to exit. . .");
            Console.ReadLine();
        }
        //  create static methods for the caller
        //public static void CarAboutToBlow(object sender, CarEventArgs e)
        //{
        //    //  updated to support Custom Event Arguments
        //    if (sender is Car c)
        //    {
        //        Console.WriteLine($"Critical Message from { c.PetName }: { e.msg }.");
        //    }
        //}
        //public static void CarIsAlmostDoomed(object sender, CarEventArgs e)
        //{
        //    if (sender is Car c)
        //    {
        //        Console.WriteLine($"Warning Message from { c.PetName }: { e.msg }.");
        //    }
        //}
        //public static void CarExploded(object sender, CarEventArgs e)
        //{
        //    if (sender is Car c)
        //    {
        //        Console.WriteLine($"Error Message from { c.PetName }: { e.msg }.");
        //    }
        //}
    }
}
