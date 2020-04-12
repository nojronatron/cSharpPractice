using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace LateBindingApp
{
    class LateBindingApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Late Binding Chptr.15 *****");
            //  try to load a local copy of CarLibrary
            Assembly a = null;
            try
            {
                a = Assembly.Load("CarLibrary");
            }
            catch(FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.Message);
            }
            if(a != null)
            {
                CreateUsingLateBinding(a);
                InvokeMethodWithArgsUsingLateBinding(a);
            }
            Console.ReadLine();
        }
        static void CreateUsingLateBinding(Assembly asm)
        {
            try
            {
                //  get metadata for the minivan type
                Type miniVan = asm.GetType("CarLibrary.MiniVan");

                //  create a minivan instance on the fly
                Object obj = Activator.CreateInstance(miniVan);
                Console.WriteLine($"Created a { obj } using late binding!");

                //  get info for TurboBoost()
                MethodInfo mi = miniVan.GetMethod("TurboBoost");

                //  invoke method ('null' for no parameters)
                mi.Invoke(obj, null);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void InvokeMethodWithArgsUsingLateBinding(Assembly asm)
        {
            try
            {
                //  first get a metadata description of the sports car
                Type sport = asm.GetType("CarLibrary.SportsCar");

                //  now create the sports car
                object obj = Activator.CreateInstance(sport);

                //  invoke TurnOnRadio() with arguments
                MethodInfo mi = sport.GetMethod("TurnOnRadio");
                mi.Invoke(obj, new object[] { true, 2 });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
