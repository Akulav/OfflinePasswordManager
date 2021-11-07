﻿using PasswordManager;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AuditScaner
{
    public partial class Login : Form
    {

        //Will Execute on load
        //All initialization is done here
        //Things like importing DLLs and enforcing Admin are here
        private string fileLocation = "C:\\PasswordManager\\";
        private bool userFlag = false;
        public Login()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string resourceName = new AssemblyName(args.Name).Name + ".dll";
                string resource = Array.Find(GetType().Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                {
                    byte[] assemblyData = new byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };

            InitializeComponent();
            Utilities.enforceAdminPrivilegesWorkaround();
            Password.PasswordChar = '*';
            DoubleBuffered = true;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            checkIfUser();

            if (userFlag)
            {
                UserButton.Text = "Login";
                importData.Visible = false;
            }
            else
            {
                UserButton.Text = "Create Account";
                DeleteData.Visible = false;
            }
        }

        private void initializeDataSet(string user)
        {
            string root = @"C:\";
            string subdir = @"C:\PasswordManager\users";
            string storageDir = @"C:\PasswordManager\" + user;

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }


            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }

            if (!Directory.Exists(storageDir))
            {
                Directory.CreateDirectory(storageDir);
            }

        }

        private void checkIfUser()
        {
            try
            {
                string Folder = @"c:\PasswordManager\users";
                if (Directory.EnumerateFiles(Folder).Count() > 0)
                {
                    userFlag = true;
                }

                else
                {
                    userFlag = false;
                }
            }

            catch { userFlag = false; }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        public void checkLogin(string user, string pass)
        {
            if (Crypto.checkHash(user, pass))
            {
                MainForm mf = new MainForm(pass, user);
                mf.Show();
                Close();
            }
            else { statusText.Text = "Wrong username / password combination"; }
        }

        private void CreateUser_Click(object sender, EventArgs e)
        {

            if (!userFlag) {
                string password = Password.Text;
                string username = Username.Text;
                bool flag = true;

                if (username == "")
                {
                    statusText.Text = "Username must not be null";
                    flag = false;
                }

                if (!ValidatePassword(password))
                {
                    statusText.Text = "Password must be at least 12 characters\n long and contain alphanumeric chars";
                    flag = false;
                }

                if (flag == true)
                {

                    string[] datapass = Crypto.GenerateHash(password, Crypto.GenerateRandomAlphanumericString(256));
                    string[] dataname = Crypto.GenerateHash(username, Crypto.GenerateRandomAlphanumericString(256));

                    initializeDataSet(username);
                    string location = "c:\\PasswordManager\\users\\" + username;

                    using (StreamWriter writer = new StreamWriter(@location))
                    {
                        writer.WriteLine(datapass[0]);
                        writer.WriteLine(datapass[1]);
                        writer.WriteLine(dataname[0]);
                        writer.WriteLine(dataname[1]);
                        writer.Close();
                    }

                    Application.Restart();
                }
            }

            else
            {
                string password = Password.Text;
                string username = Username.Text;
                checkLogin(username, password);
            }
        }


        //Modify to enforce harder password
        static bool ValidatePassword(string password)
        {
            const int MIN_LENGTH = 12;
            const int MAX_LENGTH = int.MaxValue-1;

            if (password == null) throw new ArgumentNullException();

            bool meetsLengthRequirements = password.Length >= MIN_LENGTH && password.Length <= MAX_LENGTH;
            bool hasUpperCaseLetter = false;
            bool hasLowerCaseLetter = false;
            bool hasDecimalDigit = false;

            if (meetsLengthRequirements)
            {
                foreach (char c in password)
                {
                    if (char.IsUpper(c)) hasUpperCaseLetter = true;
                    else if (char.IsLower(c)) hasLowerCaseLetter = true;
                    else if (char.IsDigit(c)) hasDecimalDigit = true;
                }
            }

            bool isValid = meetsLengthRequirements
                        //&& hasUpperCaseLetter //dont wanna make it too strict
                        && hasLowerCaseLetter
                        && hasDecimalDigit
                        ;
            return isValid;

        }

        //UI Events
        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                CreateUser_Click(null, null);
            }
        }

        private void importData_Click(object sender, EventArgs e)
        {
            ImportExportClass.import(fileLocation);
        }

        private void DeleteData_Click(object sender, EventArgs e)
        {
            DeleteUserLogin del = new DeleteUserLogin();
            del.RefToForm1 = this;
            this.Hide();
            del.Show();
        }

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
