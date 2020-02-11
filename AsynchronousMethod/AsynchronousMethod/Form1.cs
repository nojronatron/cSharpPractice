using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsynchronousMethod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void BtnRunAsyncMethodReturnsValue_Click(object sender, EventArgs e)
        {
            double result = await AsyncDoWorkWithReturn();
            listBox1.Items.Add($"AsyncDoWorkWithReturn result: { result }");
        }
        private async Task<double> AsyncDoWorkWithReturn()
        {
            Task<double> task3 = Task<double>.Factory.StartNew(() =>
            {
                Random rand = new Random();
                int numOfCycles = 100_000_000;
                //  Compute the average value of the generated random values
                double total = 0;
                for (int i = 1; i <= numOfCycles; i++)
                {
                    total += rand.Next(-10_000_000, 10_000_000);
                }
                //  average
                double average = total / numOfCycles;
                return average;
            });
            //  task caller must have an await PRIOR to calling task.result else it blocks
            return task3.Result;
        }
        private void btnCheckIfUiLocked_Click(object sender, EventArgs e)
        {
            //  increment the count in the label
            //  read the current value, increment it, then put it back
            int counter = int.Parse(label1.Text);
            counter++;
            label1.Text = counter.ToString();
        }

        private void btnRunMethodOnUiThread_Click(object sender, EventArgs e)
        {
            //  call the DoWork method in the UI Thread
            //  ...demonstrating the Thread gets blocked until DoWork() method is done
            DoWork();
        }
        private void DoWork()
        {
            //  This method will have no task so it will run in the UI thread
            //  If this method takes a long time to run it will block other button
            //  from responding to events
            Random rand = new Random();
            int numOfCycles = 700_000_000;
            //  Compute the average value of the generated random values
            double total = 0;
            for(int i=1; i<=numOfCycles; i++)
            {
                total += rand.Next(-10_000_000, 10_000_000);
            }
            //  average
            double average = total / numOfCycles;
            //  display result
            listBox1.Items.Add($"Average Value: { average:f5}");
        }

        private async void btnRunAsyncMethod_Click(object sender, EventArgs e)
        {
            //  ONLY the eventhandlers do NOT require a Action<T> but will allow a void
            await DoWorkAsync();
        }
        private async Task DoWorkAsync()
        {
            //  Seperate DISPLAY from the WORK portion of the method
            //  Use Task and a Lambda expression to put the busy portion of DoWork onto a separate thread
            Random rand = new Random();
            int numOfCycles = 700_000_000;
            double total = 0;

            Task task1 = Task.Factory.StartNew(() =>
            {
                for (int i = 1; i <= numOfCycles; i++)
                {
                    total += rand.Next(-10_000_000, 10_000_000);
                }
            });
            //  task1.Wait();  <<== this WILL lock up the UI
            await task1;    //  await is NOT a method it is a keyword that acts like a bookmark
            //  The METHOD that has keyword await MUST be marked with keyword async
            double average = total / numOfCycles;
            listBox1.Items.Add($"Average Value: { average:f5}");
        }

        private void btnWriteFile_Click(object sender, EventArgs e)
        {
            //  helper method button to write a series of random number to a file
            Random rand = new Random();
            string filename = @"numbers.txt";
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            StreamWriter streamWriter = File.AppendText(filename);
            int count = 10_000;
            for(int i=1; i<= count; i++)
            {
                //streamWriter.WriteAsync(rand.Next(-100_000, 100_000).ToString());
                streamWriter.WriteLine(rand.Next(-100_000, 100_000));
            }
            streamWriter.Close();
        }

        private async void BtnAsyncDoSomethingElse(object sender, EventArgs e)
        {
            await DoSomethingElseAsync();
        }
        private async Task DoSomethingElseAsync()
        {
            //  alternate way to write an async-await Task Method()
            await Task.Factory.StartNew(() =>
            {
                Thread.SpinWait(1_000_000);
            });
            //  if NOT using the await reference above, it would need to be added here
            listBox1.Items.Add("DoSomethingElseAsync completed.");
        }

        private async void btnAsyncReadFile_Click(object sender, EventArgs e)
        {
            await FileReaderAsync();
        }
        private async Task FileReaderAsync()
        {
            string filename = @"numbers.txt";
            StreamReader streamReader = File.OpenText(filename);
            double total = 0;
            int counter = 0;
            Task task2 = Task.Factory.StartNew(() =>
            {
                while (!streamReader.EndOfStream)
                {
                    int x = int.Parse(streamReader.ReadLine());
                    if (x >= 0)
                    {
                        total += x;
                        counter++;
                    }
                    Thread.SpinWait(100_000);
                }
                streamReader.Close();
            });
            await task2;
            double average = total / counter;
            listBox1.Items.Add($"Average Even File Values: { average:f5}");
        }

    }
}
