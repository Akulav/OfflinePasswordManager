using PasswordManager;
using System;
using System.IO;
using System.Windows.Forms;

namespace AuditScaner
{
    public partial class CreateData : Form
    {
        private readonly string key;
        public CreateData(string key)
        {
            InitializeComponent();
            passwordText.PasswordChar = '*';
            this.key = key;
            doneLabel.Visible = false;
        }

        private void Create_Click(object sender, EventArgs e)
        {
            string username = usernameText.Text;
            string password = passwordText.Text;
            string domain = domainText.Text;
            string filename = Crypto.GenerateRandomFileName(64);
            string filepath = "c:\\PasswordManager\\localuser" + "\\" + filename;

            using (StreamWriter writer = new StreamWriter(@filepath))
            {
                writer.Write(Crypto.Encrypt(username, key));
                writer.Write("\n");
                writer.Write(Crypto.Encrypt(password, key));
                writer.Write("\n");
                writer.Write(Crypto.Encrypt(domain, key));
            }
            Reset();
            doneLabel.Visible = true;
        }

        private void Reset()
        {
            usernameText.Text = null;
            passwordText.Text = null;
            domainText.Text = null;
        }

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Create_Click(null, null);
            }
        }
    }
}