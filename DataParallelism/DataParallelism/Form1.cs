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

namespace DataParallelism
{
    delegate void SafeCallDelegate(string text, ListBox listBox);
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInvoke_Click(object sender, EventArgs e)
        {   //  Action1, Action2, Action3 in lambda expressions - each runs in a seperate task
            Parallel.Invoke(
                () =>
                {
                    for (int i = 0; i <= 10; i++)
                    {
                        WriteTextSafe($"action1 ==>> taskId: { Task.CurrentId } \ti={ i }\tthreadId: { Thread.CurrentThread.ManagedThreadId }", listBox1);
                        //Thread.SpinWait(20_000_000);
                    }
                },
                () =>
                {
                    for (int i = 100; i <= 110; i++)
                    {
                        WriteTextSafe($"action2 ==>> taskId: { Task.CurrentId } \ti={ i }\tthreadId: { Thread.CurrentThread.ManagedThreadId }", listBox2);
                        //Thread.SpinWait(20_000_000);
                    }
                },
                () =>
                {
                    for (int i = 200; i <= 210; i++)
                    {
                        WriteTextSafe($"action3 ==>> taskId: { Task.CurrentId } \ti={ i }\tthreadId: { Thread.CurrentThread.ManagedThreadId }", listBox1);
                        //Thread.SpinWait(20_000_000);
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

        private void btnParallelForLoop_Click(object sender, EventArgs e)
        {
            //  NOTE: Instructor ran this in Console - NOT GUI!
            //  normal for loop
            for (int i = 0; i <= 20; i++)
            {
                WriteTextSafe($"Standard For Loop Task ==>> taskId: { Task.CurrentId } \ti={ i }\tthreadId: { Thread.CurrentThread.ManagedThreadId }", listBox1);
                Thread.SpinWait(10_000_000);
            }

            //  NOTE: Instructor ran this in Console - NOT GUI!
            //  EVERY iteration of the FOR loop runs in its own thread and all cycles are independant of each other
            Parallel.For(0, 20, i =>
            {
                WriteTextSafe($"Parallel For Loop Task ==>> taskId: { Task.CurrentId } \ti={ i }\tthreadId: { Thread.CurrentThread.ManagedThreadId }", listBox1);
                Thread.SpinWait(10_000_000);
            });

            //  NOTE: instructor ran this in Console - NOT GUI!

        }
        static double SumRoot(int root)
        {
            double result = 0;
            for(int i=0; i<10_000_000; i++)
            {
                result += Math.Exp(Math.Log(i)) / root;
            }
            return result;
        }
    }
}
