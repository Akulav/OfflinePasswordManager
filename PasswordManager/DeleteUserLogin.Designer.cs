
namespace AuditScaner
{
    partial class DeleteUserLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteUserLogin));
            this.deleteLabel = new System.Windows.Forms.Label();
            this.yesButton = new FontAwesome.Sharp.IconButton();
            this.noButton = new FontAwesome.Sharp.IconButton();
            this.topPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // deleteLabel
            // 
            this.deleteLabel.AutoSize = true;
            this.deleteLabel.Font = new System.Drawing.Font("Yu Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.deleteLabel.Location = new System.Drawing.Point(75, 89);
            this.deleteLabel.Name = "deleteLabel";
            this.deleteLabel.Size = new System.Drawing.Size(415, 42);
            this.deleteLabel.TabIndex = 0;
            this.deleteLabel.Text = "Proceed to delete all data?";
            // 
            // yesButton
            // 
            this.yesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.yesButton.Font = new System.Drawing.Font("Yu Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yesButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.yesButton.IconChar = FontAwesome.Sharp.IconChar.None;
            this.yesButton.IconColor = System.Drawing.Color.Black;
            this.yesButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.yesButton.Location = new System.Drawing.Point(298, 144);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(192, 41);
            this.yesButton.TabIndex = 1;
            this.yesButton.Text = "Yes";
            this.yesButton.UseVisualStyleBackColor = false;
            this.yesButton.Click += new System.EventHandler(this.YesButton_Click);
            // 
            // noButton
            // 
            this.noButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.noButton.Font = new System.Drawing.Font("Yu Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.noButton.IconChar = FontAwesome.Sharp.IconChar.None;
            this.noButton.IconColor = System.Drawing.Color.Black;
            this.noButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.noButton.Location = new System.Drawing.Point(82, 144);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(192, 41);
            this.noButton.TabIndex = 2;
            this.noButton.Text = "No";
            this.noButton.UseVisualStyleBackColor = false;
            this.noButton.Click += new System.EventHandler(this.NoButton_Click);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(571, 50);
            this.topPanel.TabIndex = 3;
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseDown);
            // 
            // DeleteUserLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(571, 253);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.yesButton);
            this.Controls.Add(this.deleteLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeleteUserLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeleteUserLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label deleteLabel;
        private FontAwesome.Sharp.IconButton yesButton;
        private FontAwesome.Sharp.IconButton noButton;
        private System.Windows.Forms.Panel topPanel;
    }
}