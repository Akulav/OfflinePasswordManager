using PasswordManager;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SeePass
{
    public partial class Login : Form
    {
        //Flags
        private static bool userFlag = false;
        //UI dll functionality
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        public Login()
        {
            //Loads all dependencies
            Utilities ut = new Utilities();
            ut.ImportDLL();
            
                File.WriteAllBytes("SQLite.Interop.dll", PasswordManager.Properties.Resources.sqlite_interop);
                File.WriteAllBytes("FontAwesome.Sharp.dll", PasswordManager.Properties.Resources.FontAwesome_Sharp);
            
            Utilities.MarkHidden("SQLite.Interop.dll");
            Utilities.MarkHidden("FontAwesome.Sharp.dll");

            //Makes sure the app is started as ADMIN
            Utilities.EnforceAdminPrivilegesWorkaround();

            //Loads the form
            InitializeComponent();

            //Checks user settings for dark mode
            CheckTheme();

            //Hides Password Chars
            Password.PasswordChar = '*';

            //More responsive on high-refresh rate screens
            DoubleBuffered = true;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //Checks if there is already a user 
            CheckIfUser();

            //If there is user, allow login
            if (userFlag)
            {
                UserButton.Text = "Login";
                welcomeLabel.Text = "Login to your account";
                ConfigButton.Text = "Delete Account";
            }

            //If no user, allow sign up
            else
            {
                UserButton.Text = "Create Account";
                welcomeLabel.Text = "Create an account";
                ConfigButton.Text = "Import Data";
            }
        }

        private void InitializeDataSet()
        {
            try
            {
                //Creates the folders for the app
                if (!Directory.Exists(Utilities.users))
                {
                    Directory.CreateDirectory(Utilities.users);
                }
                if (!Directory.Exists(Utilities.viewDataLocation))
                {
                    Directory.CreateDirectory(Utilities.viewDataLocation);
                }

                //Creates the DB that stores the data for login
                if (!File.Exists(Utilities.database))
                {
                    File.WriteAllText(Utilities.database, null);
                    var con = new SQLiteConnection(Utilities.database_connection);
                    con.Open();
                    var cmd = new SQLiteCommand(con)
                    {
                        CommandText = @"CREATE TABLE user(username VARCRHAR(250), user_salt VARCRHAR(250), pass VARCRHAR(250), pass_salt VARCRHAR(250), pim VARCRHAR(250), pim_salt VARCRHAR(250))"
                    };
                    cmd.ExecuteNonQuery();
                }

                //Creates the DB that stores user data
                if (!File.Exists(Utilities.user_data))
                {
                    File.WriteAllText(Utilities.user_data, null);
                    //User Data Database initialization
                    var data_con = new SQLiteConnection(Utilities.user_data_connection);
                    data_con.Open();
                    var data_cmd = new SQLiteCommand(data_con)
                    {
                        CommandText = @"CREATE TABLE data(username VARCRHAR(250), pass VARCRHAR(250),domain VARCRHAR(250))"
                    };
                    data_cmd.ExecuteNonQuery();
                    data_con.Close();
                }
            }
            catch { userFlag = false; }
        }

        //Checks if user exists
        private void CheckIfUser()
        {
            try
            {
                if (File.Exists(Utilities.database))
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

        //Verify login information
        public void CheckLogin(string user, string pass, int PIM)
        {
            if (Crypto.CheckHash(user, pass, PIM))
            {
                try
                {
                    MainForm mf = new MainForm(pass, user, int.Parse(PIMBox.Text))
                    {
                        StartPosition = FormStartPosition.CenterScreen
                    };
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
            if (!userFlag)
            {
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
                    InitializeDataSet();
                    string[] datapass = Crypto.GenerateHash(password, Crypto.GenerateRandomAlphanumericString(128));
                    string[] dataname = Crypto.GenerateHash(username, Crypto.GenerateRandomAlphanumericString(128));
                    string[] PIMRead = Crypto.GenerateHash(password + username, Crypto.GenerateRandomAlphanumericString(128));

                    for (int i = 0; i < int.Parse(PIMBox.Text); i++)
                    {
                        PIMRead = Crypto.GenerateHash(PIMRead[0], PIMRead[1]);
                    }

                    //Insert data into database user and pass actually switch places
                    var con = new SQLiteConnection(Utilities.database_connection);
                    con.Open();
                    var cmd = new SQLiteCommand(con)
                    {
                        CommandText = $"INSERT INTO user(username, user_salt, pass, pass_salt, pim, pim_salt) VALUES('{datapass[0]}', '{datapass[1]}', '{dataname[0]}', '{dataname[1]}', '{PIMRead[0]}', '{PIMRead[1]}')"
                    };

                    cmd.ExecuteNonQuery();
                    con.Close();

                    Utilities.SetFileReadAccess(Utilities.database, true);
                    Utilities.SetFileReadAccess(Utilities.user_data, true);
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

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //UI ELEMENTS
        private void LeftTopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void ThemChange_Click(object sender, EventArgs e)
        {
            PasswordManager.Properties.Settings.Default.DarkMode = !PasswordManager.Properties.Settings.Default.DarkMode;
            PasswordManager.Properties.Settings.Default.Save();
            CheckTheme();
        }

        private void CheckTheme()
        {
            if (PasswordManager.Properties.Settings.Default.DarkMode)
            {

                leftpanel.BackColor = Color.FromArgb(31, 30, 68);
                rightpanel.BackColor = Color.FromArgb(34, 33, 74);
                UserButton.BackColor = Color.FromArgb(34, 33, 74);
                ConfigButton.ForeColor = Color.Gainsboro;
                UserButton.ForeColor = Color.Gainsboro;
                ConfigButton.BackColor = Color.FromArgb(34, 33, 74);
                welcomeLabel.ForeColor = Color.Gainsboro;
                PIMLabel.ForeColor = Color.Gainsboro;
                userLabel.ForeColor = Color.Gainsboro;
                passLabel.ForeColor = Color.Gainsboro;
                themChange.BackColor = Color.FromArgb(34, 33, 74);
                CloseButton.BackColor = Color.FromArgb(34, 33, 74);
                themChange.IconColor = Color.Gainsboro;
                CloseButton.ForeColor = Color.Gainsboro;
                themChange.IconChar = FontAwesome.Sharp.IconChar.Sun;
                devLabel.ForeColor = Color.Gainsboro;
            }

            else
            {
                leftpanel.BackColor = Color.FromArgb(41, 128, 185);
                rightpanel.BackColor = SystemColors.Control;
                UserButton.BackColor = Color.FromArgb(41, 128, 185);
                ConfigButton.BackColor = Color.FromArgb(41, 128, 185);
                ConfigButton.ForeColor = Color.Gainsboro;
                UserButton.ForeColor = Color.Gainsboro;
                welcomeLabel.ForeColor = Color.FromArgb(41, 128, 185);
                PIMLabel.ForeColor = Color.FromArgb(41, 128, 185);
                userLabel.ForeColor = Color.FromArgb(41, 128, 185);
                passLabel.ForeColor = Color.FromArgb(41, 128, 185);
                themChange.BackColor = Color.Transparent;
                CloseButton.BackColor = SystemColors.Control;
                themChange.IconColor = Color.FromArgb(41, 128, 185);
                CloseButton.ForeColor = Color.FromArgb(41, 128, 185);
                themChange.IconChar = FontAwesome.Sharp.IconChar.Moon;
                devLabel.ForeColor = SystemColors.Control;
            }
        }
    }
}
