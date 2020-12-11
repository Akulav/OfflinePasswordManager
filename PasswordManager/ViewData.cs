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
        private string fileLocation = "C:\\PasswordManager\\Storage";
        public ViewData(string key)
        {
            InitializeComponent();
            this.key = key;
            getData();
        }

        private void getData()
        {
            string[] fileList = Directory.GetFiles(fileLocation);

            TextBox[] usernames = new TextBox[fileList.Length];
            TextBox[] passwords = new TextBox[fileList.Length];
            Label[] serviceLabel = new Label[fileList.Length];

            Label usernamesLabel = new Label();
            Label passwordsLabel = new Label();
            Label service = new Label();

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



            for (int i = 0; i < fileList.Length; i++)
            {
                usernames[i] = new TextBox();
                usernames[i].Font = new Font("Arial", 18);
                usernames[i].AutoSize = true;

                passwords[i] = new TextBox();
                passwords[i].Font = new Font("Arial", 18);
                passwords[i].AutoSize = true;

                serviceLabel[i] = new Label();
                serviceLabel[i].Font = new Font("Arial", 18);
                serviceLabel[i].AutoSize = true;
                serviceLabel[i].ForeColor = Color.Gainsboro;
            }

            flowPanel.Controls.Add(service);
            flowPanel.Controls.Add(usernamesLabel);
            flowPanel.Controls.Add(passwordsLabel);

            for (int i = 0; i < fileList.Length; i++)
            {
                string[] data = File.ReadAllLines(fileList[i]);

                serviceLabel[i].Text = Decrypt(data[2], key);
                flowPanel.Controls.Add(serviceLabel[i]);

                usernames[i].Text = Decrypt(data[0], key);
                flowPanel.Controls.Add(usernames[i]);
                
                passwords[i].Text = Decrypt(data[1], key);
                flowPanel.Controls.Add(passwords[i]);

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
    }

}
