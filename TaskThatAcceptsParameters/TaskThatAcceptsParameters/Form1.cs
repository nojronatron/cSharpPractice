using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TaskThatAcceptsParameters
{
    public delegate void SafeCallDelegate(string text, ListBox listBox);
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void WriteTextSafe(string text, ListBox listBox)
        {
            if (listBox.InvokeRequired)
            {
                var d = new SafeCallDelegate(WriteTextSafe);
                listBox.Invoke(d, new object[] { text, listBox });   //  can use 'this' instead of 'listBox'
            }
            else
            {
                listBox.Items.Add(text);
            }
        }

        private void btnStartFibonacciTask_Click(object sender, EventArgs e)
        {
            //  public Task (Action<object> action, object state);
            //  or
            //  public Task StartNew (Action<object> action, object state);
            //  object state: The data that is passed to the Action delegate
            //  example: Task<TResult>(Func<Object,TResult>, Object)

            int n = int.Parse(textBox1.Text);
            Task.Factory.StartNew(() =>
            {   //  by using a lambda you gain the ability to pass-in arguments directly to the Action
                //      also the lambda *IS* a delegate so it matches as a value parameter to StartNew()
                //  ...any variable declared inside this button is visible to the lambda expression
                //  StartNew() does not return anything. to make it return a value then do StartNew<T>()
                int result = Fibonacci(n);
                WriteTextSafe($"Fibonacci({ n }) = { result }.", listBox1);
            });
        }

        //  fibonacci method
        private int Fibonacci(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (n == 0 || n == 1)
            {
                return n;
            }
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        private void DisplaySumOfRandoms(object value) //int maxRandomValue)
        {
            //  case object to an int - knowing that your code will supply an int in the param
            int maxRandomValue = (int)value;
            double sum = 0;
            Random rand = new Random();
            for (int i = 1; i <= 200; i++)
            {
                int x = rand.Next(maxRandomValue);
                sum += x;
                WriteTextSafe($"x = { x }  Sum = { sum }", listBox1);
                //  slow down this work
                Thread.SpinWait(50_000_000);
            }
            WriteTextSafe($"Sum = { sum }", listBox1);
        }

        private void btnStartDisplaySumTask_Click(object sender, EventArgs e)
        {
            //  Example 1
            Action<object> action = DisplaySumOfRandoms;
            int value = 500;
            Task.Factory.StartNew(action, value);

        }
        public void DisplaySumOfRange(object value)
        {
            Tuple<int, int> tuple = (Tuple<int, int>)value;
            int value1 = tuple.Item1;
            int value2 = tuple.Item2;
            double sum = 0;
            for (int x = value1; x <= value2; x++)
            {
                sum += x;
                x++;
                WriteTextSafe($"x = { x }  Sum = { sum }", listBox1);
                Thread.SpinWait(50_000_000);
            }
        }

        private void btnStartDisplaySumRangeTask_Click(object sender, EventArgs e)
        {
            //  Example 2
            Tuple<int, int> tuple = new Tuple<int, int>(10_000, 50_000);
            Action<object> action = DisplaySumOfRange;
            Task.Factory.StartNew(action, tuple);

        }

        private void btnStartSearchTask_Click(object sender, EventArgs e)
        {
            //  example 3
            //  create an start a task that passes as array and an int value to search
            Random rand = new Random();
            int[] array = new int[1000];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(-999, 1000);
            }
            //  get the value you want to search for
            int userValue = int.Parse(textBox1.Text);

            //  set up and start the task
            Action<object, int> action = Search;
            //Task.Factory.StartNew(action, array, userValue);    //  instructor used a tuple to limit to two params
            Tuple<object, int> tuple = new Tuple<object, int>(action, userValue)
        }
        //  define a method that takes an array and an int value and searches
        public void Search(object obj, int searchTerm)
        {
            //  return nothing but display the index of the item that was found
            //  if not found return -1
            //List<int> intList = new List<int>;
            IEnumerable<int> ie = (IEnumerable<int>)obj;
            List<int> intList = ie.ToList();
            if (intList.Count < 1)
            {
                WriteTextSafe($"The list was empty.", listBox1);
            }
            else
            {
                int srchtrm = 0;
                int result = -1;
                for (int index = 0; index <= intList.Count; index++)
                {
                    if (intList[index] == srchtrm)
                    {
                        result = index;
                        break;
                    }
                }
                WriteTextSafe($"The list was empty.", listBox1);
            }
        }
    }
}
