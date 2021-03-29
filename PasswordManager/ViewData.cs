using PasswordManager;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AuditScaner
{
    public partial class ViewData : Form
    {
        private string key;
        private string fileLocation = "C:\\PasswordManager\\";
        public ViewData(string key, string username)
        {
            InitializeComponent();
            this.key = key;
            fileLocation = fileLocation + username;
            getData();
        }

        private string[] getFileList()
        {
            return Directory.GetFiles(fileLocation);
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

            for (int i = 0; i < fileList.Length; i++)
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

            for (int i = 0; i < fileList.Length; i++)
            {
                string[] data = File.ReadAllLines(fileList[i]);

                serviceLabel[i].Text = Crypto.Decrypt(data[2], key);
                flowPanel.Controls.Add(serviceLabel[i]);

                usernames[i].Text = Crypto.Decrypt(data[0], key);
                flowPanel.Controls.Add(usernames[i]);

                passwords[i].Text = Crypto.Decrypt(data[1], key);
                flowPanel.Controls.Add(passwords[i]);

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
                        string newData = Crypto.Encrypt(oldData, Crypto.GenerateRandomAlphanumericString(40));
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

    }

}