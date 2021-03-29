﻿using Microsoft.Win32;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace AuditScaner
{
    public partial class Login : Form
    {
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
            enforceAdminPrivilegesWorkaround();
            Password.PasswordChar = '*';
            DoubleBuffered = true;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            initializeDataSet();
            if (checkIfUser())
            {
                CreateUser.Visible = false;
                importData.Visible = false;
            }

            else
            {
                LoginUser.Visible = false;
                DeleteData.Visible = false;

            }
        }

        private void enforceAdminPrivilegesWorkaround()
        {
            RegistryKey rk;
            string registryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon\";

            try
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    rk = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                }
                else
                {
                    rk = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                }

                rk = rk.OpenSubKey(registryPath, true);
            }
            catch (System.Security.SecurityException)
            {
                MessageBox.Show("Please run as administrator");
                Environment.Exit(1);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void initializeDataSet()
        {
            string root = @"C:\";
            string subdir = @"C:\PasswordManager\users";
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }


            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
        }

        private bool checkIfUser()
        {
            string Folder = @"c:\PasswordManager\users";
            if (Directory.EnumerateFiles(Folder).Count() > 0)
            {
                return true;       
            }

            else
            {
                return false;
            }
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        public void checkHash(string user, string pass)
        {
            string curfile = "c:\\PasswordManager\\users\\" + user;
            try
            {
                string[] lines = File.ReadAllLines(curfile);



                string[] hashUser = GenerateHash(user, lines[0]);
                string[] hashPass = GenerateHash(pass, lines[2]);
                if (hashUser[1] == lines[3])
                {
                    if (hashPass[1] == lines[1])
                    {
                        MainForm mf = new MainForm(pass, user);                        
                        mf.Show();
                        this.Close();
                    }

                    else { MessageBox.Show("Wrong Account"); }
                }

                else { MessageBox.Show("Wrong Account"); }
            }

            catch { }
        }

        public string[] GenerateHash(string input, string salt)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(input + salt);
            SHA256Managed sHA256ManagedString = new SHA256Managed();
            byte[] hash = sHA256ManagedString.ComputeHash(bytes);
            string[] data = { salt, BitConverter.ToString(hash) };
            return data;
        }

        public string GenerateRandomAlphanumericString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[80];
            Random rnd = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[rnd.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;
        }

        private void CreateUser_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string password = Password.Text;
            string username = Username.Text;

            if (username == "")
            {
                SuccesDialog scFail = new SuccesDialog("LoginFailUsername");
                scFail.Show();
                goto end;
            }

            if (!ValidatePassword(password))
            {
                SuccesDialog scFail = new SuccesDialog("LoginFailPassword");
                scFail.Show();
                goto end;
            }

            string[] datapass = GenerateHash(password, GenerateRandomAlphanumericString());
            string[] dataname = GenerateHash(username, GenerateRandomAlphanumericString());

            string location = "c:\\PasswordManager\\users\\" + username;

            using (StreamWriter writer = new StreamWriter(@location))
            {
                writer.WriteLine(datapass[0]);
                writer.WriteLine(datapass[1]);
                writer.WriteLine(dataname[0]);
                writer.WriteLine(dataname[1]);
                writer.Close();
            }

            SuccesDialog sc = new SuccesDialog("Login");
            sc.Show();
        end:
            this.Close();

        }

        //Modify to enforce harder password
        static bool ValidatePassword(string password)
        {
            const int MIN_LENGTH = 1;
            const int MAX_LENGTH = 15;

            if (password == null) throw new ArgumentNullException();

            bool meetsLengthRequirements = password.Length >= MIN_LENGTH && password.Length <= MAX_LENGTH;
            bool hasUpperCaseLetter = false;
            bool hasLowerCaseLetter = false;
            bool hasDecimalDigit = false;

            if (meetsLengthRequirements)
            {
                foreach (char c in password)
                {
                    if (char.IsUpper(c)) hasUpperCaseLetter = false;
                    else if (char.IsLower(c)) hasLowerCaseLetter = false;
                    else if (char.IsDigit(c)) hasDecimalDigit = false;
                }
            }

            bool isValid = meetsLengthRequirements
                        //&& hasUpperCaseLetter //dont wanna make it too strict
                        //&& hasLowerCaseLetter
                        //&& hasDecimalDigit
                        ;
            return isValid;

        }
        private void LoginUser_Click(object sender, EventArgs e)
        {
            string password = Password.Text;
            string username = Username.Text;
            checkHash(username, password);
        }

        private void DeleteData_Click(object sender, EventArgs e)
        {
            DeleteUserLogin del = new DeleteUserLogin();
            del.RefToForm1 = this;
            del.Show();
            this.Hide();
        }

        private void importData_Click(object sender, EventArgs e)
        {
            import();
        }

        //Import logic
        private void import()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\PasswordManager";
            openFileDialog1.Filter = "Zip files (*.zip)|*.zip*";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;
            string selection;
            string extractPath = @"c:\PasswordManager";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                selection = openFileDialog1.FileName;
                ZipFile.ExtractToDirectory(selection, extractPath);
            }
            try
            {
                selection = openFileDialog1.FileName;
                ZipFile.ExtractToDirectory(selection, extractPath);
            }
            catch (IOException)
            {
                
            }

            catch (ArgumentNullException)
            {

            }

            Application.Restart();

        }

        //Detect enter key on password
        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

                if (checkIfUser())
                {
                    LoginUser_Click(null, null);
                }

                else
                {
                    CreateUser_Click(null, null);
                }
            }
        }
    }
}
