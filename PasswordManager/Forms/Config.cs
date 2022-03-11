using PasswordManager.Utilities;
using System.Drawing;
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
                themeButton.BackColor = SystemColors.Control;
                themeButton.ForeColor = Colors.back_light;
            }
            else themeButton.Text = "Enable Light Mode";
        }

        private void ThemeButton_Click(object sender, System.EventArgs e)
        {
            Properties.Settings.Default.DarkMode = !Properties.Settings.Default.DarkMode;
            Properties.Settings.Default.Save();
            Application.Restart();
        }
    }
}