using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //clear screen
                Console.Clear();
                //display menu
                Menu();
                //get user selection
                int selection;
                Console.Write("\n\t\tEnter your selection: ");
                int.TryParse(Console.ReadLine(), out selection);

                switch (selection)
                {
                    case 1:
                        {
                            try
                            {
                                Console.Write("Enter first integer: ");
                                int x = int.Parse(Console.ReadLine()); // possible problems: Out of range; or not digits
                                Console.Write("\nEnter second integer: ");
                                int y = int.Parse(Console.ReadLine());
                                int result = x / y; // possible problem: divide by zero; over/underflow
                                Console.WriteLine($"{x} / {y} = {result}.");
                            }
                            catch (FormatException fe)
                            {
                                Console.WriteLine(fe.Message);
                            }
                            catch (OverflowException oe)
                            {
                                Console.WriteLine(oe.Message);
                            }
                            catch (Exception ex) // this will catch all Exception classes
                            {
                                Console.WriteLine($"Something went wrong ==>>\n{ex.Message}");
                            }
                        }
                        break;

                    case 2:
                        {
                            try
                            {
                                Console.Write("Enter a positive integer: ");
                                int x = int.Parse(Console.ReadLine()); // possible problems: sqare of a negative number
                                if (x < 0)
                                {
                                    //Console.WriteLine("Throw an exception here.");
                                    NegativeNumberException nne = new NegativeNumberException();
                                    throw nne;
                                }
                                else
                                {
                                    double result = Math.Sqrt(x); // possible problem: divide by zero; over/underflow
                                    Console.WriteLine($"Math.Sqrt{x} = {result}.");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"{ex.Message}");
                            }
                        }
                        break;

                    case 3:
                        {
                            // define a method that throws the OddNumberException
                            // the method is to divide the number by 2 and return the result
                            // or throw the OddNumberException if the input parameter is odd
                            // get user input. call the method. display result.
                            try
                            {
                                {
                                    Console.Write("Input an even number: ");
                                    int x = int.Parse(Console.ReadLine());
                                    if (x % 2 != 0)
                                    {
                                        Console.WriteLine("Throw an error.");
                                        OddNumberException one = new OddNumberException();
                                        throw one;
                                    }
                                    else
                                    {
                                        int result = DivideByTwo(x);
                                        Console.Write($"The solution is: {result}");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"{ex.Message}");
                            }
                        }
                        break; //do NOT add the break within the Try/Catch

                    case 4:
                        // call a method that calls another method, each with their own single arg values
                        // Method 1 throws an Exception and calls Method 2 which throws another Exception
                        {
                            try
                            {
                                Console.Write("Input an even number: ");
                                int x = int.Parse(Console.ReadLine());
                                double result = method1(x);
                            }
                            catch(NegativeNumberException nne)
                            {
                                Console.WriteLine($"\n{nne.GetType().Name}: {nne.Message}");
                                if(nne.InnerException != null)
                                {
                                    Exception innerException = nne.InnerException;
                                    Console.WriteLine($"{innerException.GetType().Name}: {innerException.Message}");
                                }
                            }
                        }
                        break; 

                    case 5:
                        { }
                        break;

                    case 9://exit
                        return;
                }
                //pause for the results
                Console.Write("\n\nHit <Enter> to continue");
                Console.ReadLine();
            }
        }
        static double method1(int x)
        {
            try
            {
                double result1 = method2(x);
                return result1;
            }
            catch (OddNumberException oddex)
            {
                if (x < 0)
                {
                    NegativeNumberException nne = new NegativeNumberException("negative input value", oddex);
                    throw nne;
                }
                return 0; // force method to return something
            }
        }
        static double method2(int y)
        {
            if (y % 2 != 0)
            {
                Console.WriteLine("Throw an error.");
                // OddNumberException one = new OddNumberException();
                // throw one;
                throw new OddNumberException("Processes even integer numbers only!");
            }
            else
            {
                int result = DivideByTwo(y);
                Console.Write($"The solution is: {result}");
                return result;
            }
        }
        static void Menu()
        {
            Console.WriteLine("\n Menu:");
            Console.WriteLine("\t1. Catching .Net DivideByZeroException");
            Console.WriteLine("\t2. Catching .Net OverflowException");
            Console.WriteLine("\t3. Catching .Net ArithmeticException");
            //custom Exception
            Console.WriteLine("\t4. Catching. Custom NegativeValueException");

            //InnerException property
            Console.WriteLine("\t5. Catching .Net OverflowException");

            //exit
            Console.WriteLine("\t9. Exit");
        }
        static int DivideByTwo(int x)
        {
            return x / 2;
        }
    }
}
