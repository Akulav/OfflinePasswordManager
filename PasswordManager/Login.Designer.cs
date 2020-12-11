
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
            this.CreateUser = new FontAwesome.Sharp.IconButton();
            this.LoginUser = new FontAwesome.Sharp.IconButton();
            this.DeleteData = new FontAwesome.Sharp.IconButton();
            this.Minimize = new FontAwesome.Sharp.IconButton();
            this.Exit = new FontAwesome.Sharp.IconButton();
            this.topPanel = new System.Windows.Forms.Panel();
            this.Username = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.user = new System.Windows.Forms.Label();
            this.pass = new System.Windows.Forms.Label();
            this.importData = new FontAwesome.Sharp.IconButton();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreateUser
            // 
            this.CreateUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.CreateUser.ForeColor = System.Drawing.Color.Gainsboro;
            this.CreateUser.IconChar = FontAwesome.Sharp.IconChar.None;
            this.CreateUser.IconColor = System.Drawing.Color.Black;
            this.CreateUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.CreateUser.Location = new System.Drawing.Point(253, 102);
            this.CreateUser.Name = "CreateUser";
            this.CreateUser.Size = new System.Drawing.Size(178, 55);
            this.CreateUser.TabIndex = 0;
            this.CreateUser.Text = "CreateUser";
            this.CreateUser.UseVisualStyleBackColor = false;
            this.CreateUser.Click += new System.EventHandler(this.CreateUser_Click);
            // 
            // LoginUser
            // 
            this.LoginUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.LoginUser.ForeColor = System.Drawing.Color.Gainsboro;
            this.LoginUser.IconChar = FontAwesome.Sharp.IconChar.None;
            this.LoginUser.IconColor = System.Drawing.Color.Black;
            this.LoginUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.LoginUser.Location = new System.Drawing.Point(253, 102);
            this.LoginUser.Name = "LoginUser";
            this.LoginUser.Size = new System.Drawing.Size(178, 55);
            this.LoginUser.TabIndex = 1;
            this.LoginUser.Text = "LoginUser";
            this.LoginUser.UseVisualStyleBackColor = false;
            this.LoginUser.Click += new System.EventHandler(this.LoginUser_Click);
            // 
            // DeleteData
            // 
            this.DeleteData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.DeleteData.ForeColor = System.Drawing.Color.Gainsboro;
            this.DeleteData.IconChar = FontAwesome.Sharp.IconChar.None;
            this.DeleteData.IconColor = System.Drawing.Color.Black;
            this.DeleteData.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.DeleteData.Location = new System.Drawing.Point(253, 215);
            this.DeleteData.Name = "DeleteData";
            this.DeleteData.Size = new System.Drawing.Size(178, 55);
            this.DeleteData.TabIndex = 2;
            this.DeleteData.Text = "DeleteUser";
            this.DeleteData.UseVisualStyleBackColor = false;
            this.DeleteData.Click += new System.EventHandler(this.DeleteData_Click);
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
            // 
            // user
            // 
            this.user.AutoSize = true;
            this.user.ForeColor = System.Drawing.Color.Gainsboro;
            this.user.Location = new System.Drawing.Point(250, 170);
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
            // importData
            // 
            this.importData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.importData.ForeColor = System.Drawing.Color.Gainsboro;
            this.importData.IconChar = FontAwesome.Sharp.IconChar.None;
            this.importData.IconColor = System.Drawing.Color.Black;
            this.importData.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.importData.Location = new System.Drawing.Point(253, 215);
            this.importData.Name = "importData";
            this.importData.Size = new System.Drawing.Size(178, 55);
            this.importData.TabIndex = 10;
            this.importData.Text = "Import Data";
            this.importData.UseVisualStyleBackColor = false;
            this.importData.Click += new System.EventHandler(this.importData_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(689, 398);
            this.Controls.Add(this.importData);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.user);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.DeleteData);
            this.Controls.Add(this.LoginUser);
            this.Controls.Add(this.CreateUser);
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

        private FontAwesome.Sharp.IconButton CreateUser;
        private FontAwesome.Sharp.IconButton LoginUser;
        private FontAwesome.Sharp.IconButton DeleteData;
        private FontAwesome.Sharp.IconButton Minimize;
        private FontAwesome.Sharp.IconButton Exit;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label user;
        private System.Windows.Forms.Label pass;
        private FontAwesome.Sharp.IconButton importData;
    }
}