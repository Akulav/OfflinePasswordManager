using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuditScaner
{
    public partial class SuccesDialog : Form
    {
        string form;
        public SuccesDialog(string form)
        {
            InitializeComponent();
            this.form = form;
            if (form == "LoginFailUsername") { Succes.Text = "Username too short"; }
            if (form == "LoginFailPassword") { Succes.Text = "Password must be at least 8 long"; }
        }

        private void DialogConfirm_Click(object sender, EventArgs e)
        {
            if (form == "Login")
            {
                Login lg = new Login();
                lg.Show();
                this.Close();
            }

            if (form == "LoginFailUsername")
            {
                
                Login lg = new Login();
                lg.Show();
                this.Close();
            }

            if (form == "LoginFailPassword")
            {
                Login lg = new Login();
                lg.Show();
                this.Close();
            }
        }

        private void SuccesDialog_Load(object sender, EventArgs e)
        {

        }

        private void topPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
    }
}
