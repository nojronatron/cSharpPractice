namespace TasksWithWindowsForms
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
            this.buttonStartTasks = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.btnStartTaskWithTResult = new System.Windows.Forms.Button();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.btnStartTaskWithTResultNonBlocking = new System.Windows.Forms.Button();
            this.btnChainingTasks = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 29;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(286, 700);
            this.listBox1.TabIndex = 0;
            // 
            // buttonStartTasks
            // 
            this.buttonStartTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartTasks.Location = new System.Drawing.Point(12, 732);
            this.buttonStartTasks.Name = "buttonStartTasks";
            this.buttonStartTasks.Size = new System.Drawing.Size(583, 45);
            this.buttonStartTasks.TabIndex = 1;
            this.buttonStartTasks.Text = "Start Tasks";
            this.buttonStartTasks.UseVisualStyleBackColor = true;
            this.buttonStartTasks.Click += new System.EventHandler(this.buttonStartTasks_Click);
            // 
            // listBox2
            // 
            this.listBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 29;
            this.listBox2.Location = new System.Drawing.Point(305, 13);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(290, 700);
            this.listBox2.TabIndex = 2;
            // 
            // btnStartTaskWithTResult
            // 
            this.btnStartTaskWithTResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartTaskWithTResult.Location = new System.Drawing.Point(610, 471);
            this.btnStartTaskWithTResult.Name = "btnStartTaskWithTResult";
            this.btnStartTaskWithTResult.Size = new System.Drawing.Size(423, 93);
            this.btnStartTaskWithTResult.TabIndex = 3;
            this.btnStartTaskWithTResult.Text = "Start Tasks that Return Value but Blocks the UI Thread";
            this.btnStartTaskWithTResult.UseVisualStyleBackColor = true;
            this.btnStartTaskWithTResult.Click += new System.EventHandler(this.btnStartTaskWithTResult_Click);
            // 
            // listBox3
            // 
            this.listBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 29;
            this.listBox3.Location = new System.Drawing.Point(610, 13);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(432, 410);
            this.listBox3.TabIndex = 4;
            // 
            // btnStartTaskWithTResultNonBlocking
            // 
            this.btnStartTaskWithTResultNonBlocking.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartTaskWithTResultNonBlocking.Location = new System.Drawing.Point(610, 583);
            this.btnStartTaskWithTResultNonBlocking.Name = "btnStartTaskWithTResultNonBlocking";
            this.btnStartTaskWithTResultNonBlocking.Size = new System.Drawing.Size(423, 84);
            this.btnStartTaskWithTResultNonBlocking.TabIndex = 5;
            this.btnStartTaskWithTResultNonBlocking.Text = "Start Tasks that Return Value and Query The Results Non-Blocking";
            this.btnStartTaskWithTResultNonBlocking.UseVisualStyleBackColor = true;
            this.btnStartTaskWithTResultNonBlocking.Click += new System.EventHandler(this.btnStartTaskWithTResultNonBlocking_Click);
            // 
            // btnChainingTasks
            // 
            this.btnChainingTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChainingTasks.Location = new System.Drawing.Point(610, 693);
            this.btnChainingTasks.Name = "btnChainingTasks";
            this.btnChainingTasks.Size = new System.Drawing.Size(423, 84);
            this.btnChainingTasks.TabIndex = 6;
            this.btnChainingTasks.Text = "Start Chained Tasks";
            this.btnChainingTasks.UseVisualStyleBackColor = true;
            this.btnChainingTasks.Click += new System.EventHandler(this.btnChainingTasks_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 789);
            this.Controls.Add(this.btnChainingTasks);
            this.Controls.Add(this.btnStartTaskWithTResultNonBlocking);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.btnStartTaskWithTResult);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.buttonStartTasks);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonStartTasks;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button btnStartTaskWithTResult;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Button btnStartTaskWithTResultNonBlocking;
        private System.Windows.Forms.Button btnChainingTasks;
    }
}

