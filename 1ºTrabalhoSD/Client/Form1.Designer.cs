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
            this.xmlFileTextBox = new System.Windows.Forms.TextBox();
            this.xmlfilelabel = new System.Windows.Forms.Label();
            this.createPeerBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.addPeerTextBox = new System.Windows.Forms.TextBox();
            this.addPeerBtn = new System.Windows.Forms.Button();
            this.showPeersTextBox = new System.Windows.Forms.TextBox();
            this.knownPeers = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.musicToSearchTextBox = new System.Windows.Forms.TextBox();
            this.searchMusicBtn = new System.Windows.Forms.Button();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pathBtn = new System.Windows.Forms.Button();
            this.albumSearchMusicBtn = new System.Windows.Forms.Button();
            this.albumToSearchTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // xmlFileTextBox
            // 
            this.xmlFileTextBox.Location = new System.Drawing.Point(82, 7);
            this.xmlFileTextBox.Name = "xmlFileTextBox";
            this.xmlFileTextBox.ReadOnly = true;
            this.xmlFileTextBox.Size = new System.Drawing.Size(216, 20);
            this.xmlFileTextBox.TabIndex = 4;
            // 
            // xmlfilelabel
            // 
            this.xmlfilelabel.AutoSize = true;
            this.xmlfilelabel.Location = new System.Drawing.Point(12, 10);
            this.xmlfilelabel.Name = "xmlfilelabel";
            this.xmlfilelabel.Size = new System.Drawing.Size(48, 13);
            this.xmlfilelabel.TabIndex = 6;
            this.xmlfilelabel.Text = "XML File";
            // 
            // createPeerBtn
            // 
            this.createPeerBtn.Location = new System.Drawing.Point(346, 5);
            this.createPeerBtn.Name = "createPeerBtn";
            this.createPeerBtn.Size = new System.Drawing.Size(98, 23);
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
            this.label1.Text = "Add Peer URI:";
            // 
            // addPeerTextBox
            // 
            this.addPeerTextBox.Location = new System.Drawing.Point(94, 64);
            this.addPeerTextBox.Name = "addPeerTextBox";
            this.addPeerTextBox.ReadOnly = true;
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
            this.musicToSearchTextBox.ReadOnly = true;
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
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(15, 261);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.Size = new System.Drawing.Size(432, 90);
            this.outputTextBox.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Output:";
            // 
            // pathBtn
            // 
            this.pathBtn.Location = new System.Drawing.Point(304, 5);
            this.pathBtn.Name = "pathBtn";
            this.pathBtn.Size = new System.Drawing.Size(36, 23);
            this.pathBtn.TabIndex = 23;
            this.pathBtn.Text = "...";
            this.pathBtn.UseVisualStyleBackColor = true;
            this.pathBtn.Click += new System.EventHandler(this.pathBtn_Click);
            // 
            // albumSearchMusicBtn
            // 
            this.albumSearchMusicBtn.Location = new System.Drawing.Point(386, 219);
            this.albumSearchMusicBtn.Name = "albumSearchMusicBtn";
            this.albumSearchMusicBtn.Size = new System.Drawing.Size(61, 20);
            this.albumSearchMusicBtn.TabIndex = 26;
            this.albumSearchMusicBtn.Text = "Search";
            this.albumSearchMusicBtn.UseVisualStyleBackColor = true;
            this.albumSearchMusicBtn.Click += new System.EventHandler(this.albumSearchMusicBtn_Click);
            // 
            // albumToSearchTextBox
            // 
            this.albumToSearchTextBox.Location = new System.Drawing.Point(82, 219);
            this.albumToSearchTextBox.Name = "albumToSearchTextBox";
            this.albumToSearchTextBox.ReadOnly = true;
            this.albumToSearchTextBox.Size = new System.Drawing.Size(298, 20);
            this.albumToSearchTextBox.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Album Name:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 363);
            this.Controls.Add(this.albumSearchMusicBtn);
            this.Controls.Add(this.albumToSearchTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pathBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.searchMusicBtn);
            this.Controls.Add(this.musicToSearchTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.knownPeers);
            this.Controls.Add(this.showPeersTextBox);
            this.Controls.Add(this.addPeerBtn);
            this.Controls.Add(this.addPeerTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createPeerBtn);
            this.Controls.Add(this.xmlfilelabel);
            this.Controls.Add(this.xmlFileTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox xmlFileTextBox;
        private System.Windows.Forms.Label xmlfilelabel;
        private System.Windows.Forms.Button createPeerBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox addPeerTextBox;
        private System.Windows.Forms.Button addPeerBtn;
        private System.Windows.Forms.TextBox showPeersTextBox;
        private System.Windows.Forms.Label knownPeers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox musicToSearchTextBox;
        private System.Windows.Forms.Button searchMusicBtn;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button pathBtn;
        private System.Windows.Forms.Button albumSearchMusicBtn;
        private System.Windows.Forms.TextBox albumToSearchTextBox;
        private System.Windows.Forms.Label label4;
    }
}

