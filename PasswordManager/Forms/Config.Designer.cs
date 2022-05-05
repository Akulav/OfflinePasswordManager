namespace PasswordManager
{
    partial class Config
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
            this.themeLabel = new System.Windows.Forms.Label();
            this.themeButton = new FontAwesome.Sharp.IconButton();
            this.checkHaskButton = new FontAwesome.Sharp.IconButton();
            this.hash = new System.Windows.Forms.Label();
            this.downloadedHash = new System.Windows.Forms.Label();
            this.timeBox = new System.Windows.Forms.TextBox();
            this.timeButton = new FontAwesome.Sharp.IconButton();
            this.timeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // themeLabel
            // 
            this.themeLabel.AutoSize = true;
            this.themeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themeLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.themeLabel.Location = new System.Drawing.Point(369, 200);
            this.themeLabel.Name = "themeLabel";
            this.themeLabel.Size = new System.Drawing.Size(475, 51);
            this.themeLabel.TabIndex = 2;
            this.themeLabel.Text = "This will restart the app.";
            // 
            // themeButton
            // 
            this.themeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.themeButton.Font = new System.Drawing.Font("Yu Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themeButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.themeButton.IconChar = FontAwesome.Sharp.IconChar.None;
            this.themeButton.IconColor = System.Drawing.Color.Black;
            this.themeButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.themeButton.Location = new System.Drawing.Point(171, 200);
            this.themeButton.Name = "themeButton";
            this.themeButton.Size = new System.Drawing.Size(192, 51);
            this.themeButton.TabIndex = 3;
            this.themeButton.Text = "THEME PLACEHOLDEER";
            this.themeButton.UseVisualStyleBackColor = false;
            this.themeButton.Click += new System.EventHandler(this.ThemeButton_Click);
            // 
            // checkHaskButton
            // 
            this.checkHaskButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.checkHaskButton.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkHaskButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkHaskButton.IconChar = FontAwesome.Sharp.IconChar.None;
            this.checkHaskButton.IconColor = System.Drawing.Color.Black;
            this.checkHaskButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.checkHaskButton.Location = new System.Drawing.Point(171, 268);
            this.checkHaskButton.Name = "checkHaskButton";
            this.checkHaskButton.Size = new System.Drawing.Size(192, 63);
            this.checkHaskButton.TabIndex = 4;
            this.checkHaskButton.Text = "Check Hash";
            this.checkHaskButton.UseVisualStyleBackColor = false;
            this.checkHaskButton.Click += new System.EventHandler(this.CheckHaskButton_Click);
            // 
            // hash
            // 
            this.hash.AutoSize = true;
            this.hash.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hash.ForeColor = System.Drawing.Color.Gainsboro;
            this.hash.Location = new System.Drawing.Point(373, 268);
            this.hash.Name = "hash";
            this.hash.Size = new System.Drawing.Size(189, 26);
            this.hash.TabIndex = 5;
            this.hash.Text = "PLACE_HOLDER";
            // 
            // downloadedHash
            // 
            this.downloadedHash.AutoSize = true;
            this.downloadedHash.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadedHash.ForeColor = System.Drawing.Color.Gainsboro;
            this.downloadedHash.Location = new System.Drawing.Point(373, 305);
            this.downloadedHash.Name = "downloadedHash";
            this.downloadedHash.Size = new System.Drawing.Size(189, 26);
            this.downloadedHash.TabIndex = 6;
            this.downloadedHash.Text = "PLACE_HOLDER";
            this.downloadedHash.Visible = false;
            // 
            // timeBox
            // 
            this.timeBox.Location = new System.Drawing.Point(378, 364);
            this.timeBox.Name = "timeBox";
            this.timeBox.Size = new System.Drawing.Size(184, 20);
            this.timeBox.TabIndex = 7;
            // 
            // timeButton
            // 
            this.timeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.timeButton.Font = new System.Drawing.Font("Yu Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.timeButton.IconChar = FontAwesome.Sharp.IconChar.None;
            this.timeButton.IconColor = System.Drawing.Color.Black;
            this.timeButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.timeButton.Location = new System.Drawing.Point(171, 346);
            this.timeButton.Name = "timeButton";
            this.timeButton.Size = new System.Drawing.Size(192, 51);
            this.timeButton.TabIndex = 8;
            this.timeButton.Text = "Set Timeout (s)";
            this.timeButton.UseVisualStyleBackColor = false;
            this.timeButton.Click += new System.EventHandler(this.TimeButton_Click);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.timeLabel.Location = new System.Drawing.Point(568, 358);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(0, 26);
            this.timeLabel.TabIndex = 9;
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(924, 621);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.timeButton);
            this.Controls.Add(this.timeBox);
            this.Controls.Add(this.downloadedHash);
            this.Controls.Add(this.hash);
            this.Controls.Add(this.checkHaskButton);
            this.Controls.Add(this.themeButton);
            this.Controls.Add(this.themeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Config";
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.Config_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label themeLabel;
        private FontAwesome.Sharp.IconButton themeButton;
        private FontAwesome.Sharp.IconButton checkHaskButton;
        private System.Windows.Forms.Label hash;
        private System.Windows.Forms.Label downloadedHash;
        private System.Windows.Forms.TextBox timeBox;
        private FontAwesome.Sharp.IconButton timeButton;
        private System.Windows.Forms.Label timeLabel;
    }
}