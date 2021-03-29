using PasswordManager;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AuditScaner
{
    public partial class DeleteUserLogin : Form
    {
        private string fileLocation = "C:\\PasswordManager\\Storage";
        string curFile = @"c:\PasswordManager\user";

        public DeleteUserLogin()
        {
            InitializeComponent();
            okButton.Hide();
        }

        public Form RefToForm1 { get; set; }

        private void noButton_Click(object sender, EventArgs e)
        {
            this.RefToForm1.Show();
            this.Close();
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

        private void yesButton_Click(object sender, EventArgs e)
        {
            yesButton.Hide();
            noButton.Hide();
            this.RefToForm1.Close();
            try
            {
                deleteLabel.Text = "Secure erase started...";

                string[] fileList = Directory.GetFiles(fileLocation);
                for (int i = 0; i < fileList.Length; i++)
                {
                    string data = File.ReadAllText(fileList[i]);
                    string newData = Crypto.Encrypt(data, Crypto.GenerateRandomAlphanumericString(40));
                    File.WriteAllText(fileList[i], newData);
                    File.Encrypt(fileList[i]);
                    File.Delete(fileList[i]);
                }
            }

            catch { }
            try
            {
                File.Delete(curFile);
            }

            catch { }

            deleteLabel.Text = "Success";
            okButton.Show();

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Close();
        }
    }
}
