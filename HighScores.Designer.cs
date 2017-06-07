namespace WumpusTest
{
    partial class ScoreScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScoreScreen));
            this.scores = new System.Windows.Forms.Label();
            this.orderLabel = new System.Windows.Forms.Label();
            this.ranks = new System.Windows.Forms.Label();
            this.names = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // scores
            // 
            this.scores.AutoSize = true;
            this.scores.BackColor = System.Drawing.Color.SandyBrown;
            this.scores.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.scores.ForeColor = System.Drawing.Color.White;
            this.scores.Location = new System.Drawing.Point(176, 27);
            this.scores.Name = "scores";
            this.scores.Size = new System.Drawing.Size(186, 36);
            this.scores.TabIndex = 0;
            this.scores.Text = "High Scores:";
            // 
            // orderLabel
            // 
            this.orderLabel.AutoSize = true;
            this.orderLabel.BackColor = System.Drawing.Color.SandyBrown;
            this.orderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.orderLabel.ForeColor = System.Drawing.Color.White;
            this.orderLabel.Location = new System.Drawing.Point(32, 93);
            this.orderLabel.Name = "orderLabel";
            this.orderLabel.Size = new System.Drawing.Size(375, 25);
            this.orderLabel.TabIndex = 2;
            this.orderLabel.Text = "Rank  -  Name                  -                  Score";
            // 
            // ranks
            // 
            this.ranks.AutoSize = true;
            this.ranks.BackColor = System.Drawing.Color.SandyBrown;
            this.ranks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ranks.ForeColor = System.Drawing.Color.White;
            this.ranks.Location = new System.Drawing.Point(49, 133);
            this.ranks.Name = "ranks";
            this.ranks.Size = new System.Drawing.Size(23, 225);
            this.ranks.TabIndex = 3;
            this.ranks.Text = "1\r\n\r\n2\r\n\r\n3\r\n\r\n4\r\n\r\n5";
            // 
            // names
            // 
            this.names.BackColor = System.Drawing.Color.SandyBrown;
            this.names.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.names.ForeColor = System.Drawing.Color.White;
            this.names.Location = new System.Drawing.Point(108, 133);
            this.names.Name = "names";
            this.names.Size = new System.Drawing.Size(222, 225);
            this.names.TabIndex = 4;
            this.names.Text = "1\r\n\r\n2\r\n\r\n3\r\n\r\n4\r\n\r\n5";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SandyBrown;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(349, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 225);
            this.label1.TabIndex = 5;
            this.label1.Text = "1\r\n\r\n2\r\n\r\n3\r\n\r\n4\r\n\r\n5";
            // 
            // menuButton
            // 
            this.menuButton.BackColor = System.Drawing.Color.SandyBrown;
            this.menuButton.ForeColor = System.Drawing.Color.White;
            this.menuButton.Location = new System.Drawing.Point(182, 421);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(148, 39);
            this.menuButton.TabIndex = 6;
            this.menuButton.Text = "Return to Menu";
            this.menuButton.UseVisualStyleBackColor = false;
            // 
            // ScoreScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(552, 491);
            this.Controls.Add(this.menuButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.names);
            this.Controls.Add(this.ranks);
            this.Controls.Add(this.orderLabel);
            this.Controls.Add(this.scores);
            this.Name = "ScoreScreen";
            this.Text = "HighScores";
            this.Load += new System.EventHandler(this.ScoreScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label scores;
        private System.Windows.Forms.Label orderLabel;
        private System.Windows.Forms.Label ranks;
        private System.Windows.Forms.Label names;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button menuButton;
    }
}