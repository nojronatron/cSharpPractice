using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOverrides
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with System.Object *****\n");
            Person p1 = new Person();

            // use inherited members of System.Object
            Console.WriteLine($"ToString: {p1.ToString()}");
            Console.WriteLine($"Hash Code: {p1.GetHashCode()}");
            Console.WriteLine($"Type: {p1.GetType()}");

            // Make some other references to p1
            Person p2 = p1;
            object o = p2;

            // Are the references pointing to the same object in memory
            if (o.Equals(p1) && p2.Equals(o))
            {
                Console.WriteLine("Same instance!");
            }
            Console.WriteLine();

            // check Equals() member override
            Console.WriteLine($"p1.Equals(o): {p1.Equals(o)}");
            Console.WriteLine();
            Person p3 = new Person("Dood", "Man", 19);
            Console.WriteLine($"p3.Equals(o): {p3.Equals(o)}");
            Console.WriteLine();

            // created to check overridden ToString()
            Console.WriteLine(p1.ToString());
            Console.WriteLine(p3.ToString());
            Console.WriteLine();

            // Hashcodes
            Person hash1 = new Person("Billy", "Jean", 18);
            Console.WriteLine($"hash1.GetHashCode(): {hash1.GetHashCode()}");

            // Test Equals() and GetHashCode() overrides
            Person p11 = new Person("Homer", "Simpson", 50);
            Person p12 = new Person("Homer", "Simpson", 50);
            Console.WriteLine($"p11.ToString(): {p11.ToString()}");
            Console.WriteLine($"p12.ToString(): {p12.ToString()}");
            Console.WriteLine($"p11 = p12?: {p11.Equals(p12)}");
            Console.WriteLine($"Same hash codes?: {p11.GetHashCode() == p12.GetHashCode()}");
            p12.Age = 42;
            Console.WriteLine($"p11.ToString(): {p11.ToString()}");
            Console.WriteLine($"p12.ToString(): {p12.ToString()}");
            Console.WriteLine($"p11 = p12?: {p11.Equals(p12)}");
            Console.WriteLine($"Same hash codes?: {p11.GetHashCode() == p12.GetHashCode()}");

            // System.Object static Members
            Console.WriteLine();
            StaticMembersOfObject();

            
            Console.Write("\n\nPress <Enter> to exit. . .");
            Console.ReadLine();
        }
        static void StaticMembersOfObject()
        {
            // static members of System.Object
            Person p3 = new Person("Sally", "Jones", 4);
            Person p4 = new Person("Sally", "Jones", 4);
            Console.WriteLine($"P3 and P4 has same state: {object.Equals(p3, p4)}");
            Console.WriteLine($"P3 and P4 are pointing to same object: {object.ReferenceEquals(p3, p4)}");
        }
    }
}
