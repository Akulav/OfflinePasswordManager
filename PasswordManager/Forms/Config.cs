﻿using Newtonsoft.Json;
using PasswordManager.Resources;
using PasswordManager.Utilities;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class Config : Form
    {
        Data dt = JsonConvert.DeserializeObject<Data>(File.ReadAllText(Paths.settings));
        public Config()
        {
            InitializeComponent();
            CheckTheme();
        }

        private void ThemeButton_Click(object sender, System.EventArgs e)
        {
            dt.dark = !dt.dark;
            Utility.saveSettings(dt);
            Application.Restart();
        }

        private void Config_Load(object sender, System.EventArgs e)
        {
            hash.Text = Utility.GetMD5();
            int timeValue = dt.Timeout / 1000;
            timeBox.Text = timeValue.ToString();
        }

        private void CheckHaskButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string update_data = client.DownloadString(Paths.hash);
                    downloadedHash.Visible = true;
                    downloadedHash.Text = update_data;
                }
            }

            catch { downloadedHash.Text = "Error downloading hash"; }
        }

        private void CheckTheme()
        {
            if (!dt.dark)
            {
                themeButton.Text = "Enable Dark Mode";
                Colors.ChangeTheme(Controls, this, "light");
            }

            else themeButton.Text = "Enable Light Mode";
        }

        private void TimeButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                dt.Timeout = int.Parse(timeBox.Text) * 1000;
                Utility.saveSettings(dt);
                timeLabel.Text = "Time will be applied next restart";
            }
            catch { timeLabel.Text = "Input a valid number"; }
        }
    }
}