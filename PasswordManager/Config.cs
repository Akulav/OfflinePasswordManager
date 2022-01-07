﻿using System.Drawing;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
            CheckTheme();
        }

        private void CheckTheme()
        {
            if (!Properties.Settings.Default.DarkMode)
            {
                themeButton.Text = "Enable Dark Mode";
                BackColor = SystemColors.Control;
                label1.ForeColor = Color.FromArgb(41, 128, 185);
                label2.ForeColor = Color.FromArgb(41, 128, 185);
                label0.ForeColor = Color.FromArgb(41, 128, 185);
                themeButton.BackColor = SystemColors.Control;
                themeButton.ForeColor = Color.FromArgb(41, 128, 185);
            }

            else themeButton.Text = "Enable Light Mode";
        }

        private void themeButton_Click(object sender, System.EventArgs e)
        {
            Properties.Settings.Default.DarkMode = !Properties.Settings.Default.DarkMode;
            Properties.Settings.Default.Save();
            Application.Restart();
        }
    }
}
