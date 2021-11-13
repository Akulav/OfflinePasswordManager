using PasswordManager;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace AuditScaner
{
    public partial class Login : Form
    {

        //Flag if a user already exists or not
        private bool userFlag = false;

        //UI dll functionality
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        //Adds dependencies inside .exe, makes sure password is masked and doublebuffered
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
            CheckIfUserAsync();
            Utilities.EnforceAdminPrivilegesWorkaround();
            InitializeComponent();
            Password.PasswordChar = '*';
            DoubleBuffered = true;
        }

        //On Load check is a user is already created. If exists, login, else sign up.
        private void Login_Load(object sender, EventArgs e)
        {
            if (userFlag)
            {
                UserButton.Text = "Login";
                ConfigButton.Text = "Delete Account";
            }
            else
            {
                InitializeDataSetAsync();
                UserButton.Text = "Create Account";
                ConfigButton.Text = "Import Data";
            }
        }

        //Create all necessary folders for the program.
        private void InitializeDataSetAsync()
        {
            Thread thread = new Thread(() => {
                try
                {
                    if (!Directory.Exists(Utilities.root))
                    {
                        Directory.CreateDirectory(Utilities.root);
                    }
                    if (!Directory.Exists(Utilities.users))
                    {
                        Directory.CreateDirectory(Utilities.users);
                    }
                    if (!Directory.Exists(Utilities.viewDataLocation))
                    {
                        Directory.CreateDirectory(Utilities.viewDataLocation);
                    }
                }
                catch { userFlag = false; }
            });
            thread.Start();
        }

        //Checks if user exists
        private void CheckIfUserAsync()
        {
            Thread thread = new Thread(() => {
                try
                {
                    if (Directory.EnumerateFiles(Utilities.users).Count() > 0)
                    {
                        userFlag = true;
                    }

                    else
                    {
                        userFlag = false;
                    }
                }

                catch { userFlag = false; }
            });
            thread.Start();
        }

        //Verify login information
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

        //Sign ups the user
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

                if (int.TryParse(PIMBox.Text, out _))
                {
                    int PIM = int.Parse(PIMBox.Text);
                    if (PIM > 100000 || PIM < 100)
                    {
                        statusText.Text = "PIM must be between 100 and 100000";
                        flag = false;
                    }
                }

                if (!int.TryParse(PIMBox.Text, out _))
                {
                    statusText.Text = "PIM must be a number";
                    flag = false;
                }            

                if (!Crypto.ValidatePassword(password))
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
                    Utilities.SetFileReadAccess(Utilities.curfile, true);
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
