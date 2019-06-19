using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceNameClash
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Interface Name Clashes *****");
            // All of these invocations call the same Draw() method!

            Octogon oct = new Octogon();
            IDrawToForm itfForm = (IDrawToForm)oct;
            itfForm.Draw();

            // shorthand notation if variable not needed afterward
            ((IDrawToPrinter)oct).Draw();

            // can also use the "is" keyword
            if (oct is IDrawToMemory dtm) dtm.Draw();
            

            Console.ReadLine();
        }
    }
    public interface IDrawToForm
    {
        void Draw();
    }
    public interface IDrawToMemory
    {
        void Draw();
    }
    public interface IDrawToPrinter
    {
        void Draw();
    }
    class Octogon : IDrawToForm, IDrawToMemory, IDrawToPrinter
    {
        //public void Draw()
        //{
        //    // Shared drawing logic
        //    Console.WriteLine("Drawing the Octagon...");
        //}

        // Explicitly bind Draw() implementations to a given interface
        //     Explicit Casting will be required to access the required functionality
        void IDrawToForm.Draw() // access modifier no longer allowed; explicitly implemented members are automatically private
        {
            Console.WriteLine("Drawing the Octagon...to FORM.");
        }
        void IDrawToMemory.Draw()
        {
            Console.WriteLine("Drawing the Octagon...to MEMORY.");
        }
        void IDrawToPrinter.Draw()
        {
            Console.WriteLine("Drawing the Octagon...to PRINTER.");
        }
    }
}
