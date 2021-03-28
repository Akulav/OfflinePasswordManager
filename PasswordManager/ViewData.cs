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
    public partial class ViewData : Form
    {
        private string key;
        private string username;
        private string fileLocation = "C:\\PasswordManager\\Storage\\";
        public ViewData(string key, string username)
        {
            InitializeComponent();
            this.key = key;
            this.username = username;
            getData();
        }

        private string[] getFileList()
        {
            return Directory.GetFiles(fileLocation+username);
        }

        private void getData()
        {
            var dataList = File.ReadAllLines(fileLocation+username).Count();

            TextBox[] usernames = new TextBox[dataList];
            TextBox[] passwords = new TextBox[dataList];
            Label[] serviceLabel = new Label[dataList];

            Label usernamesLabel = new Label();
            Label passwordsLabel = new Label();
            Label service = new Label();
            Label deleteLabel = new Label();

            service.Text = "Service";
            service.AutoSize = true;
            service.Font = new Font("Arial", 18);
            service.ForeColor = Color.Gainsboro;

            usernamesLabel.Font = new Font("Arial", 18);
            usernamesLabel.Text = "Username";
            usernamesLabel.AutoSize = true;
            usernamesLabel.ForeColor = Color.Gainsboro;

            passwordsLabel.Font = new Font("Arial", 18);
            passwordsLabel.Text = "Password";
            passwordsLabel.ForeColor = Color.Gainsboro;
            passwordsLabel.AutoSize = true;

            deleteLabel.Font = new Font("Arial", 18);
            deleteLabel.Text = "Click to delete data";
            deleteLabel.ForeColor = Color.Gainsboro;
            deleteLabel.AutoSize = true;

            for (int i = 0; i < dataList / 3; i++)
            {
                usernames[i] = new TextBox();
                usernames[i].Font = new Font("Arial", 16);
                usernames[i].Width = 500;
                usernames[i].AutoSize = true;

                passwords[i] = new TextBox();
                passwords[i].Font = new Font("Arial", 16);
                passwords[i].Width = 500;
                passwords[i].AutoSize = true;

                serviceLabel[i] = new Label();
                serviceLabel[i].Font = new Font("Arial", 17);
                serviceLabel[i].AutoSize = true;
                serviceLabel[i].ForeColor = Color.Gainsboro;
            }

            flowPanel.Controls.Add(service);
            flowPanel.Controls.Add(usernamesLabel);
            flowPanel.Controls.Add(passwordsLabel);
            flowPanel.Controls.Add(deleteLabel);

            for (int i = 0; i < dataList / 3; i++)
            {
                string[] data = File.ReadAllLines(fileLocation+username);

                if (i == 0) {

                    serviceLabel[i].Text = Decrypt(data[2], key);
                    flowPanel.Controls.Add(serviceLabel[i]);

                    usernames[i].Text = Decrypt(data[0], key);
                    flowPanel.Controls.Add(usernames[i]);

                    passwords[i].Text = Decrypt(data[1], key);
                    flowPanel.Controls.Add(passwords[i]);
                }

                else
                {
                    serviceLabel[i].Text = Decrypt(data[i+5], key);
                    flowPanel.Controls.Add(serviceLabel[i]);

                    usernames[i].Text = Decrypt(data[i+3], key);
                    flowPanel.Controls.Add(usernames[i]);

                    passwords[i].Text = Decrypt(data[i+4], key);
                    flowPanel.Controls.Add(passwords[i]);
                }

                Button delete = new Button();
                delete.Text = i.ToString();
                delete.ForeColor = Color.Gainsboro;
                delete.Font = new Font("Arial", 16);
                delete.Width = 500;
                delete.AutoSize = true;
                delete.Click += new EventHandler(delegate (Object o, EventArgs a)
                {
                    int index = int.Parse(delete.Text);
                    string[] list = getFileList();
                    try
                    { 
                            string oldData = File.ReadAllText(list[index]);
                            string newData = Encrypt(oldData, GenerateRandomAlphanumericString());
                            File.WriteAllText(list[index], newData);
                            File.Delete(list[index]); 
                    }

                    catch { }
                    this.Controls.Clear();
                    this.InitializeComponent();
                    getData();
                });
                flowPanel.Controls.Add(delete);
            }

        }

        public string Decrypt(string cipherText, string EncryptionKey)
        {
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        public string GenerateRandomAlphanumericString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[40];
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