using PasswordManager;
using System;
using System.IO;
using System.Windows.Forms;

namespace AuditScaner
{
    public partial class CreateData : Form
    {
        private string key;
        public CreateData(string key)
        {
            InitializeComponent();
            passwordText.PasswordChar = '*';
            this.key = key;
            doneLabel.Visible = false;
        }

        private void create_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string username = usernameText.Text;
            string password = passwordText.Text;
            string domain = domainText.Text;
            string filename = Crypto.GenerateRandomFileName(rnd.Next(64, 256));
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

        public void Reset()
        {
            usernameText.Text = null;
            passwordText.Text = null;
            domainText.Text = null;
        }

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                create_Click(null, null);
            }
        }
    }
}