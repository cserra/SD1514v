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
            this.outputPanel = new System.Windows.Forms.TextBox();
            this.servicoLabel = new System.Windows.Forms.Label();
            this.createBtn = new System.Windows.Forms.Button();
            this.sizeInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Informação:";
            // 
            // outputPanel
            // 
            this.outputPanel.Location = new System.Drawing.Point(12, 91);
            this.outputPanel.Multiline = true;
            this.outputPanel.Name = "outputPanel";
            this.outputPanel.ReadOnly = true;
            this.outputPanel.Size = new System.Drawing.Size(255, 121);
            this.outputPanel.TabIndex = 16;
            // 
            // servicoLabel
            // 
            this.servicoLabel.AutoSize = true;
            this.servicoLabel.Location = new System.Drawing.Point(100, 60);
            this.servicoLabel.Name = "servicoLabel";
            this.servicoLabel.Size = new System.Drawing.Size(96, 13);
            this.servicoLabel.TabIndex = 15;
            this.servicoLabel.Text = "Serviço não criado";
            // 
            // createBtn
            // 
            this.createBtn.Location = new System.Drawing.Point(112, 34);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 219);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.outputPanel);
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
        private System.Windows.Forms.TextBox outputPanel;
        private System.Windows.Forms.Label servicoLabel;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.TextBox sizeInput;
        private System.Windows.Forms.Label label1;
    }
}

