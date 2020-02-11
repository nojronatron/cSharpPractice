namespace DataParallelism
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.btnInvoke = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnParallelForLoop = new System.Windows.Forms.Button();
            this.btnParallelForEachLoop = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnParallelForEachLoop);
            this.panel1.Controls.Add(this.btnParallelForLoop);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnInvoke);
            this.panel1.Controls.Add(this.listBox2);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1101, 759);
            this.panel1.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 29;
            this.listBox1.Location = new System.Drawing.Point(15, 15);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(322, 613);
            this.listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 29;
            this.listBox2.Location = new System.Drawing.Point(362, 15);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(313, 613);
            this.listBox2.TabIndex = 1;
            // 
            // btnInvoke
            // 
            this.btnInvoke.Location = new System.Drawing.Point(15, 690);
            this.btnInvoke.Name = "btnInvoke";
            this.btnInvoke.Size = new System.Drawing.Size(322, 47);
            this.btnInvoke.TabIndex = 2;
            this.btnInvoke.Text = "Invoke";
            this.btnInvoke.UseVisualStyleBackColor = true;
            this.btnInvoke.Click += new System.EventHandler(this.btnInvoke_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(733, 439);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1label1label1label1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(927, 506);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 35);
            this.textBox1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(362, 690);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(313, 47);
            this.button2.TabIndex = 6;
            this.button2.Text = "Parallel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnParallelForLoop
            // 
            this.btnParallelForLoop.Location = new System.Drawing.Point(686, 632);
            this.btnParallelForLoop.Name = "btnParallelForLoop";
            this.btnParallelForLoop.Size = new System.Drawing.Size(313, 47);
            this.btnParallelForLoop.TabIndex = 7;
            this.btnParallelForLoop.Text = "ParallelForLoop";
            this.btnParallelForLoop.UseVisualStyleBackColor = true;
            this.btnParallelForLoop.Click += new System.EventHandler(this.btnParallelForLoop_Click);
            // 
            // btnParallelForEachLoop
            // 
            this.btnParallelForEachLoop.Location = new System.Drawing.Point(686, 690);
            this.btnParallelForEachLoop.Name = "btnParallelForEachLoop";
            this.btnParallelForEachLoop.Size = new System.Drawing.Size(313, 47);
            this.btnParallelForEachLoop.TabIndex = 8;
            this.btnParallelForEachLoop.Text = "ParallelForEachLoop";
            this.btnParallelForEachLoop.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 784);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInvoke;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnParallelForEachLoop;
        private System.Windows.Forms.Button btnParallelForLoop;
    }
}

