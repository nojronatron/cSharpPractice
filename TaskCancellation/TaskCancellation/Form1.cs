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

namespace TaskCancellation
{
    public partial class Form1 : Form
    {
        //  declare a CancellationTokenSource object to the accessible to both buttons
        CancellationTokenSource cancellationTokenSource = null; //  just declare for accessibility by buttons; create it later

        private delegate void SafeCallDelegate(string text, ListBox listBox);

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
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStartTask_Click(object sender, EventArgs e)
        {
            //  Create cancellationTokenSource within a button so it's lifetime will be accessible to both buttons
            cancellationTokenSource = new CancellationTokenSource();
            //  start a task
            //  Task.Facotry.StartNew(Action, CancellationToken)
            Task task1 = Task.Factory.StartNew(() =>
            {
                Random rand = new Random();
                for(int i=0; i < 200; i++)
                {
                    //  here is where most of the work is being done so this is good candidate for CheckIfCancellation request
                    //  check if cancellation has been requested
                    if (cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        //  do some cleanup like close files, net connections, db connections, streams, ...
                        cancellationTokenSource.Token.ThrowIfCancellationRequested();
                    }
                    WriteTextSafe(rand.Next().ToString(), listBox1);
                    Thread.SpinWait(20_000_000);
                }
            }, cancellationTokenSource.Token);
        }

        private void btnCancelTask_Click(object sender, EventArgs e)
        {
            if(cancellationTokenSource != null)
            {
                //  request cancellation
                cancellationTokenSource.Cancel();
                WriteTextSafe("Operation cancelled.", listBox1);
            }
        }
    }
}
