using PasswordManager;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AuditScaner
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
            okButton.Hide();
        }

        public Form RefToForm1 { get; set; }

        private void NoButton_Click(object sender, EventArgs e)
        {
            RefToForm1.Show();
            Close();
        }

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            yesButton.Hide();
            noButton.Hide();
            RefToForm1.Close();
            Crypto.Erase(Utilities.fileLocation);
            deleteLabel.Text = "Success";
            okButton.Show();

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            Close();
        }
    }
}
