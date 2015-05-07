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
            this.inputFileBtn = new System.Windows.Forms.Button();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.xmlFileTextBox = new System.Windows.Forms.TextBox();
            this.xmlfilelabel = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.createPeerBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.addPeerTextBox = new System.Windows.Forms.TextBox();
            this.addPeerBtn = new System.Windows.Forms.Button();
            this.showPeersTextBox = new System.Windows.Forms.TextBox();
            this.knownPeers = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.musicToSearchTextBox = new System.Windows.Forms.TextBox();
            this.searchMusicBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inputFileBtn
            // 
            this.inputFileBtn.Location = new System.Drawing.Point(292, 5);
            this.inputFileBtn.Name = "inputFileBtn";
            this.inputFileBtn.Size = new System.Drawing.Size(30, 23);
            this.inputFileBtn.TabIndex = 1;
            this.inputFileBtn.Text = "...";
            this.inputFileBtn.UseVisualStyleBackColor = true;
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(57, 6);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(73, 20);
            this.portTextBox.TabIndex = 3;
            // 
            // xmlFileTextBox
            // 
            this.xmlFileTextBox.Location = new System.Drawing.Point(208, 7);
            this.xmlFileTextBox.Name = "xmlFileTextBox";
            this.xmlFileTextBox.Size = new System.Drawing.Size(78, 20);
            this.xmlFileTextBox.TabIndex = 4;
            // 
            // xmlfilelabel
            // 
            this.xmlfilelabel.AutoSize = true;
            this.xmlfilelabel.Location = new System.Drawing.Point(154, 9);
            this.xmlfilelabel.Name = "xmlfilelabel";
            this.xmlfilelabel.Size = new System.Drawing.Size(48, 13);
            this.xmlfilelabel.TabIndex = 6;
            this.xmlfilelabel.Text = "XML File";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(25, 9);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(26, 13);
            this.PortLabel.TabIndex = 7;
            this.PortLabel.Text = "Port";
            // 
            // createPeerBtn
            // 
            this.createPeerBtn.Location = new System.Drawing.Point(346, 5);
            this.createPeerBtn.Name = "createPeerBtn";
            this.createPeerBtn.Size = new System.Drawing.Size(98, 36);
            this.createPeerBtn.TabIndex = 12;
            this.createPeerBtn.Text = "Create Peer";
            this.createPeerBtn.UseVisualStyleBackColor = true;
            this.createPeerBtn.Click += new System.EventHandler(this.CreatePeerBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Add Peer Port:";
            // 
            // addPeerTextBox
            // 
            this.addPeerTextBox.Location = new System.Drawing.Point(94, 64);
            this.addPeerTextBox.Name = "addPeerTextBox";
            this.addPeerTextBox.Size = new System.Drawing.Size(108, 20);
            this.addPeerTextBox.TabIndex = 14;
            // 
            // addPeerBtn
            // 
            this.addPeerBtn.Location = new System.Drawing.Point(208, 64);
            this.addPeerBtn.Name = "addPeerBtn";
            this.addPeerBtn.Size = new System.Drawing.Size(61, 20);
            this.addPeerBtn.TabIndex = 15;
            this.addPeerBtn.Text = "Add";
            this.addPeerBtn.UseVisualStyleBackColor = true;
            this.addPeerBtn.Click += new System.EventHandler(this.addPeerBtn_Click);
            // 
            // showPeersTextBox
            // 
            this.showPeersTextBox.Location = new System.Drawing.Point(15, 112);
            this.showPeersTextBox.Multiline = true;
            this.showPeersTextBox.Name = "showPeersTextBox";
            this.showPeersTextBox.ReadOnly = true;
            this.showPeersTextBox.Size = new System.Drawing.Size(432, 62);
            this.showPeersTextBox.TabIndex = 16;
            // 
            // knownPeers
            // 
            this.knownPeers.AutoSize = true;
            this.knownPeers.Location = new System.Drawing.Point(12, 96);
            this.knownPeers.Name = "knownPeers";
            this.knownPeers.Size = new System.Drawing.Size(88, 13);
            this.knownPeers.TabIndex = 17;
            this.knownPeers.Text = "Added Peer Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Music Name:";
            // 
            // musicToSearchTextBox
            // 
            this.musicToSearchTextBox.Location = new System.Drawing.Point(82, 193);
            this.musicToSearchTextBox.Name = "musicToSearchTextBox";
            this.musicToSearchTextBox.Size = new System.Drawing.Size(298, 20);
            this.musicToSearchTextBox.TabIndex = 19;
            // 
            // searchMusicBtn
            // 
            this.searchMusicBtn.Location = new System.Drawing.Point(386, 193);
            this.searchMusicBtn.Name = "searchMusicBtn";
            this.searchMusicBtn.Size = new System.Drawing.Size(61, 20);
            this.searchMusicBtn.TabIndex = 20;
            this.searchMusicBtn.Text = "Search";
            this.searchMusicBtn.UseVisualStyleBackColor = true;
            this.searchMusicBtn.Click += new System.EventHandler(this.searchMusicBtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 237);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(432, 90);
            this.textBox1.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Requests:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 343);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.searchMusicBtn);
            this.Controls.Add(this.musicToSearchTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.knownPeers);
            this.Controls.Add(this.showPeersTextBox);
            this.Controls.Add(this.addPeerBtn);
            this.Controls.Add(this.addPeerTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createPeerBtn);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.xmlfilelabel);
            this.Controls.Add(this.xmlFileTextBox);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.inputFileBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button inputFileBtn;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.TextBox xmlFileTextBox;
        private System.Windows.Forms.Label xmlfilelabel;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Button createPeerBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox addPeerTextBox;
        private System.Windows.Forms.Button addPeerBtn;
        private System.Windows.Forms.TextBox showPeersTextBox;
        private System.Windows.Forms.Label knownPeers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox musicToSearchTextBox;
        private System.Windows.Forms.Button searchMusicBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
    }
}

