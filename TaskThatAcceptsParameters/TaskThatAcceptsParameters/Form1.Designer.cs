namespace TaskThatAcceptsParameters
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnStartFibonacciTask = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartDisplaySumTask = new System.Windows.Forms.Button();
            this.btnStartDisplaySumRangeTask = new System.Windows.Forms.Button();
            this.btnStartSearchTask = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 29;
            this.listBox1.Location = new System.Drawing.Point(15, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(414, 700);
            this.listBox1.TabIndex = 0;
            // 
            // btnStartFibonacciTask
            // 
            this.btnStartFibonacciTask.Location = new System.Drawing.Point(15, 786);
            this.btnStartFibonacciTask.Name = "btnStartFibonacciTask";
            this.btnStartFibonacciTask.Size = new System.Drawing.Size(414, 70);
            this.btnStartFibonacciTask.TabIndex = 1;
            this.btnStartFibonacciTask.Text = "Start Fibonacci Task";
            this.btnStartFibonacciTask.UseVisualStyleBackColor = true;
            this.btnStartFibonacciTask.Click += new System.EventHandler(this.btnStartFibonacciTask_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnStartSearchTask);
            this.panel1.Controls.Add(this.btnStartDisplaySumRangeTask);
            this.panel1.Controls.Add(this.btnStartDisplaySumTask);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.btnStartFibonacciTask);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1223, 868);
            this.panel1.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(341, 730);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(88, 35);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 733);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter an integer from 1 to 50:";
            // 
            // btnStartDisplaySumTask
            // 
            this.btnStartDisplaySumTask.Location = new System.Drawing.Point(445, 786);
            this.btnStartDisplaySumTask.Name = "btnStartDisplaySumTask";
            this.btnStartDisplaySumTask.Size = new System.Drawing.Size(414, 70);
            this.btnStartDisplaySumTask.TabIndex = 4;
            this.btnStartDisplaySumTask.Text = "Start Display Sum Task";
            this.btnStartDisplaySumTask.UseVisualStyleBackColor = true;
            this.btnStartDisplaySumTask.Click += new System.EventHandler(this.btnStartDisplaySumTask_Click);
            // 
            // btnStartDisplaySumRangeTask
            // 
            this.btnStartDisplaySumRangeTask.Location = new System.Drawing.Point(445, 692);
            this.btnStartDisplaySumRangeTask.Name = "btnStartDisplaySumRangeTask";
            this.btnStartDisplaySumRangeTask.Size = new System.Drawing.Size(414, 70);
            this.btnStartDisplaySumRangeTask.TabIndex = 5;
            this.btnStartDisplaySumRangeTask.Text = "Start Display Sum Range Task";
            this.btnStartDisplaySumRangeTask.UseVisualStyleBackColor = true;
            this.btnStartDisplaySumRangeTask.Click += new System.EventHandler(this.btnStartDisplaySumRangeTask_Click);
            // 
            // btnStartSearchTask
            // 
            this.btnStartSearchTask.Location = new System.Drawing.Point(445, 599);
            this.btnStartSearchTask.Name = "btnStartSearchTask";
            this.btnStartSearchTask.Size = new System.Drawing.Size(414, 70);
            this.btnStartSearchTask.TabIndex = 6;
            this.btnStartSearchTask.Text = "Start Search Task";
            this.btnStartSearchTask.UseVisualStyleBackColor = true;
            this.btnStartSearchTask.Click += new System.EventHandler(this.btnStartSearchTask_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 903);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnStartFibonacciTask;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnStartDisplaySumTask;
        private System.Windows.Forms.Button btnStartDisplaySumRangeTask;
        private System.Windows.Forms.Button btnStartSearchTask;
    }
}

