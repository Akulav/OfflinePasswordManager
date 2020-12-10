
namespace AuditScaner
{
    partial class CreateData
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
            this.create = new FontAwesome.Sharp.IconButton();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.usernameText = new System.Windows.Forms.TextBox();
            this.user = new System.Windows.Forms.Label();
            this.pass = new System.Windows.Forms.Label();
            this.domainText = new System.Windows.Forms.TextBox();
            this.domain = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // create
            // 
            this.create.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.create.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.create.ForeColor = System.Drawing.Color.Gainsboro;
            this.create.IconChar = FontAwesome.Sharp.IconChar.None;
            this.create.IconColor = System.Drawing.Color.Black;
            this.create.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.create.Location = new System.Drawing.Point(355, 298);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(192, 86);
            this.create.TabIndex = 0;
            this.create.Text = "Add account";
            this.create.UseVisualStyleBackColor = false;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // passwordText
            // 
            this.passwordText.Location = new System.Drawing.Point(425, 246);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(119, 20);
            this.passwordText.TabIndex = 1;
            // 
            // usernameText
            // 
            this.usernameText.Location = new System.Drawing.Point(425, 220);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(119, 20);
            this.usernameText.TabIndex = 2;
            // 
            // user
            // 
            this.user.AutoSize = true;
            this.user.ForeColor = System.Drawing.Color.Gainsboro;
            this.user.Location = new System.Drawing.Point(352, 226);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(55, 13);
            this.user.TabIndex = 3;
            this.user.Text = "Username";
            // 
            // pass
            // 
            this.pass.AutoSize = true;
            this.pass.ForeColor = System.Drawing.Color.Gainsboro;
            this.pass.Location = new System.Drawing.Point(352, 249);
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(53, 13);
            this.pass.TabIndex = 4;
            this.pass.Text = "Password";
            // 
            // domainText
            // 
            this.domainText.Location = new System.Drawing.Point(425, 272);
            this.domainText.Name = "domainText";
            this.domainText.Size = new System.Drawing.Size(119, 20);
            this.domainText.TabIndex = 5;
            // 
            // domain
            // 
            this.domain.AutoSize = true;
            this.domain.ForeColor = System.Drawing.Color.Gainsboro;
            this.domain.Location = new System.Drawing.Point(352, 275);
            this.domain.Name = "domain";
            this.domain.Size = new System.Drawing.Size(43, 13);
            this.domain.TabIndex = 6;
            this.domain.Text = "Service";
            // 
            // CreateData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(908, 582);
            this.Controls.Add(this.domain);
            this.Controls.Add(this.domainText);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.user);
            this.Controls.Add(this.usernameText);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.create);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreateData";
            this.Text = "CreateData";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton create;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.TextBox usernameText;
        private System.Windows.Forms.Label user;
        private System.Windows.Forms.Label pass;
        private System.Windows.Forms.TextBox domainText;
        private System.Windows.Forms.Label domain;
    }
}