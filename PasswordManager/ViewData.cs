using PasswordManager;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AuditScaner
{
    public partial class ViewData : Form
    {
        private readonly string key;
        public ViewData(string key)
        {
            InitializeComponent();
            this.key = key;
            GetData();
        }

        private string[] GetFileList()
        {
            return Directory.GetFiles(Utilities.viewDataLocation);
        }

        private void GetData()
        {
            string[] fileList = Directory.GetFiles(Utilities.viewDataLocation);

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
                usernames[i] = new TextBox
                {
                    Font = new Font("Arial", 16),
                    Width = 500,
                    AutoSize = true
                };

                passwords[i] = new TextBox
                {
                    Font = new Font("Arial", 16),
                    Width = 500,
                    AutoSize = true
                };

                serviceLabel[i] = new Label
                {
                    Font = new Font("Arial", 17),
                    AutoSize = true,
                    ForeColor = Color.Gainsboro
                };
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

                Button delete = new Button
                {
                    Name = i.ToString(),
                    Text = "Delete",
                    ForeColor = Color.Gainsboro,
                    Font = new Font("Arial", 16),
                    Width = 500,
                    AutoSize = true
                };
                delete.Click += new EventHandler(delegate (Object o, EventArgs a)
                {
                    int index = int.Parse(delete.Name);
                    string[] list = GetFileList();
                    try
                    {
                        string oldData = File.ReadAllText(list[index]);
                        string newData = Crypto.Encrypt(oldData, Crypto.GenerateRandomAlphanumericString(20));
                        File.WriteAllText(list[index], newData);
                        File.Delete(list[index]);
                    }

                    catch { }
                    Controls.Clear();
                    InitializeComponent();
                    GetData();
                });
                flowPanel.Controls.Add(delete);

            }

        }

    }

}