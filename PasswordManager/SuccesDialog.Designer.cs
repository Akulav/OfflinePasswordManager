
namespace AuditScaner
{
    partial class SuccesDialog
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
            this.Succes = new System.Windows.Forms.Label();
            this.DialogConfirm = new FontAwesome.Sharp.IconButton();
            this.topPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Succes
            // 
            this.Succes.AutoSize = true;
            this.Succes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Succes.ForeColor = System.Drawing.Color.Gainsboro;
            this.Succes.Location = new System.Drawing.Point(65, 38);
            this.Succes.Name = "Succes";
            this.Succes.Size = new System.Drawing.Size(299, 24);
            this.Succes.TabIndex = 0;
            this.Succes.Text = "Operation completed with success\r\n";
            // 
            // DialogConfirm
            // 
            this.DialogConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.DialogConfirm.Cursor = System.Windows.Forms.Cursors.Default;
            this.DialogConfirm.ForeColor = System.Drawing.Color.Gainsboro;
            this.DialogConfirm.IconChar = FontAwesome.Sharp.IconChar.None;
            this.DialogConfirm.IconColor = System.Drawing.Color.BlanchedAlmond;
            this.DialogConfirm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.DialogConfirm.Location = new System.Drawing.Point(69, 74);
            this.DialogConfirm.Name = "DialogConfirm";
            this.DialogConfirm.Size = new System.Drawing.Size(295, 38);
            this.DialogConfirm.TabIndex = 1;
            this.DialogConfirm.Text = "OK";
            this.DialogConfirm.UseVisualStyleBackColor = false;
            this.DialogConfirm.Click += new System.EventHandler(this.DialogConfirm_Click);
            // 
            // topPanel
            // 
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(413, 33);
            this.topPanel.TabIndex = 6;
            this.topPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.topPanel_Paint);
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseDown);
            // 
            // SuccesDialog
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(413, 155);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.DialogConfirm);
            this.Controls.Add(this.Succes);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SuccesDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SuccesDialog";
            this.Load += new System.EventHandler(this.SuccesDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Succes;
        private FontAwesome.Sharp.IconButton DialogConfirm;
        private System.Windows.Forms.Panel topPanel;
    }
}