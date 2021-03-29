using System;
using System.IO;
using System.Windows.Forms;
using PasswordManager;

namespace AuditScaner
{
    public partial class CreateData : Form
    {
        private string key;
        private string username;
        private Form currentChildForm;
        public CreateData(string key, string username)
        {
            InitializeComponent();
            passwordText.PasswordChar = '*';
            this.key = key;
            this.username = username;
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
            OpenChildForm(new SuccessWindow("CreateData"));
        }

        private void OpenChildForm(Form childForm)
        {
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            Controls.Add(childForm);
            childForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void Reset()
        {
            usernameText.Text = null;
            passwordText.Text = null;
            domainText.Text = null;
        }
       
    }


}