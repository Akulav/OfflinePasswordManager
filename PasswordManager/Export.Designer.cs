
namespace AuditScaner
{
    partial class ImportExport
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
            this.exportButton = new FontAwesome.Sharp.IconButton();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // exportButton
            // 
            this.exportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.exportButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.exportButton.IconChar = FontAwesome.Sharp.IconChar.None;
            this.exportButton.IconColor = System.Drawing.Color.Black;
            this.exportButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.exportButton.Location = new System.Drawing.Point(334, 183);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(249, 69);
            this.exportButton.TabIndex = 0;
            this.exportButton.Text = "Export Data";
            this.exportButton.UseVisualStyleBackColor = false;
            this.exportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.statusLabel.Location = new System.Drawing.Point(384, 255);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(144, 20);
            this.statusLabel.TabIndex = 2;
            this.statusLabel.Text = "DATA EXPORTED";
            // 
            // ImportExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(921, 624);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.exportButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ImportExport";
            this.Text = "ImportExport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton exportButton;
        private System.Windows.Forms.Label statusLabel;
    }
}