
namespace AuditScaner
{
    partial class ImportConfirm
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
            this.importLabel = new System.Windows.Forms.Label();
            this.yesButton = new FontAwesome.Sharp.IconButton();
            this.noButton = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // importLabel
            // 
            this.importLabel.AutoSize = true;
            this.importLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.importLabel.Location = new System.Drawing.Point(192, 190);
            this.importLabel.Name = "importLabel";
            this.importLabel.Size = new System.Drawing.Size(558, 37);
            this.importLabel.TabIndex = 0;
            this.importLabel.Text = "Importing will erase all data. Proceed?";
            // 
            // yesButton
            // 
            this.yesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.yesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yesButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.yesButton.IconChar = FontAwesome.Sharp.IconChar.None;
            this.yesButton.IconColor = System.Drawing.Color.Black;
            this.yesButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.yesButton.Location = new System.Drawing.Point(500, 293);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(250, 75);
            this.yesButton.TabIndex = 1;
            this.yesButton.Text = "Yes";
            this.yesButton.UseVisualStyleBackColor = false;
            this.yesButton.Click += new System.EventHandler(this.YesButton_Click);
            // 
            // noButton
            // 
            this.noButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.noButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.noButton.IconChar = FontAwesome.Sharp.IconChar.None;
            this.noButton.IconColor = System.Drawing.Color.Black;
            this.noButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.noButton.Location = new System.Drawing.Point(199, 293);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(250, 75);
            this.noButton.TabIndex = 2;
            this.noButton.Text = "No";
            this.noButton.UseVisualStyleBackColor = false;
            this.noButton.Click += new System.EventHandler(this.NoButton_Click);
            // 
            // ImportConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(921, 624);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.yesButton);
            this.Controls.Add(this.importLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ImportConfirm";
            this.Text = "ImportConfirm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label importLabel;
        private FontAwesome.Sharp.IconButton yesButton;
        private FontAwesome.Sharp.IconButton noButton;
    }
}