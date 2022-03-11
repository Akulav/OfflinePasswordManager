using PasswordManager;
using PasswordManager.Utilities;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SeePass
{
    public partial class DeleteUserLogin : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        public DeleteUserLogin()
        {
            InitializeComponent();
            CheckTheme();
        }

        private void CheckTheme()
        {
            if (PasswordManager.Properties.Settings.Default.DarkMode)
            {
                topPanel.BackColor = Colors.back_darker;
                deleteLabel.BackColor = Colors.back_dark;
                deleteLabel.ForeColor = Color.Gainsboro;
                noButton.BackColor = Colors.back_dark;
                yesButton.BackColor = Colors.back_dark;
                noButton.ForeColor = Color.Gainsboro;
                yesButton.ForeColor = Color.Gainsboro;
                BackColor = Colors.back_dark;
            }
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            Close();
        }

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            Crypto.Erase();
            Application.Restart();
        }
    }
}
