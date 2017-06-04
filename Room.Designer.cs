namespace WumpusTest
{
    partial class Room
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Room));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.room1 = new System.Windows.Forms.Button();
            this.room2 = new System.Windows.Forms.Button();
            this.room3 = new System.Windows.Forms.Button();
            this.room4 = new System.Windows.Forms.Button();
            this.room5 = new System.Windows.Forms.Button();
            this.room6 = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.turnLabel = new System.Windows.Forms.Label();
            this.playerScore = new System.Windows.Forms.Label();
            this.RoomNum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(622, 265);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 36);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // room1
            // 
            this.room1.Location = new System.Drawing.Point(344, 172);
            this.room1.Name = "room1";
            this.room1.Size = new System.Drawing.Size(75, 23);
            this.room1.TabIndex = 2;
            this.room1.Text = "Room 1";
            this.room1.UseVisualStyleBackColor = true;
            this.room1.Click += new System.EventHandler(this.room1_Click);
            // 
            // room2
            // 
            this.room2.Location = new System.Drawing.Point(535, 111);
            this.room2.Name = "room2";
            this.room2.Size = new System.Drawing.Size(75, 23);
            this.room2.TabIndex = 3;
            this.room2.Text = "Room 2";
            this.room2.UseVisualStyleBackColor = true;
            this.room2.Click += new System.EventHandler(this.room2_Click);
            // 
            // room3
            // 
            this.room3.Location = new System.Drawing.Point(689, 172);
            this.room3.Name = "room3";
            this.room3.Size = new System.Drawing.Size(75, 23);
            this.room3.TabIndex = 4;
            this.room3.Text = "Room 3";
            this.room3.UseVisualStyleBackColor = true;
            this.room3.Click += new System.EventHandler(this.room3_Click);
            // 
            // room4
            // 
            this.room4.Location = new System.Drawing.Point(708, 348);
            this.room4.Name = "room4";
            this.room4.Size = new System.Drawing.Size(75, 23);
            this.room4.TabIndex = 5;
            this.room4.Text = "Room 4";
            this.room4.UseVisualStyleBackColor = true;
            this.room4.Click += new System.EventHandler(this.room4_Click);
            // 
            // room5
            // 
            this.room5.Location = new System.Drawing.Point(535, 432);
            this.room5.Name = "room5";
            this.room5.Size = new System.Drawing.Size(75, 23);
            this.room5.TabIndex = 6;
            this.room5.Text = "Room 5";
            this.room5.UseVisualStyleBackColor = true;
            this.room5.Click += new System.EventHandler(this.room5_Click);
            // 
            // room6
            // 
            this.room6.Location = new System.Drawing.Point(301, 348);
            this.room6.Name = "room6";
            this.room6.Size = new System.Drawing.Size(75, 23);
            this.room6.TabIndex = 7;
            this.room6.Text = "Room 6";
            this.room6.UseVisualStyleBackColor = true;
            this.room6.Click += new System.EventHandler(this.room6_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(829, 445);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 8;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Gold Count: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Arrow Count:";
            // 
            // turnLabel
            // 
            this.turnLabel.AutoSize = true;
            this.turnLabel.Location = new System.Drawing.Point(12, 250);
            this.turnLabel.Name = "turnLabel";
            this.turnLabel.Size = new System.Drawing.Size(126, 17);
            this.turnLabel.TabIndex = 11;
            this.turnLabel.Text = "Number Of Turns: ";
            // 
            // playerScore
            // 
            this.playerScore.AutoSize = true;
            this.playerScore.Location = new System.Drawing.Point(12, 284);
            this.playerScore.Name = "playerScore";
            this.playerScore.Size = new System.Drawing.Size(104, 17);
            this.playerScore.TabIndex = 12;
            this.playerScore.Text = "Current Score: ";
            // 
            // RoomNum
            // 
            this.RoomNum.AutoSize = true;
            this.RoomNum.Location = new System.Drawing.Point(12, 314);
            this.RoomNum.Name = "RoomNum";
            this.RoomNum.Size = new System.Drawing.Size(107, 17);
            this.RoomNum.TabIndex = 13;
            this.RoomNum.Text = "Room Number: ";
            // 
            // Room
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(958, 535);
            this.Controls.Add(this.RoomNum);
            this.Controls.Add(this.playerScore);
            this.Controls.Add(this.turnLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.room6);
            this.Controls.Add(this.room5);
            this.Controls.Add(this.room4);
            this.Controls.Add(this.room3);
            this.Controls.Add(this.room2);
            this.Controls.Add(this.room1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Room";
            this.Text = "Room";
            this.Load += new System.EventHandler(this.Room_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button room1;
        private System.Windows.Forms.Button room2;
        private System.Windows.Forms.Button room3;
        private System.Windows.Forms.Button room4;
        private System.Windows.Forms.Button room5;
        private System.Windows.Forms.Button room6;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label turnLabel;
        private System.Windows.Forms.Label playerScore;
        private System.Windows.Forms.Label RoomNum;
    }
}