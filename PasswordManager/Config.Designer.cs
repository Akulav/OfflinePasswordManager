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
            this.label0 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.themeButton = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // label0
            // 
            this.label0.AutoSize = true;
            this.label0.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label0.ForeColor = System.Drawing.Color.Gainsboro;
            this.label0.Location = new System.Drawing.Point(174, 254);
            this.label0.Name = "label0";
            this.label0.Size = new System.Drawing.Size(601, 51);
            this.label0.TabIndex = 0;
            this.label0.Text = "This program uses encryption.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(174, 305);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(561, 51);
            this.label1.TabIndex = 1;
            this.label1.Text = "All files are securely erased.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(369, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(475, 51);
            this.label2.TabIndex = 2;
            this.label2.Text = "This will restart the app.";
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
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(924, 621);
            this.Controls.Add(this.themeButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Config";
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton themeButton;
    }
}