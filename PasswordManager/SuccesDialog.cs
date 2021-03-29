using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AuditScaner
{
    public partial class SuccesDialog : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        private string form;
        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
        public SuccesDialog(string form)
        {
            InitializeComponent();
            this.form = form;
            if (form == "LoginFailUsername") { Succes.Text = "Username too short"; }
            if (form == "LoginFailPassword") { Succes.Text = "Password must be alpha-numeric\n and a length between 8 and 15"; }
        }
        private void DialogConfirm_Click(object sender, EventArgs e)
        {
                Login lg = new Login();
                lg.Show();
                Close();       
        }

    }
}
