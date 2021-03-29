using PasswordManager;
using System;
using System.IO;
using System.Windows.Forms;

namespace AuditScaner
{
    public partial class CreateData : Form
    {
        private string key;
        private string username;
        public CreateData(string key, string username)
        {
            InitializeComponent();
            passwordText.PasswordChar = '*';
            this.key = key;
            this.username = username;
            doneLabel.Visible = false;
        }

        private void create_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string username = usernameText.Text;
            string password = passwordText.Text;
            string domain = domainText.Text;
            string filename = Crypto.GenerateRandomAlphanumericString(rnd.Next(0, 256));
            string filepath = "c:\\PasswordManager\\" + this.username + "\\" + filename;

            using (StreamWriter writer = new StreamWriter(@filepath))
            {
                writer.Write(Crypto.Encrypt(username, this.key));
                writer.Write("\n");
                writer.Write(Crypto.Encrypt(password, this.key));
                writer.Write("\n");
                writer.Write(Crypto.Encrypt(domain, this.key));
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
    }
}