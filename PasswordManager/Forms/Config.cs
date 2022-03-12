using PasswordManager.Utilities;
using System;
using System.Drawing;
using System.IO;
using System.Net;
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
                themeLabel.ForeColor = Colors.back_light;
                hash.ForeColor = Colors.back_light;
                hash.ForeColor = Colors.back_light;
                downloadedHash.ForeColor = Colors.back_light;
                themeButton.BackColor = SystemColors.Control;
                themeButton.ForeColor = Colors.back_light;
                checkHaskButton.BackColor = SystemColors.Control;
                checkHaskButton.ForeColor = Colors.back_light;
            }
            else themeButton.Text = "Enable Light Mode";
        }

        private void ThemeButton_Click(object sender, System.EventArgs e)
        {
            Properties.Settings.Default.DarkMode = !Properties.Settings.Default.DarkMode;
            Properties.Settings.Default.Save();
            Application.Restart();
        }

        private void Config_Load(object sender, System.EventArgs e)
        {
            hash.Text = Utility.GetMD5();
        }

        private void checkHaskButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string update_data = client.DownloadString("https://raw.githubusercontent.com/Akulav/OfflinePasswordManager/main/PasswordManager/Resources/hash.MD");
                    downloadedHash.Visible = true;
                    if (hash.Text != update_data) { downloadedHash.Text = "Application not original or old"; }
                    else { downloadedHash.Text = "Application is original"; }                  
                }
            }

            catch { downloadedHash.Text = "Error downloading hash"; }
            
        }
    }
}