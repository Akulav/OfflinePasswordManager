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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuditScaner
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
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

        private void topPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DeleteData_Click(object sender, EventArgs e)
        {

        }

        public void checkHash(string input)
        {
            string curFile = @"c:\PasswordManager\user";
            string[] lines = File.ReadAllLines(curFile);
            string[] newHash = GenerateHash(input, lines[0]);
            if (newHash[1]==lines[1])
            {
                MessageBox.Show(newHash[1]);
                MessageBox.Show(lines[1]);
            }
        }

        public string[] GenerateHash(string input, string salt)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(input + salt);
            SHA256Managed sHA256ManagedString = new SHA256Managed();
            byte[] hash = sHA256ManagedString.ComputeHash(bytes);
            string[] data = { salt, Encoding.ASCII.GetString(hash) };
            return data;
        }

        public string GenerateRandomAlphanumericString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[80];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;
        }

        private void CreateUser_Click(object sender, EventArgs e)
        {
            string password = Password.Text;
            string[] data = GenerateHash(password,GenerateRandomAlphanumericString());
            using (StreamWriter writer = new StreamWriter(@"c:\\PasswordManager\\user"))
            {
                writer.WriteLine(data[0]);
                writer.WriteLine(data[1]);
            }
            
        }

        private void LoginUser_Click(object sender, EventArgs e)
        {
            string password = Password.Text;
            checkHash(password);
        }
    }
}
