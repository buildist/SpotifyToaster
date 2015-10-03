﻿namespace spotifytoaster
{
    partial class ToastOverlay
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
            this.trackBox = new System.Windows.Forms.Label();
            this.artistBox = new System.Windows.Forms.Label();
            this.albumBox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // trackBox
            // 
            this.trackBox.AutoSize = true;
            this.trackBox.BackColor = System.Drawing.Color.Black;
            this.trackBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trackBox.ForeColor = System.Drawing.Color.YellowGreen;
            this.trackBox.Location = new System.Drawing.Point(80, 57);
            this.trackBox.Name = "trackBox";
            this.trackBox.Size = new System.Drawing.Size(93, 16);
            this.trackBox.TabIndex = 8;
            this.trackBox.Text = "Track Name";
            // 
            // artistBox
            // 
            this.artistBox.AutoSize = true;
            this.artistBox.BackColor = System.Drawing.Color.Black;
            this.artistBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.artistBox.ForeColor = System.Drawing.Color.YellowGreen;
            this.artistBox.Location = new System.Drawing.Point(80, 34);
            this.artistBox.Name = "artistBox";
            this.artistBox.Size = new System.Drawing.Size(43, 16);
            this.artistBox.TabIndex = 7;
            this.artistBox.Text = "Artist";
            // 
            // albumBox
            // 
            this.albumBox.AutoSize = true;
            this.albumBox.BackColor = System.Drawing.Color.Black;
            this.albumBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.albumBox.ForeColor = System.Drawing.Color.YellowGreen;
            this.albumBox.Location = new System.Drawing.Point(80, 10);
            this.albumBox.Name = "albumBox";
            this.albumBox.Size = new System.Drawing.Size(51, 16);
            this.albumBox.TabIndex = 12;
            this.albumBox.Text = "Album";
            // 
            // ToastOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(363, 84);
            this.ControlBox = false;
            this.Controls.Add(this.albumBox);
            this.Controls.Add(this.trackBox);
            this.Controls.Add(this.artistBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ToastOverlay";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ToastOverlay";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Black;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label trackBox;
        internal System.Windows.Forms.Label artistBox;
        internal System.Windows.Forms.Label albumBox;


    }
}