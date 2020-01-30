using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TasksWithWindowsForms
{
    public partial class Form1 : Form
    {
        private delegate void SafeCallDelegate(string text, ListBox listBox);

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStartTasks_Click(object sender, EventArgs e)
        {
            //  Task(Action)
            Task task1 = Task.Factory.StartNew(() =>
            {
                Random rand = new Random();
                for (int i = 1; i <= 200; i++)
                {
                    int x = rand.Next();
                    if (x % 3 == 0)
                    {
                        //  if x is divisible by 3 then display it
                        //  listBox1.Items.Add(x);  //  directly display to a listbox
                        //  *** this will cause a cross thread operation 
                        //  replace with thread-safe method
                        WriteTextSafe(x.ToString(), listBox1);
                        //  simulate a long process
                    }
                    //  create a 2nd task that display divisibles by 7 to listBox2
                    if (x % 7 == 0)
                    {
                        WriteTextSafe(x.ToString(), listBox2);
                    }
                    Thread.SpinWait(20000000);  //  hog the cpu for a little bit
                }
            });
        }
        //  thread safe method
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

        private void btnStartTaskWithTResult_Click(object sender, EventArgs e)
        {
            //  use Task<TResult> for methods or lambda expressions that return a vlue
            Task<double> task1 = Task<double>.Factory.StartNew(() =>
           {
               //   a msg to indicate this has started
               WriteTextSafe("task1 has just started, returning average", listBox3);
               Random rand = new Random();
               double total = 0;
               for (int i = 1; i <= 200; i++)
               {
                   total += rand.Next();
                   Thread.SpinWait(2000000);
               }
               double avg = total / 200;
               return avg;  //  Task<double> REQUIRES returning a value of type double
           });
            //  to capture the return value from a Task<TResult> a query to the Result
            //  property is required
            listBox3.Items.Add("Waiting for results to return from task1...");
            //double average = task1.Result;  //  this BLOCKS the thread stopping other Tasks
            //listBox3.Items.Add($"Average value: { average }");
        }

        private void btnStartTaskWithTResultNonBlocking_Click(object sender, EventArgs e)
        {
            Task<double> task1 = Task<double>.Factory.StartNew(() =>
            {
                //   a msg to indicate this has started
                WriteTextSafe("task1 has just started, returning average", listBox3);
                Random rand = new Random();
                double total = 0;
                for (int i = 1; i <= 200; i++)
                {
                    total += rand.Next();
                    Thread.SpinWait(20000000);
                }
                double avg = total / 200;
                return avg;  //  Task<double> REQUIRES returning a value of type double
            });
            //  start 2nd Task to Wait and Query the results from Task1
            //  Task2 should start when Task1 completes its operation
            Task task2 = task1.ContinueWith(task =>
            {
                //  the code here (task2) will start when task1 completes
                //  the argument, 'task', is a REF to Task task1 (above)
                //  results from task1 can be accessed via the task REF
                double average = task.Result;
                //  display without using xtra method like WriteSafe()
                //  synch scheduler will take care of safe-thread usage
                listBox3.Items.Add($"Average value: {average:f5}");
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void btnChainingTasks_Click(object sender, EventArgs e)
        {
            //  chaining tasks with CountinueWith
            Task<int>.Factory.StartNew(() =>
           {
               WriteTextSafe("First task has just started", listBox3);
               Thread.SpinWait(200_000_000);
               int x = new Random().Next();
               return x;
           }).ContinueWith<int>(task =>
           {
               WriteTextSafe("Second task has just started", listBox3);
               Thread.SpinWait(200_000_000);
               int x = new Random().Next();
               int value1 = task.Result;
               return x + value1;
           }).ContinueWith(task =>
           {
               WriteTextSafe("Third task has just started", listBox3);
               Thread.SpinWait(200_000_000);
               //  get result return value from previous tasks
               int result = task.Result;
               WriteTextSafe($"Overall result: {result}", listBox3);
           });
        }
    }
}
