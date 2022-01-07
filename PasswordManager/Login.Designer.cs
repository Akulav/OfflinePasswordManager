
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.Username = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.passLabel = new System.Windows.Forms.Label();
            this.statusText = new System.Windows.Forms.Label();
            this.PIMLabel = new System.Windows.Forms.Label();
            this.PIMBox = new System.Windows.Forms.TextBox();
            this.leftpanel = new System.Windows.Forms.Panel();
            this.leftTopPanel = new System.Windows.Forms.Panel();
            this.devLabel = new System.Windows.Forms.Label();
            this.leftlabel = new System.Windows.Forms.Label();
            this.leftPictureBox = new System.Windows.Forms.PictureBox();
            this.rightpanel = new System.Windows.Forms.Panel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.CloseButton = new System.Windows.Forms.Button();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.UserButton = new FontAwesome.Sharp.IconButton();
            this.ConfigButton = new FontAwesome.Sharp.IconButton();
            this.themChange = new FontAwesome.Sharp.IconButton();
            this.leftpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftPictureBox)).BeginInit();
            this.rightpanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(109, 217);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(290, 20);
            this.Username.TabIndex = 6;
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(109, 243);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(290, 20);
            this.Password.TabIndex = 7;
            this.Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Password_KeyDown);
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.userLabel.Location = new System.Drawing.Point(20, 215);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(83, 20);
            this.userLabel.TabIndex = 8;
            this.userLabel.Text = "Username";
            // 
            // passLabel
            // 
            this.passLabel.AutoSize = true;
            this.passLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.passLabel.Location = new System.Drawing.Point(20, 241);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(78, 20);
            this.passLabel.TabIndex = 9;
            this.passLabel.Text = "Password";
            // 
            // statusText
            // 
            this.statusText.AutoEllipsis = true;
            this.statusText.AutoSize = true;
            this.statusText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.statusText.Location = new System.Drawing.Point(21, 357);
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(0, 13);
            this.statusText.TabIndex = 11;
            // 
            // PIMLabel
            // 
            this.PIMLabel.AutoSize = true;
            this.PIMLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PIMLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.PIMLabel.Location = new System.Drawing.Point(20, 267);
            this.PIMLabel.Name = "PIMLabel";
            this.PIMLabel.Size = new System.Drawing.Size(71, 20);
            this.PIMLabel.TabIndex = 12;
            this.PIMLabel.Text = "PIM (Nr.)";
            // 
            // PIMBox
            // 
            this.PIMBox.Location = new System.Drawing.Point(109, 269);
            this.PIMBox.Name = "PIMBox";
            this.PIMBox.Size = new System.Drawing.Size(290, 20);
            this.PIMBox.TabIndex = 13;
            this.PIMBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Password_KeyDown);
            // 
            // leftpanel
            // 
            this.leftpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.leftpanel.Controls.Add(this.leftTopPanel);
            this.leftpanel.Controls.Add(this.devLabel);
            this.leftpanel.Controls.Add(this.leftlabel);
            this.leftpanel.Controls.Add(this.leftPictureBox);
            this.leftpanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftpanel.Location = new System.Drawing.Point(0, 0);
            this.leftpanel.Name = "leftpanel";
            this.leftpanel.Size = new System.Drawing.Size(262, 398);
            this.leftpanel.TabIndex = 16;
            // 
            // leftTopPanel
            // 
            this.leftTopPanel.BackColor = System.Drawing.Color.Transparent;
            this.leftTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.leftTopPanel.Location = new System.Drawing.Point(0, 0);
            this.leftTopPanel.Name = "leftTopPanel";
            this.leftTopPanel.Size = new System.Drawing.Size(262, 42);
            this.leftTopPanel.TabIndex = 20;
            this.leftTopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.leftTopPanel_MouseDown);
            // 
            // devLabel
            // 
            this.devLabel.AutoSize = true;
            this.devLabel.Font = new System.Drawing.Font("Yu Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.devLabel.ForeColor = System.Drawing.Color.White;
            this.devLabel.Location = new System.Drawing.Point(147, 375);
            this.devLabel.Name = "devLabel";
            this.devLabel.Size = new System.Drawing.Size(109, 14);
            this.devLabel.TabIndex = 17;
            this.devLabel.Text = "Developed by Akulav";
            // 
            // leftlabel
            // 
            this.leftlabel.AutoSize = true;
            this.leftlabel.Font = new System.Drawing.Font("Yu Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftlabel.ForeColor = System.Drawing.Color.White;
            this.leftlabel.Location = new System.Drawing.Point(25, 177);
            this.leftlabel.Name = "leftlabel";
            this.leftlabel.Size = new System.Drawing.Size(218, 27);
            this.leftlabel.TabIndex = 16;
            this.leftlabel.Text = "Welcome to SeePass";
            // 
            // leftPictureBox
            // 
            this.leftPictureBox.Image = global::PasswordManager.Properties.Resources.leftimage;
            this.leftPictureBox.Location = new System.Drawing.Point(72, 48);
            this.leftPictureBox.Name = "leftPictureBox";
            this.leftPictureBox.Size = new System.Drawing.Size(119, 133);
            this.leftPictureBox.TabIndex = 0;
            this.leftPictureBox.TabStop = false;
            // 
            // rightpanel
            // 
            this.rightpanel.BackColor = System.Drawing.SystemColors.Control;
            this.rightpanel.Controls.Add(this.topPanel);
            this.rightpanel.Controls.Add(this.welcomeLabel);
            this.rightpanel.Controls.Add(this.statusText);
            this.rightpanel.Controls.Add(this.UserButton);
            this.rightpanel.Controls.Add(this.ConfigButton);
            this.rightpanel.Controls.Add(this.passLabel);
            this.rightpanel.Controls.Add(this.Username);
            this.rightpanel.Controls.Add(this.userLabel);
            this.rightpanel.Controls.Add(this.PIMBox);
            this.rightpanel.Controls.Add(this.PIMLabel);
            this.rightpanel.Controls.Add(this.Password);
            this.rightpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightpanel.Location = new System.Drawing.Point(262, 0);
            this.rightpanel.Name = "rightpanel";
            this.rightpanel.Size = new System.Drawing.Size(427, 398);
            this.rightpanel.TabIndex = 17;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.Transparent;
            this.topPanel.Controls.Add(this.themChange);
            this.topPanel.Controls.Add(this.CloseButton);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(427, 42);
            this.topPanel.TabIndex = 19;
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseDown);
            // 
            // CloseButton
            // 
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseButton.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.CloseButton.Location = new System.Drawing.Point(387, -1);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(40, 40);
            this.CloseButton.TabIndex = 16;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Yu Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.welcomeLabel.Location = new System.Drawing.Point(19, 72);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(229, 27);
            this.welcomeLabel.TabIndex = 18;
            this.welcomeLabel.Text = "WELCOME_MESSAGE";
            // 
            // UserButton
            // 
            this.UserButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.UserButton.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.UserButton.IconChar = FontAwesome.Sharp.IconChar.None;
            this.UserButton.IconColor = System.Drawing.Color.Black;
            this.UserButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.UserButton.Location = new System.Drawing.Point(24, 299);
            this.UserButton.Name = "UserButton";
            this.UserButton.Size = new System.Drawing.Size(178, 55);
            this.UserButton.TabIndex = 0;
            this.UserButton.Text = "BUTTON";
            this.UserButton.UseVisualStyleBackColor = false;
            this.UserButton.Click += new System.EventHandler(this.CreateUser_Click);
            // 
            // ConfigButton
            // 
            this.ConfigButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.ConfigButton.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.ConfigButton.IconChar = FontAwesome.Sharp.IconChar.None;
            this.ConfigButton.IconColor = System.Drawing.Color.Black;
            this.ConfigButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ConfigButton.Location = new System.Drawing.Point(221, 299);
            this.ConfigButton.Name = "ConfigButton";
            this.ConfigButton.Size = new System.Drawing.Size(178, 55);
            this.ConfigButton.TabIndex = 15;
            this.ConfigButton.Text = "BUTTON";
            this.ConfigButton.UseVisualStyleBackColor = false;
            this.ConfigButton.Click += new System.EventHandler(this.ConfigButton_Click);
            // 
            // themChange
            // 
            this.themChange.BackColor = System.Drawing.Color.Transparent;
            this.themChange.IconChar = FontAwesome.Sharp.IconChar.Moon;
            this.themChange.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.themChange.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.themChange.Location = new System.Drawing.Point(344, -1);
            this.themChange.Name = "themChange";
            this.themChange.Size = new System.Drawing.Size(40, 40);
            this.themChange.TabIndex = 17;
            this.themChange.Text = "X";
            this.themChange.UseVisualStyleBackColor = false;
            this.themChange.Click += new System.EventHandler(this.themChange_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(689, 398);
            this.Controls.Add(this.rightpanel);
            this.Controls.Add(this.leftpanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Login_Load);
            this.leftpanel.ResumeLayout(false);
            this.leftpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftPictureBox)).EndInit();
            this.rightpanel.ResumeLayout(false);
            this.rightpanel.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton UserButton;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.Label statusText;
        private System.Windows.Forms.Label PIMLabel;
        private System.Windows.Forms.TextBox PIMBox;
        private FontAwesome.Sharp.IconButton ConfigButton;
        private System.Windows.Forms.Panel leftpanel;
        private System.Windows.Forms.PictureBox leftPictureBox;
        private System.Windows.Forms.Panel rightpanel;
        private System.Windows.Forms.Label devLabel;
        private System.Windows.Forms.Label leftlabel;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Panel leftTopPanel;
        private System.Windows.Forms.Panel topPanel;
        private FontAwesome.Sharp.IconButton themChange;
    }
}