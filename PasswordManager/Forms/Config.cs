using PasswordManager.Utilities;
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
            if (!Properties.Settings.Default.DarkMode)
            {
                themeButton.Text = "Enable Dark Mode";
                Colors.ChangeTheme(Controls, this, "light");
            }

            else themeButton.Text = "Enable Light Mode";
        }


    }
}