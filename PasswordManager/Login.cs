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

        private bool checkIfUser()
        {   try
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

            catch { return false; }
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
            else { MessageBox.Show("Wrong Account"); }           
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

        //UI Events
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

        private void importData_Click(object sender, EventArgs e)
        {
            ImportExportClass.import();
        }
        private void LoginUser_Click(object sender, EventArgs e)
        {
            string password = Password.Text;
            string username = Username.Text;
            checkLogin(username, password);
        }

        private void DeleteData_Click(object sender, EventArgs e)
        {
            DeleteUserLogin del = new DeleteUserLogin();
            del.RefToForm1 = this;
            del.Show();
            this.Hide();
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
