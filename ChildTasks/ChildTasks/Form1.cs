using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ChildTasks
{
    public partial class Form1 : Form
    {
        private delegate void SafeCallDelegate(string text, ListBox listBox);
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

        private void btnStartUnattachedChildTasks_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            Task ParentTask = Task.Factory.StartNew(() =>
           {
               WriteTextSafe($"ParentTask ID: { Task.CurrentId } has started.", listBox1);
               //   A Delegate in the form of a lambda expression
               //   Start a Child Task 
               Task ChildTask1 = Task.Factory.StartNew(() =>
               {
                   //   child task 1
                   for (int i = 1; i <= 10; i++)
                   {
                       WriteTextSafe($"ChildTask1 ID: { Task.CurrentId }\ti={ i }", listBox1);
                       Thread.SpinWait(rand.Next(50_000_000, 300_000_000));
                   }
               });
               //   Start a Child Task 
               Task ChildTask2 = Task.Factory.StartNew(() =>
               {
                   //   child task 2
                   for(int i=20; i <= 30; i++)
                   {
                       WriteTextSafe($"ChildTask2 ID: { Task.CurrentId }\ti={ i }", listBox1);
                       Thread.SpinWait(rand.Next(50_000_000, 300_000_000));
                   }
               });
               //   This is the PARENTTASK area
               WriteTextSafe($"ParentTask ID: { Task.CurrentId } is completing", listBox1);

           }).ContinueWith(task =>
           {
               //   parent doesn't have to wait for Children but this runs AFTER ParentTask exits
               if (task.IsCompleted) WriteTextSafe("Parent Task has completed.", listBox1);
           });
            //  DONT do a ParentTask.Wait() it will lock the UI Thread making entire app unresponsive
        }

        private void btnStartAttachedChildTasks_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            Task ParentTask = Task.Factory.StartNew(() =>
            {
                WriteTextSafe($"ParentTask ID: { Task.CurrentId } has started.", listBox2);
                //   A Delegate in the form of a lambda expression
                //   Start a Child Task 
                Task ChildTask1 = Task.Factory.StartNew(() =>
                {
                    //   child task 1
                    for (int i = 1; i <= 10; i++)
                    {
                        WriteTextSafe($"ChildTask1 ID: { Task.CurrentId }\ti={ i }", listBox2);
                        Thread.SpinWait(rand.Next(50_000_000, 300_000_000));
                    }
                }, TaskCreationOptions.AttachedToParent);
                //   Start a Child Task 
                Task ChildTask2 = Task.Factory.StartNew(() =>
                {
                    //   child task 2
                    for (int i = 20; i <= 30; i++)
                    {
                        WriteTextSafe($"ChildTask2 ID: { Task.CurrentId }\ti={ i }", listBox2);
                        Thread.SpinWait(rand.Next(50_000_000, 300_000_000));
                    }
                }, TaskCreationOptions.AttachedToParent);
                //   This is the PARENTTASK area
                WriteTextSafe($"ParentTask ID: { Task.CurrentId } is completing", listBox2);

            }).ContinueWith(task =>
            {
                //   parent doesn't have to wait for Children but this runs AFTER ParentTask exits
                if (task.IsCompleted) WriteTextSafe("Parent Task has completed.", listBox2);
            });
        }

        private void btnUnattachedChildTaskParentTaskWaitForResult_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            Task ParentTask = Task.Factory.StartNew(() =>
            {
                WriteTextSafe($"ParentTask ID: { Task.CurrentId } has started.", listBox1);
                //   A Delegate in the form of a lambda expression
                //   Start a Child Task 
                Task<double> ChildTask1 = Task<double>.Factory.StartNew(() =>
                {
                    //   child task 1
                    double total = 0;
                    for (int i = 1; i <= 10; i++)
                    {
                        int x = rand.Next(1000);
                        total += x;
                        WriteTextSafe($"ChildTask1 ID: { Task.CurrentId }\ti={ i }\tx={ x }", listBox1);
                        Thread.SpinWait(rand.Next(50_000_000, 300_000_000));
                    }
                    return total;   //  required in order for value to get passed to another Task
                });
                //   Start a Child Task 
                Task<double> ChildTask2 = Task<double>.Factory.StartNew(() =>
                {
                    //   child task 2
                    double total = 0;
                    for (int i = 20; i <= 30; i++)
                    {
                        int x = rand.Next(1000, 2000);
                        total += x;
                        WriteTextSafe($"ChildTask2 ID: { Task.CurrentId }\ti={ i }\tx={ x }", listBox1);
                        Thread.SpinWait(rand.Next(50_000_000, 300_000_000));
                    }
                    return total;   //  the PARENT will have to grab the ChildTasks' returns
                });
                //  parent add the two totals and display the overall total
                double childTotals = ChildTask1.Result + ChildTask2.Result; //  this forces a WAIT because property 'result' is blocking
                //   This is the PARENTTASK area
                WriteTextSafe($"ParentTask ID: { Task.CurrentId } completed and returned: { childTotals }", listBox2);
            }).ContinueWith(task =>
            {
                //   parent doesn't have to wait for Children but this runs AFTER ParentTask exits
                if (task.IsCompleted)
                {
                    WriteTextSafe("Parent Task has completed.", listBox1);
                }
            });

        }
    }
}
