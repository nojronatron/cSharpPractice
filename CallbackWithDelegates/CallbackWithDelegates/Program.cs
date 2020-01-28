using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallbackWithDelegates
{
    //  Note: Instead of using a separate Library, everything will be done here so the mechanics are easier to follow

    //  define a class that will make a callback
    public delegate void MyCallbackDelegate (string message, int value);

    public class Worker
    {
        //  this worker will process all the work given to it and will call you back if it encounters a problem
        public void Process(MyCallbackDelegate callback)    //  the argument here is the phone number by which the worker can call the App
        {
            //  processing
            //      simulate processing by making the worker spin for a few seconds
            //      display just to observe -- usually DON'T do this
            Console.WriteLine("worker is about to start processing...");
            System.Threading.Thread.SpinWait(100000000);

            //  create a random value
            int r = new Random().Next();
            if (r % 2 != 0)
            {
                //  call back the client
                //      but WHERE and HOW? The Library does not know
                //      Define a delegate type for the callback ^^^^^^^^
                callback("r is not even!", r);
            }
            else
            {
                callback("r is even!", r);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //  create a worker
            Worker worker1 = new Worker();

            //  ask worker1 to start the process
            //  pass a reference to the method where to receive call (callback)
            //  by creating a Delegate object of type MyCallbackDelegate
            MyCallbackDelegate callback = CallbackHandler;  //  assign the method to the callback delegate

            //  pass the callback delegate to the worker1
            worker1.Process(callback);  //  this actually tells the recipient what to call via the delegate99


            

            Console.Write("Press <Enter> to exit. . .");
            Console.ReadLine();
        }
        //  define a method in this app you want the Worker object to call
        //  method MUST have the same signature as the callback delegate
        static void CallbackHandler(string msg, int x)
        {
            //  The term 'handler' ^^^^^^ is usually used for Callback methods
            //  process information sent back from worker
            Console.WriteLine("==================================================");
            Console.WriteLine($"Message sent from worker: { msg }.");
            Console.WriteLine($"Value sent from worker: { x }.");
            Console.WriteLine("==================================================");
        }
    }
}
