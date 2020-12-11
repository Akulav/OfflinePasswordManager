using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuditScaner
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            //Make sure program is ran as Admin
            enforceAdminPrivilegesWorkaround();
            //Make sure to hide password
            Password.PasswordChar = '*';
        }

        private void Login_Load(object sender, EventArgs e)
        {
            initializeDataSet();
            int user = checkIfUser();
            if (user == 0)
            {
                LoginUser.Visible = false;
                DeleteData.Visible = false;
            }

            else if (user == 1)
            {
                CreateUser.Visible = false;
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
            string subdir = @"C:\PasswordManager";
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }


            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
        }

        private int checkIfUser()
        {
            string curFile = @"c:\PasswordManager\user";
            if (File.Exists(curFile))
            {
                return 1;
            }

            else
            {
                return 0;
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

        public void checkHash(string user,string pass)
        {
            string curFile = @"c:\PasswordManager\user";
            string[] lines = File.ReadAllLines(curFile);
            string[] hashUser = GenerateHash(user, lines[0]);
            string[] hashPass = GenerateHash(pass, lines[2]);
            if (hashUser[1] == lines[3])
            {
                if (hashPass[1] == lines[1])
                {
                    MainForm mf = new MainForm(pass);
                    mf.Show();
                    this.Close();
                }

                else { MessageBox.Show("Wrong Account"); }
            }

            else { MessageBox.Show("Wrong Account"); }
            
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

            if (password.Length < 3)
            {
                SuccesDialog scFail = new SuccesDialog("LoginFailPassword");
                scFail.Show();
                goto end;
            }

            string[] datapass = GenerateHash(password,GenerateRandomAlphanumericString());
            string[] dataname = GenerateHash(username, GenerateRandomAlphanumericString());
            using (StreamWriter writer = new StreamWriter(@"c:\\PasswordManager\\user"))
            {
                writer.WriteLine(datapass[0]);
                Thread.Sleep(100);
                writer.WriteLine(datapass[1]);
                Thread.Sleep(100);
                writer.WriteLine(dataname[0]);
                Thread.Sleep(100);
                writer.WriteLine(dataname[1]);
            }

            

            SuccesDialog sc = new SuccesDialog("Login");
            sc.Show();
            end:
            this.Close();
            
        }

        private void LoginUser_Click(object sender, EventArgs e)
        {
            string password = Password.Text;
            string username = Username.Text;
            checkHash(username,password);
        }

    }
}
