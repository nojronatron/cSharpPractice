namespace AsynchronousMethod
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
            this.btnRunMethodOnUiThread = new System.Windows.Forms.Button();
            this.btnCheckIfUiLocked = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAsyncReadFile = new System.Windows.Forms.Button();
            this.BtnDoSomethingElseAsync = new System.Windows.Forms.Button();
            this.btnWriteFile = new System.Windows.Forms.Button();
            this.btnRunAsyncMethod = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.BtnRunAsyncMethodReturnsValue = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRunMethodOnUiThread
            // 
            this.btnRunMethodOnUiThread.Location = new System.Drawing.Point(10, 596);
            this.btnRunMethodOnUiThread.Name = "btnRunMethodOnUiThread";
            this.btnRunMethodOnUiThread.Size = new System.Drawing.Size(418, 48);
            this.btnRunMethodOnUiThread.TabIndex = 0;
            this.btnRunMethodOnUiThread.Text = "Run Method on UI Thread";
            this.btnRunMethodOnUiThread.UseVisualStyleBackColor = true;
            this.btnRunMethodOnUiThread.Click += new System.EventHandler(this.btnRunMethodOnUiThread_Click);
            // 
            // btnCheckIfUiLocked
            // 
            this.btnCheckIfUiLocked.Location = new System.Drawing.Point(10, 767);
            this.btnCheckIfUiLocked.Name = "btnCheckIfUiLocked";
            this.btnCheckIfUiLocked.Size = new System.Drawing.Size(310, 48);
            this.btnCheckIfUiLocked.TabIndex = 1;
            this.btnCheckIfUiLocked.Text = "Check If UI Locked";
            this.btnCheckIfUiLocked.UseVisualStyleBackColor = true;
            this.btnCheckIfUiLocked.Click += new System.EventHandler(this.btnCheckIfUiLocked_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnRunAsyncMethodReturnsValue);
            this.panel1.Controls.Add(this.btnAsyncReadFile);
            this.panel1.Controls.Add(this.BtnDoSomethingElseAsync);
            this.panel1.Controls.Add(this.btnWriteFile);
            this.panel1.Controls.Add(this.btnRunAsyncMethod);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.btnCheckIfUiLocked);
            this.panel1.Controls.Add(this.btnRunMethodOnUiThread);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(863, 828);
            this.panel1.TabIndex = 2;
            // 
            // btnAsyncReadFile
            // 
            this.btnAsyncReadFile.Location = new System.Drawing.Point(434, 650);
            this.btnAsyncReadFile.Name = "btnAsyncReadFile";
            this.btnAsyncReadFile.Size = new System.Drawing.Size(418, 48);
            this.btnAsyncReadFile.TabIndex = 7;
            this.btnAsyncReadFile.Text = "Read Async From A File";
            this.btnAsyncReadFile.UseVisualStyleBackColor = true;
            this.btnAsyncReadFile.Click += new System.EventHandler(this.btnAsyncReadFile_Click);
            // 
            // BtnDoSomethingElseAsync
            // 
            this.BtnDoSomethingElseAsync.Location = new System.Drawing.Point(10, 704);
            this.BtnDoSomethingElseAsync.Name = "BtnDoSomethingElseAsync";
            this.BtnDoSomethingElseAsync.Size = new System.Drawing.Size(418, 48);
            this.BtnDoSomethingElseAsync.TabIndex = 6;
            this.BtnDoSomethingElseAsync.Text = "Do Something Else Async";
            this.BtnDoSomethingElseAsync.UseVisualStyleBackColor = true;
            this.BtnDoSomethingElseAsync.Click += new System.EventHandler(this.BtnAsyncDoSomethingElse);
            // 
            // btnWriteFile
            // 
            this.btnWriteFile.Location = new System.Drawing.Point(434, 596);
            this.btnWriteFile.Name = "btnWriteFile";
            this.btnWriteFile.Size = new System.Drawing.Size(418, 48);
            this.btnWriteFile.TabIndex = 5;
            this.btnWriteFile.Text = "Write To A File";
            this.btnWriteFile.UseVisualStyleBackColor = true;
            this.btnWriteFile.Click += new System.EventHandler(this.btnWriteFile_Click);
            // 
            // btnRunAsyncMethod
            // 
            this.btnRunAsyncMethod.Location = new System.Drawing.Point(10, 650);
            this.btnRunAsyncMethod.Name = "btnRunAsyncMethod";
            this.btnRunAsyncMethod.Size = new System.Drawing.Size(418, 48);
            this.btnRunAsyncMethod.TabIndex = 4;
            this.btnRunAsyncMethod.Text = "Run Async Method";
            this.btnRunAsyncMethod.UseVisualStyleBackColor = true;
            this.btnRunAsyncMethod.Click += new System.EventHandler(this.btnRunAsyncMethod_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(326, 767);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 48);
            this.label1.TabIndex = 3;
            this.label1.Text = "0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 29;
            this.listBox1.Location = new System.Drawing.Point(10, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(648, 497);
            this.listBox1.TabIndex = 2;
            // 
            // BtnRunAsyncMethodReturnsValue
            // 
            this.BtnRunAsyncMethodReturnsValue.Location = new System.Drawing.Point(434, 704);
            this.BtnRunAsyncMethodReturnsValue.Name = "BtnRunAsyncMethodReturnsValue";
            this.BtnRunAsyncMethodReturnsValue.Size = new System.Drawing.Size(418, 76);
            this.BtnRunAsyncMethodReturnsValue.TabIndex = 8;
            this.BtnRunAsyncMethodReturnsValue.Text = "Run Async Method That Returns Value";
            this.BtnRunAsyncMethodReturnsValue.UseVisualStyleBackColor = true;
            this.BtnRunAsyncMethodReturnsValue.Click += new System.EventHandler(this.BtnRunAsyncMethodReturnsValue_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 853);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRunMethodOnUiThread;
        private System.Windows.Forms.Button btnCheckIfUiLocked;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRunAsyncMethod;
        private System.Windows.Forms.Button btnWriteFile;
        private System.Windows.Forms.Button BtnDoSomethingElseAsync;
        private System.Windows.Forms.Button btnAsyncReadFile;
        private System.Windows.Forms.Button BtnRunAsyncMethodReturnsValue;
    }
}

