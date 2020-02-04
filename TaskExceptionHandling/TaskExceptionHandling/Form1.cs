using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskExceptionHandling
{
    public partial class Form1 : Form
    {
        private delegate void SafeCallDelegate(string text, ListBox listBox);
        private delegate void SafeLabelDelegate(string text, Label label);
        public Form1()
        {
            InitializeComponent();
        }

        private void btnHandlingAttachedChildTaskExceptions_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            Task ParentTask = Task.Factory.StartNew(() =>
           {
               //   parent Task
               //   create an inner Task
               Task ChildTask1 = Task.Factory.StartNew(() =>
              {
                  //   Child Task1
                  while (true)
                  {
                      //    get a random value
                      int x = rand.Next(-999, 1000);
                      Thread.SpinWait(rand.Next(100_000_000, 300_000_000));
                      WriteTextSafe($"ChildTask1: x={ x }", listBox1);
                      if (x < -500 && x % 2 != 0)
                      {
                          WriteTextSafe($"ChildTask1 is throwing an Arithmetic Exception!", listBox1);
                          throw new ArithmeticException("ChildTask1 Error! Negative odd numbers are invalid");
                      }
                  }
              });
               Task ChildTask2 = Task.Factory.StartNew(() =>
               {
                   //   Child Task 2
                   while (true)
                   {
                       //    get a random value
                       int x = rand.Next(-999, 1000);
                       Thread.SpinWait(rand.Next(100_000_000, 300_000_000));
                       WriteTextSafe($"ChildTask1: x={ x }", listBox2);
                       if (x > 500 && x % 2 == 0)
                       {
                           WriteTextSafe($"ChildTask2 is throwing an Argument Exception!", listBox2);
                           throw new ArgumentException("ChildTask2 Error! Even numbers above 499 are invalid");
                       }
                   }
               });
               //  Add a Wait statement causing the Parent to wait for capturing the Aggregate Exception
               //  All Exceptions thrown from Child Task(s) are wrapped inside the AggregateException instance
               try
               {
                   //  wait on both children
                   //  You *could* childTask1.Wait(); childTask2.Wait(); ... etc
                   //  but preferred way is :
                   Task.WaitAll(ChildTask1, ChildTask2);
               }
               catch (AggregateException ae)
               {
                   //   Sequence through the innerExceptions of ae
                   foreach(Exception exception in ae.InnerExceptions)
                   {
                       //   Display the type and message of each innerException thrown by Child Tasks
                       WriteLabelSafe($"{ exception.GetType().Name }: { exception.Message }\n", label1);
                   }
               }
           });
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
        private void WriteLabelSafe(string text, Label label)
        {
            if (label.InvokeRequired)
            {
                var d = new SafeLabelDelegate(WriteLabelSafe);
                label.Invoke(d, new object[] { text, label });
            }
            else
            {
                label.Text += text;
            }
        }
    }
}
