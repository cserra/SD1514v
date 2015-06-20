namespace Manager
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
            this.label2 = new System.Windows.Forms.Label();
            this.servicoLabel = new System.Windows.Forms.Label();
            this.createBtn = new System.Windows.Forms.Button();
            this.sizeInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.newGameBtn = new System.Windows.Forms.Button();
            this.publiInput = new System.Windows.Forms.TextBox();
            this.publishBtn = new System.Windows.Forms.Button();
            this.outputPanel = new System.Windows.Forms.TextBox();
            this.suspendBtn = new System.Windows.Forms.Button();
            this.endGameBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Publishing:";
            // 
            // servicoLabel
            // 
            this.servicoLabel.AutoSize = true;
            this.servicoLabel.Location = new System.Drawing.Point(146, 31);
            this.servicoLabel.Name = "servicoLabel";
            this.servicoLabel.Size = new System.Drawing.Size(96, 13);
            this.servicoLabel.TabIndex = 15;
            this.servicoLabel.Text = "Serviço não criado";
            // 
            // createBtn
            // 
            this.createBtn.Location = new System.Drawing.Point(276, 6);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(75, 23);
            this.createBtn.TabIndex = 14;
            this.createBtn.Text = "Criar Serviço";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // sizeInput
            // 
            this.sizeInput.Location = new System.Drawing.Point(149, 8);
            this.sizeInput.Name = "sizeInput";
            this.sizeInput.Size = new System.Drawing.Size(121, 20);
            this.sizeInput.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tamanho da Matrix (NxN):";
            // 
            // newGameBtn
            // 
            this.newGameBtn.Location = new System.Drawing.Point(275, 35);
            this.newGameBtn.Name = "newGameBtn";
            this.newGameBtn.Size = new System.Drawing.Size(75, 23);
            this.newGameBtn.TabIndex = 18;
            this.newGameBtn.Text = "New Game";
            this.newGameBtn.UseVisualStyleBackColor = true;
            this.newGameBtn.Click += new System.EventHandler(this.newGameBtn_Click);
            // 
            // publiInput
            // 
            this.publiInput.Location = new System.Drawing.Point(12, 135);
            this.publiInput.Multiline = true;
            this.publiInput.Name = "publiInput";
            this.publiInput.Size = new System.Drawing.Size(339, 93);
            this.publiInput.TabIndex = 19;
            // 
            // publishBtn
            // 
            this.publishBtn.Location = new System.Drawing.Point(275, 234);
            this.publishBtn.Name = "publishBtn";
            this.publishBtn.Size = new System.Drawing.Size(75, 23);
            this.publishBtn.TabIndex = 20;
            this.publishBtn.Text = "Publish";
            this.publishBtn.UseVisualStyleBackColor = true;
            this.publishBtn.Click += new System.EventHandler(this.publishBtn_Click);
            // 
            // outputPanel
            // 
            this.outputPanel.Location = new System.Drawing.Point(15, 53);
            this.outputPanel.Multiline = true;
            this.outputPanel.Name = "outputPanel";
            this.outputPanel.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.outputPanel.Size = new System.Drawing.Size(258, 63);
            this.outputPanel.TabIndex = 21;
            // 
            // suspendBtn
            // 
            this.suspendBtn.Location = new System.Drawing.Point(276, 64);
            this.suspendBtn.Name = "suspendBtn";
            this.suspendBtn.Size = new System.Drawing.Size(75, 23);
            this.suspendBtn.TabIndex = 22;
            this.suspendBtn.Text = "Stop Game";
            this.suspendBtn.UseVisualStyleBackColor = true;
            this.suspendBtn.Click += new System.EventHandler(this.suspendBtn_Click);
            // 
            // endGameBtn
            // 
            this.endGameBtn.Location = new System.Drawing.Point(275, 93);
            this.endGameBtn.Name = "endGameBtn";
            this.endGameBtn.Size = new System.Drawing.Size(75, 23);
            this.endGameBtn.TabIndex = 23;
            this.endGameBtn.Text = "End Game";
            this.endGameBtn.UseVisualStyleBackColor = true;
            this.endGameBtn.Click += new System.EventHandler(this.endGameBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 259);
            this.Controls.Add(this.endGameBtn);
            this.Controls.Add(this.suspendBtn);
            this.Controls.Add(this.outputPanel);
            this.Controls.Add(this.publishBtn);
            this.Controls.Add(this.publiInput);
            this.Controls.Add(this.newGameBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.servicoLabel);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.sizeInput);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label servicoLabel;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.TextBox sizeInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button newGameBtn;
        private System.Windows.Forms.TextBox publiInput;
        private System.Windows.Forms.Button publishBtn;
        private System.Windows.Forms.TextBox outputPanel;
        private System.Windows.Forms.Button suspendBtn;
        private System.Windows.Forms.Button endGameBtn;
    }
}

