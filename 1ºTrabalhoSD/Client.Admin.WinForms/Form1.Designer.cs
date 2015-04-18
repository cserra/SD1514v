namespace Client.Admin.WinForms
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
            this.maxJobsTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.launchWorkerBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.workerIdsListBox = new System.Windows.Forms.ListBox();
            this.terminateWorkerBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // maxJobsTextBox
            // 
            this.maxJobsTextBox.Location = new System.Drawing.Point(118, 39);
            this.maxJobsTextBox.Name = "maxJobsTextBox";
            this.maxJobsTextBox.Size = new System.Drawing.Size(36, 20);
            this.maxJobsTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "MaxJobs";
            // 
            // launchWorkerBtn
            // 
            this.launchWorkerBtn.Location = new System.Drawing.Point(192, 28);
            this.launchWorkerBtn.Name = "launchWorkerBtn";
            this.launchWorkerBtn.Size = new System.Drawing.Size(80, 40);
            this.launchWorkerBtn.TabIndex = 2;
            this.launchWorkerBtn.Text = "Launch Worker";
            this.launchWorkerBtn.UseVisualStyleBackColor = true;
            this.launchWorkerBtn.Click += new System.EventHandler(this.launchWorkerBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ids";
            // 
            // workerIdsListBox
            // 
            this.workerIdsListBox.FormattingEnabled = true;
            this.workerIdsListBox.Location = new System.Drawing.Point(63, 91);
            this.workerIdsListBox.Name = "workerIdsListBox";
            this.workerIdsListBox.Size = new System.Drawing.Size(195, 121);
            this.workerIdsListBox.TabIndex = 4;
            // 
            // terminateWorkerBtn
            // 
            this.terminateWorkerBtn.Location = new System.Drawing.Point(102, 218);
            this.terminateWorkerBtn.Name = "terminateWorkerBtn";
            this.terminateWorkerBtn.Size = new System.Drawing.Size(113, 27);
            this.terminateWorkerBtn.TabIndex = 5;
            this.terminateWorkerBtn.Text = "Terminate Worker";
            this.terminateWorkerBtn.UseVisualStyleBackColor = true;
            this.terminateWorkerBtn.Click += new System.EventHandler(this.terminateWorkerBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.terminateWorkerBtn);
            this.Controls.Add(this.workerIdsListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.launchWorkerBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maxJobsTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox maxJobsTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button launchWorkerBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox workerIdsListBox;
        private System.Windows.Forms.Button terminateWorkerBtn;
    }
}

