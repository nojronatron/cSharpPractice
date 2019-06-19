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

            IDrawToPrinter itfPrinter = (IDrawToPrinter)oct;
            itfPrinter.Draw();

            IDrawToMemory itfMemory = (IDrawToMemory)oct;
            itfMemory.Draw();


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
        public void Draw()
        {
            // Shared drawing logic
            Console.WriteLine("Drawing the Octagon...");
        }
    }
}
