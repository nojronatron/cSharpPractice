namespace ChildTasks
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
            this.btnStartUnattachedChildTasks = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStartAttachedChildTasks = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.btnUnattachedChildTaskParentTaskWaitForResult = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 29;
            this.listBox1.Location = new System.Drawing.Point(14, 22);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(655, 526);
            this.listBox1.TabIndex = 0;
            // 
            // btnStartUnattachedChildTasks
            // 
            this.btnStartUnattachedChildTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartUnattachedChildTasks.Location = new System.Drawing.Point(14, 611);
            this.btnStartUnattachedChildTasks.Name = "btnStartUnattachedChildTasks";
            this.btnStartUnattachedChildTasks.Size = new System.Drawing.Size(337, 41);
            this.btnStartUnattachedChildTasks.TabIndex = 1;
            this.btnStartUnattachedChildTasks.Text = "Start Unattached Child Tasks";
            this.btnStartUnattachedChildTasks.UseVisualStyleBackColor = true;
            this.btnStartUnattachedChildTasks.Click += new System.EventHandler(this.btnStartUnattachedChildTasks_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnUnattachedChildTaskParentTaskWaitForResult);
            this.panel1.Controls.Add(this.listBox2);
            this.panel1.Controls.Add(this.btnStartAttachedChildTasks);
            this.panel1.Controls.Add(this.btnStartUnattachedChildTasks);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1365, 668);
            this.panel1.TabIndex = 2;
            // 
            // btnStartAttachedChildTasks
            // 
            this.btnStartAttachedChildTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartAttachedChildTasks.Location = new System.Drawing.Point(357, 611);
            this.btnStartAttachedChildTasks.Name = "btnStartAttachedChildTasks";
            this.btnStartAttachedChildTasks.Size = new System.Drawing.Size(312, 41);
            this.btnStartAttachedChildTasks.TabIndex = 2;
            this.btnStartAttachedChildTasks.Text = "Start Attached Child Tasks";
            this.btnStartAttachedChildTasks.UseVisualStyleBackColor = true;
            this.btnStartAttachedChildTasks.Click += new System.EventHandler(this.btnStartAttachedChildTasks_Click);
            // 
            // listBox2
            // 
            this.listBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 29;
            this.listBox2.Location = new System.Drawing.Point(690, 22);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(655, 526);
            this.listBox2.TabIndex = 3;
            // 
            // btnUnattachedChildTaskParentTaskWaitForResult
            // 
            this.btnUnattachedChildTaskParentTaskWaitForResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnattachedChildTaskParentTaskWaitForResult.Location = new System.Drawing.Point(690, 568);
            this.btnUnattachedChildTaskParentTaskWaitForResult.Name = "btnUnattachedChildTaskParentTaskWaitForResult";
            this.btnUnattachedChildTaskParentTaskWaitForResult.Size = new System.Drawing.Size(361, 84);
            this.btnUnattachedChildTaskParentTaskWaitForResult.TabIndex = 4;
            this.btnUnattachedChildTaskParentTaskWaitForResult.Text = "Unattached Child Task Parent Task Waiting for Result";
            this.btnUnattachedChildTaskParentTaskWaitForResult.UseVisualStyleBackColor = true;
            this.btnUnattachedChildTaskParentTaskWaitForResult.Click += new System.EventHandler(this.btnUnattachedChildTaskParentTaskWaitForResult_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1401, 696);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnStartUnattachedChildTasks;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStartAttachedChildTasks;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button btnUnattachedChildTaskParentTaskWaitForResult;
    }
}

