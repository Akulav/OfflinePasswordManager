
namespace AuditScaner
{
    partial class ViewData
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
            this.flowPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // flowPanel
            // 
            this.flowPanel.AutoScroll = true;
            this.flowPanel.ColumnCount = 2;
            this.flowPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.flowPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.flowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanel.Location = new System.Drawing.Point(0, 0);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.RowCount = 2;
            this.flowPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.flowPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.flowPanel.Size = new System.Drawing.Size(924, 621);
            this.flowPanel.TabIndex = 0;
            // 
            // ViewData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(924, 621);
            this.Controls.Add(this.flowPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewData";
            this.Text = "ViewData";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel flowPanel;
    }
}