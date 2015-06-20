namespace Client
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
            this.publicityPanel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.outputPanel = new System.Windows.Forms.TextBox();
            this.PlayBtn = new System.Windows.Forms.Button();
            this.yInput = new System.Windows.Forms.TextBox();
            this.xInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.userNameInput = new System.Windows.Forms.TextBox();
            this.UserName = new System.Windows.Forms.Label();
            this.registerBtn = new System.Windows.Forms.Button();
            this.playerStatusOutput = new System.Windows.Forms.TextBox();
            this.unregisterBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // publicityPanel
            // 
            this.publicityPanel.Location = new System.Drawing.Point(12, 223);
            this.publicityPanel.Multiline = true;
            this.publicityPanel.Name = "publicityPanel";
            this.publicityPanel.ReadOnly = true;
            this.publicityPanel.Size = new System.Drawing.Size(459, 84);
            this.publicityPanel.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Output:";
            // 
            // outputPanel
            // 
            this.outputPanel.Location = new System.Drawing.Point(12, 100);
            this.outputPanel.Multiline = true;
            this.outputPanel.Name = "outputPanel";
            this.outputPanel.ReadOnly = true;
            this.outputPanel.Size = new System.Drawing.Size(459, 117);
            this.outputPanel.TabIndex = 33;
            // 
            // PlayBtn
            // 
            this.PlayBtn.Location = new System.Drawing.Point(156, 55);
            this.PlayBtn.Name = "PlayBtn";
            this.PlayBtn.Size = new System.Drawing.Size(54, 23);
            this.PlayBtn.TabIndex = 31;
            this.PlayBtn.Text = "Play";
            this.PlayBtn.UseVisualStyleBackColor = true;
            this.PlayBtn.Click += new System.EventHandler(this.PlayBtn_Click);
            // 
            // yInput
            // 
            this.yInput.Location = new System.Drawing.Point(96, 57);
            this.yInput.Name = "yInput";
            this.yInput.Size = new System.Drawing.Size(54, 20);
            this.yInput.TabIndex = 30;
            // 
            // xInput
            // 
            this.xInput.Location = new System.Drawing.Point(96, 31);
            this.xInput.Name = "xInput";
            this.xInput.Size = new System.Drawing.Size(54, 20);
            this.xInput.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Coordinate Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Coordinate X:";
            // 
            // userNameInput
            // 
            this.userNameInput.Location = new System.Drawing.Point(80, 5);
            this.userNameInput.Name = "userNameInput";
            this.userNameInput.Size = new System.Drawing.Size(310, 20);
            this.userNameInput.TabIndex = 26;
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Location = new System.Drawing.Point(13, 8);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(60, 13);
            this.UserName.TabIndex = 25;
            this.UserName.Text = "UserName:";
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(396, 3);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(75, 23);
            this.registerBtn.TabIndex = 24;
            this.registerBtn.Text = "Register";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // playerStatusOutput
            // 
            this.playerStatusOutput.Location = new System.Drawing.Point(231, 31);
            this.playerStatusOutput.Multiline = true;
            this.playerStatusOutput.Name = "playerStatusOutput";
            this.playerStatusOutput.ReadOnly = true;
            this.playerStatusOutput.Size = new System.Drawing.Size(159, 63);
            this.playerStatusOutput.TabIndex = 36;
            // 
            // unregisterBtn
            // 
            this.unregisterBtn.Location = new System.Drawing.Point(396, 34);
            this.unregisterBtn.Name = "unregisterBtn";
            this.unregisterBtn.Size = new System.Drawing.Size(75, 23);
            this.unregisterBtn.TabIndex = 37;
            this.unregisterBtn.Text = "UnRegister";
            this.unregisterBtn.UseVisualStyleBackColor = true;
            this.unregisterBtn.Click += new System.EventHandler(this.unregisterBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 329);
            this.Controls.Add(this.unregisterBtn);
            this.Controls.Add(this.playerStatusOutput);
            this.Controls.Add(this.publicityPanel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.outputPanel);
            this.Controls.Add(this.PlayBtn);
            this.Controls.Add(this.yInput);
            this.Controls.Add(this.xInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userNameInput);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.registerBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox publicityPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox outputPanel;
        private System.Windows.Forms.Button PlayBtn;
        private System.Windows.Forms.TextBox yInput;
        private System.Windows.Forms.TextBox xInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userNameInput;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.TextBox playerStatusOutput;
        private System.Windows.Forms.Button unregisterBtn;
    }
}

