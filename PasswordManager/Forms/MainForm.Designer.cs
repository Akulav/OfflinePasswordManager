namespace SeePass
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.ExitButton = new FontAwesome.Sharp.IconButton();
            this.labelEstheticLine = new System.Windows.Forms.Label();
            this.Settings = new FontAwesome.Sharp.IconButton();
            this.ViewData = new FontAwesome.Sharp.IconButton();
            this.ExportTools = new FontAwesome.Sharp.IconButton();
            this.CreateData = new FontAwesome.Sharp.IconButton();
            this.Dashboard = new FontAwesome.Sharp.IconButton();
            this.PanelLogo = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.Minimize = new FontAwesome.Sharp.IconButton();
            this.Exit = new FontAwesome.Sharp.IconButton();
            this.labelTitleOfChildForm = new System.Windows.Forms.Label();
            this.iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.winVer = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.clock = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.MenuPanel.SuspendLayout();
            this.PanelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).BeginInit();
            this.panelDesktop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.MenuPanel.Controls.Add(this.ExitButton);
            this.MenuPanel.Controls.Add(this.labelEstheticLine);
            this.MenuPanel.Controls.Add(this.Settings);
            this.MenuPanel.Controls.Add(this.ViewData);
            this.MenuPanel.Controls.Add(this.ExportTools);
            this.MenuPanel.Controls.Add(this.CreateData);
            this.MenuPanel.Controls.Add(this.Dashboard);
            this.MenuPanel.Controls.Add(this.PanelLogo);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(220, 696);
            this.MenuPanel.TabIndex = 0;
            // 
            // ExitButton
            // 
            this.ExitButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.ExitButton.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.ExitButton.IconColor = System.Drawing.Color.Gainsboro;
            this.ExitButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ExitButton.IconSize = 32;
            this.ExitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExitButton.Location = new System.Drawing.Point(0, 453);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.ExitButton.Size = new System.Drawing.Size(220, 60);
            this.ExitButton.TabIndex = 7;
            this.ExitButton.Text = "EXIT";
            this.ExitButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // labelEstheticLine
            // 
            this.labelEstheticLine.AutoSize = true;
            this.labelEstheticLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelEstheticLine.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelEstheticLine.Location = new System.Drawing.Point(0, 440);
            this.labelEstheticLine.Name = "labelEstheticLine";
            this.labelEstheticLine.Size = new System.Drawing.Size(283, 13);
            this.labelEstheticLine.TabIndex = 6;
            this.labelEstheticLine.Text = "______________________________________________";
            // 
            // Settings
            // 
            this.Settings.Dock = System.Windows.Forms.DockStyle.Top;
            this.Settings.FlatAppearance.BorderSize = 0;
            this.Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Settings.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Settings.ForeColor = System.Drawing.Color.Gainsboro;
            this.Settings.IconChar = FontAwesome.Sharp.IconChar.UserCog;
            this.Settings.IconColor = System.Drawing.Color.Gainsboro;
            this.Settings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Settings.IconSize = 32;
            this.Settings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Settings.Location = new System.Drawing.Point(0, 380);
            this.Settings.Name = "Settings";
            this.Settings.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.Settings.Size = new System.Drawing.Size(220, 60);
            this.Settings.TabIndex = 5;
            this.Settings.Text = "Configuration";
            this.Settings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Settings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Settings.UseVisualStyleBackColor = true;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // ViewData
            // 
            this.ViewData.Dock = System.Windows.Forms.DockStyle.Top;
            this.ViewData.FlatAppearance.BorderSize = 0;
            this.ViewData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ViewData.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewData.ForeColor = System.Drawing.Color.Gainsboro;
            this.ViewData.IconChar = FontAwesome.Sharp.IconChar.ShieldVirus;
            this.ViewData.IconColor = System.Drawing.Color.Gainsboro;
            this.ViewData.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ViewData.IconSize = 32;
            this.ViewData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ViewData.Location = new System.Drawing.Point(0, 320);
            this.ViewData.Name = "ViewData";
            this.ViewData.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.ViewData.Size = new System.Drawing.Size(220, 60);
            this.ViewData.TabIndex = 4;
            this.ViewData.Text = "View Data";
            this.ViewData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ViewData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ViewData.UseVisualStyleBackColor = true;
            this.ViewData.Click += new System.EventHandler(this.ViewData_Click);
            // 
            // ExportTools
            // 
            this.ExportTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExportTools.FlatAppearance.BorderSize = 0;
            this.ExportTools.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExportTools.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportTools.ForeColor = System.Drawing.Color.Gainsboro;
            this.ExportTools.IconChar = FontAwesome.Sharp.IconChar.FileExport;
            this.ExportTools.IconColor = System.Drawing.Color.Gainsboro;
            this.ExportTools.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ExportTools.IconSize = 32;
            this.ExportTools.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExportTools.Location = new System.Drawing.Point(0, 260);
            this.ExportTools.Name = "ExportTools";
            this.ExportTools.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.ExportTools.Size = new System.Drawing.Size(220, 60);
            this.ExportTools.TabIndex = 3;
            this.ExportTools.Text = "Export Data";
            this.ExportTools.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExportTools.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExportTools.UseVisualStyleBackColor = true;
            this.ExportTools.Click += new System.EventHandler(this.ExportTools_Click);
            // 
            // CreateData
            // 
            this.CreateData.Dock = System.Windows.Forms.DockStyle.Top;
            this.CreateData.FlatAppearance.BorderSize = 0;
            this.CreateData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateData.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateData.ForeColor = System.Drawing.Color.Gainsboro;
            this.CreateData.IconChar = FontAwesome.Sharp.IconChar.ChartBar;
            this.CreateData.IconColor = System.Drawing.Color.Gainsboro;
            this.CreateData.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.CreateData.IconSize = 32;
            this.CreateData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreateData.Location = new System.Drawing.Point(0, 200);
            this.CreateData.Name = "CreateData";
            this.CreateData.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.CreateData.Size = new System.Drawing.Size(220, 60);
            this.CreateData.TabIndex = 2;
            this.CreateData.Text = "Create Data";
            this.CreateData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreateData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CreateData.UseVisualStyleBackColor = true;
            this.CreateData.Click += new System.EventHandler(this.CreateData_Click);
            // 
            // Dashboard
            // 
            this.Dashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.Dashboard.FlatAppearance.BorderSize = 0;
            this.Dashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Dashboard.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dashboard.ForeColor = System.Drawing.Color.Gainsboro;
            this.Dashboard.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.Dashboard.IconColor = System.Drawing.Color.Gainsboro;
            this.Dashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Dashboard.IconSize = 32;
            this.Dashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Dashboard.Location = new System.Drawing.Point(0, 140);
            this.Dashboard.Name = "Dashboard";
            this.Dashboard.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.Dashboard.Size = new System.Drawing.Size(220, 60);
            this.Dashboard.TabIndex = 1;
            this.Dashboard.Text = "Dashboard";
            this.Dashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Dashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Dashboard.UseVisualStyleBackColor = true;
            this.Dashboard.Click += new System.EventHandler(this.Dashboard_Click);
            // 
            // PanelLogo
            // 
            this.PanelLogo.Controls.Add(this.btnHome);
            this.PanelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelLogo.Location = new System.Drawing.Point(0, 0);
            this.PanelLogo.Name = "PanelLogo";
            this.PanelLogo.Size = new System.Drawing.Size(220, 140);
            this.PanelLogo.TabIndex = 1;
            // 
            // btnHome
            // 
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(35, 27);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(145, 92);
            this.btnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnHome.TabIndex = 1;
            this.btnHome.TabStop = false;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.panelTitleBar.Controls.Add(this.Minimize);
            this.panelTitleBar.Controls.Add(this.Exit);
            this.panelTitleBar.Controls.Add(this.labelTitleOfChildForm);
            this.panelTitleBar.Controls.Add(this.iconCurrentChildForm);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(220, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(924, 75);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTitleBar_MouseDown);
            // 
            // Minimize
            // 
            this.Minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Minimize.FlatAppearance.BorderSize = 0;
            this.Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Minimize.ForeColor = System.Drawing.Color.Gainsboro;
            this.Minimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.Minimize.IconColor = System.Drawing.Color.Gainsboro;
            this.Minimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Minimize.IconSize = 32;
            this.Minimize.Location = new System.Drawing.Point(874, 3);
            this.Minimize.Name = "Minimize";
            this.Minimize.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.Minimize.Size = new System.Drawing.Size(22, 21);
            this.Minimize.TabIndex = 8;
            this.Minimize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Minimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Minimize.UseVisualStyleBackColor = true;
            this.Minimize.Click += new System.EventHandler(this.Minimize_Click);
            // 
            // Exit
            // 
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit.FlatAppearance.BorderSize = 0;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.ForeColor = System.Drawing.Color.Gainsboro;
            this.Exit.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.Exit.IconColor = System.Drawing.Color.Gainsboro;
            this.Exit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Exit.IconSize = 32;
            this.Exit.Location = new System.Drawing.Point(902, 3);
            this.Exit.Name = "Exit";
            this.Exit.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.Exit.Size = new System.Drawing.Size(22, 21);
            this.Exit.TabIndex = 6;
            this.Exit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // labelTitleOfChildForm
            // 
            this.labelTitleOfChildForm.AutoSize = true;
            this.labelTitleOfChildForm.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleOfChildForm.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelTitleOfChildForm.Location = new System.Drawing.Point(44, 36);
            this.labelTitleOfChildForm.Name = "labelTitleOfChildForm";
            this.labelTitleOfChildForm.Size = new System.Drawing.Size(36, 14);
            this.labelTitleOfChildForm.TabIndex = 1;
            this.labelTitleOfChildForm.Text = "Home";
            // 
            // iconCurrentChildForm
            // 
            this.iconCurrentChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.iconCurrentChildForm.ForeColor = System.Drawing.Color.MediumPurple;
            this.iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.iconCurrentChildForm.IconColor = System.Drawing.Color.MediumPurple;
            this.iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCurrentChildForm.Location = new System.Drawing.Point(6, 27);
            this.iconCurrentChildForm.Name = "iconCurrentChildForm";
            this.iconCurrentChildForm.Size = new System.Drawing.Size(32, 32);
            this.iconCurrentChildForm.TabIndex = 0;
            this.iconCurrentChildForm.TabStop = false;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panelDesktop.Controls.Add(this.winVer);
            this.panelDesktop.Controls.Add(this.pictureBox1);
            this.panelDesktop.Controls.Add(this.clock);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDesktop.Location = new System.Drawing.Point(220, 75);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(924, 621);
            this.panelDesktop.TabIndex = 3;
            // 
            // winVer
            // 
            this.winVer.AutoSize = true;
            this.winVer.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winVer.ForeColor = System.Drawing.Color.Gainsboro;
            this.winVer.Location = new System.Drawing.Point(417, 478);
            this.winVer.Name = "winVer";
            this.winVer.Size = new System.Drawing.Size(115, 21);
            this.winVer.TabIndex = 7;
            this.winVer.Text = "PLACEHOLDER";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(361, 245);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(265, 230);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // clock
            // 
            this.clock.Font = new System.Drawing.Font("Yu Gothic", 63.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clock.ForeColor = System.Drawing.Color.Gainsboro;
            this.clock.Location = new System.Drawing.Point(305, 142);
            this.clock.Name = "clock";
            this.clock.Size = new System.Drawing.Size(681, 97);
            this.clock.TabIndex = 6;
            this.clock.Text = "00:00:00";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 696);
            this.ControlBox = false;
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.MenuPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SeePass";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
            this.MenuPanel.ResumeLayout(false);
            this.MenuPanel.PerformLayout();
            this.PanelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).EndInit();
            this.panelDesktop.ResumeLayout(false);
            this.panelDesktop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MenuPanel;
        private FontAwesome.Sharp.IconButton Settings;
        private FontAwesome.Sharp.IconButton ViewData;
        private FontAwesome.Sharp.IconButton ExportTools;
        private FontAwesome.Sharp.IconButton CreateData;
        private FontAwesome.Sharp.IconButton Dashboard;
        private System.Windows.Forms.Panel PanelLogo;
        private System.Windows.Forms.PictureBox btnHome;
        private System.Windows.Forms.Panel panelTitleBar;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private System.Windows.Forms.Label labelTitleOfChildForm;
        private FontAwesome.Sharp.IconButton Exit;
        private FontAwesome.Sharp.IconButton Minimize;
        private FontAwesome.Sharp.IconButton ExitButton;
        private System.Windows.Forms.Label labelEstheticLine;
        public System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Label clock;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label winVer;
        private System.Windows.Forms.Timer timer;
    }
}