using PasswordManager;
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
            Utilities.EnforceAdminPrivilegesWorkaround();
            Password.PasswordChar = '*';
            DoubleBuffered = true;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            CheckIfUser();

            if (userFlag)
            {
                UserButton.Text = "Login";
                ConfigButton.Text = "Delete Account";
            }
            else
            {
                UserButton.Text = "Create Account";
                ConfigButton.Text = "Import Data";
            }
        }

        private void InitializeDataSet()
        {
            string root = @"C:\";
            string subdir = @"C:\PasswordManager\users";
            string storageDir = @"C:\PasswordManager\localuser";

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

        private void CheckIfUser()
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

        public void CheckLogin(string user, string pass, int PIM)
        {
            if (Crypto.CheckHash(user, pass, PIM))
            {
                try
                {
                    MainForm mf = new MainForm(pass, user, int.Parse(PIMBox.Text));
                    mf.Show();
                    Close();
                }

                catch 
                {
                    statusText.Text = "Input a number inside PIM";
                }
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

                if (!int.TryParse(PIMBox.Text, out _))
                {
                    statusText.Text = "PIM must be a number. Recommended above 1000";
                    flag = false;
                }

                if (!ValidatePassword(password))
                {
                    statusText.Text = "Password must be at least 12 characters\n long and contain alphanumeric chars";
                    flag = false;
                }

                if (flag == true)
                {
                    string[] datapass = Crypto.GenerateHash(password, Crypto.GenerateRandomAlphanumericString(128));                   
                    string[] dataname = Crypto.GenerateHash(username, Crypto.GenerateRandomAlphanumericString(128));
                    string[] PIMRead = Crypto.GenerateHash(password+username, Crypto.GenerateRandomAlphanumericString(128));

                    for (int i = 0; i < int.Parse(PIMBox.Text); i++)
                    {
                        PIMRead = Crypto.GenerateHash(PIMRead[0], PIMRead[1]);
                    }

                    InitializeDataSet();

                    using (StreamWriter writer = new StreamWriter(Utilities.curfile))
                    {
                        writer.WriteLine(datapass[0]);
                        writer.WriteLine(datapass[1]);
                        writer.WriteLine(dataname[0]);
                        writer.WriteLine(dataname[1]);
                        writer.WriteLine(PIMRead[0]);
                        writer.WriteLine(PIMRead[1]);
                        writer.Close();
                    }
                    Application.Restart();
                }
            }

            else
            {
                string password = Password.Text;
                string username = Username.Text;

                try
                {
                    int PIM = int.Parse(PIMBox.Text);
                    CheckLogin(username, password, PIM);
                }

                catch { statusText.Text = "Input a valid number for PIM"; }
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
                        && hasUpperCaseLetter
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

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
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

        private void ConfigButton_Click(object sender, EventArgs e)
        {
            if (!userFlag)
            {
                ImportExportClass.Import();
            }

            else
            {
                DeleteUserLogin del = new DeleteUserLogin();
                del.Show();
                Close();
            }
        }
    }
}
