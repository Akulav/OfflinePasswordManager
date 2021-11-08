
namespace AuditScaner
{
    partial class Login
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
            this.UserButton = new FontAwesome.Sharp.IconButton();
            this.Minimize = new FontAwesome.Sharp.IconButton();
            this.Exit = new FontAwesome.Sharp.IconButton();
            this.topPanel = new System.Windows.Forms.Panel();
            this.Username = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.user = new System.Windows.Forms.Label();
            this.pass = new System.Windows.Forms.Label();
            this.statusText = new System.Windows.Forms.Label();
            this.PIMLabel = new System.Windows.Forms.Label();
            this.PIMBox = new System.Windows.Forms.TextBox();
            this.CLauseLabel = new System.Windows.Forms.Label();
            this.ConfigButton = new FontAwesome.Sharp.IconButton();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserButton
            // 
            this.UserButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.UserButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.UserButton.IconChar = FontAwesome.Sharp.IconChar.None;
            this.UserButton.IconColor = System.Drawing.Color.Black;
            this.UserButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.UserButton.Location = new System.Drawing.Point(253, 102);
            this.UserButton.Name = "UserButton";
            this.UserButton.Size = new System.Drawing.Size(178, 55);
            this.UserButton.TabIndex = 0;
            this.UserButton.Text = "BUTTON";
            this.UserButton.UseVisualStyleBackColor = false;
            this.UserButton.Click += new System.EventHandler(this.CreateUser_Click);
            // 
            // Minimize
            // 
            this.Minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Minimize.ForeColor = System.Drawing.Color.Gainsboro;
            this.Minimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.Minimize.IconColor = System.Drawing.Color.Gainsboro;
            this.Minimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Minimize.Location = new System.Drawing.Point(631, 3);
            this.Minimize.Name = "Minimize";
            this.Minimize.Size = new System.Drawing.Size(26, 23);
            this.Minimize.TabIndex = 3;
            this.Minimize.UseVisualStyleBackColor = true;
            this.Minimize.Click += new System.EventHandler(this.Minimize_Click);
            // 
            // Exit
            // 
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.ForeColor = System.Drawing.Color.Gainsboro;
            this.Exit.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.Exit.IconColor = System.Drawing.Color.Gainsboro;
            this.Exit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Exit.Location = new System.Drawing.Point(663, 3);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(26, 23);
            this.Exit.TabIndex = 4;
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.topPanel.Controls.Add(this.Exit);
            this.topPanel.Controls.Add(this.Minimize);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(689, 33);
            this.topPanel.TabIndex = 5;
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseDown);
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(311, 163);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(120, 20);
            this.Username.TabIndex = 6;
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(311, 189);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(120, 20);
            this.Password.TabIndex = 7;
            this.Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Password_KeyDown);
            // 
            // user
            // 
            this.user.AutoSize = true;
            this.user.ForeColor = System.Drawing.Color.Gainsboro;
            this.user.Location = new System.Drawing.Point(252, 166);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(55, 13);
            this.user.TabIndex = 8;
            this.user.Text = "Username";
            // 
            // pass
            // 
            this.pass.AutoSize = true;
            this.pass.ForeColor = System.Drawing.Color.Gainsboro;
            this.pass.Location = new System.Drawing.Point(252, 192);
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(53, 13);
            this.pass.TabIndex = 9;
            this.pass.Text = "Password";
            // 
            // statusText
            // 
            this.statusText.AutoSize = true;
            this.statusText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusText.ForeColor = System.Drawing.Color.Gainsboro;
            this.statusText.Location = new System.Drawing.Point(252, 299);
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(0, 15);
            this.statusText.TabIndex = 11;
            // 
            // PIMLabel
            // 
            this.PIMLabel.AutoSize = true;
            this.PIMLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.PIMLabel.Location = new System.Drawing.Point(252, 218);
            this.PIMLabel.Name = "PIMLabel";
            this.PIMLabel.Size = new System.Drawing.Size(26, 13);
            this.PIMLabel.TabIndex = 12;
            this.PIMLabel.Text = "PIM";
            // 
            // PIMBox
            // 
            this.PIMBox.Location = new System.Drawing.Point(311, 215);
            this.PIMBox.Name = "PIMBox";
            this.PIMBox.Size = new System.Drawing.Size(120, 20);
            this.PIMBox.TabIndex = 13;
            this.PIMBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Password_KeyDown);
            // 
            // CLauseLabel
            // 
            this.CLauseLabel.AutoSize = true;
            this.CLauseLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CLauseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CLauseLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.CLauseLabel.Location = new System.Drawing.Point(0, 378);
            this.CLauseLabel.Name = "CLauseLabel";
            this.CLauseLabel.Size = new System.Drawing.Size(424, 20);
            this.CLauseLabel.TabIndex = 14;
            this.CLauseLabel.Text = "*An invalid PIM will let you  login, but data will be unviewable";
            this.CLauseLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // ConfigButton
            // 
            this.ConfigButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.ConfigButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.ConfigButton.IconChar = FontAwesome.Sharp.IconChar.None;
            this.ConfigButton.IconColor = System.Drawing.Color.Black;
            this.ConfigButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ConfigButton.Location = new System.Drawing.Point(253, 241);
            this.ConfigButton.Name = "ConfigButton";
            this.ConfigButton.Size = new System.Drawing.Size(178, 55);
            this.ConfigButton.TabIndex = 15;
            this.ConfigButton.Text = "BUTTON";
            this.ConfigButton.UseVisualStyleBackColor = false;
            this.ConfigButton.Click += new System.EventHandler(this.ConfigButton_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(689, 398);
            this.Controls.Add(this.ConfigButton);
            this.Controls.Add(this.CLauseLabel);
            this.Controls.Add(this.PIMBox);
            this.Controls.Add(this.PIMLabel);
            this.Controls.Add(this.statusText);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.user);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.UserButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Login_Load);
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton UserButton;
        private FontAwesome.Sharp.IconButton Minimize;
        private FontAwesome.Sharp.IconButton Exit;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label user;
        private System.Windows.Forms.Label pass;
        private System.Windows.Forms.Label statusText;
        private System.Windows.Forms.Label PIMLabel;
        private System.Windows.Forms.TextBox PIMBox;
        private System.Windows.Forms.Label CLauseLabel;
        private FontAwesome.Sharp.IconButton ConfigButton;
    }
}