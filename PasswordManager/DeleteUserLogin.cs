using PasswordManager;
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
                topPanel.BackColor = Color.FromArgb(31, 30, 68);
                deleteLabel.BackColor = Color.FromArgb(34, 33, 74);
                deleteLabel.ForeColor = Color.Gainsboro;
                noButton.BackColor = Color.FromArgb(34, 33, 74);
                yesButton.BackColor = Color.FromArgb(34, 33, 74);
                noButton.ForeColor = Color.Gainsboro;
                yesButton.ForeColor = Color.Gainsboro;
                BackColor = Color.FromArgb(34, 33, 74);
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
