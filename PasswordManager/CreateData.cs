using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuditScaner
{
    public partial class CreateData : Form
    {
        private string key;
        private Form currentChildForm;
        public CreateData(string key)
        {
            InitializeComponent();
            passwordText.PasswordChar = '*';
            this.key = key;
        }

        private void create_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string username = usernameText.Text;
            string password = passwordText.Text;
            string domain = domainText.Text;
            string filename = GenerateRandomAlphanumericString(rnd.Next(0,200));
            string filepath = "c:\\PasswordManager\\Storage\\" + filename;
            using (StreamWriter writer = new StreamWriter(@filepath))
            {
                writer.Write(Encrypt(username, this.key));
                writer.Write("\n");
                writer.Write(Encrypt(password, this.key));
                writer.Write("\n");
                writer.Write(Encrypt(domain, this.key));
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

        public string GenerateRandomAlphanumericString(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];
            Random rnd = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[rnd.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;
        }

        public string Encrypt(string clearText, string EncryptionKey)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
       
    }


}