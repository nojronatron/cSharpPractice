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
            }
            Console.ReadLine();
        }
        static void CreateUsingLateBinding(Assembly asm)
        {
            try
            {
                //  get metadata for the minivan type
                Type miniVan = asm.GetType("CarLibrary.MiniVan");

                //  create a minivan instance on teh fly
                Object obj = Activator.CreateInstance(miniVan);
                Console.WriteLine($"Created a { obj } using late binding!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
