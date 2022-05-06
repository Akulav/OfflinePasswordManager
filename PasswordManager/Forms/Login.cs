using PasswordManager;
using PasswordManager.Utilities;
using System;
using System.Data.SQLite;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace SeePass
{
    public partial class Login : Form
    {
        private static bool userFlag = false;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        //
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
    (
        int nLeftRect,
        int nTopRect,
        int nRightRect,
        int nBottomRect,
        int nWidthEllipse,
        int nHeightEllipse
    );
        //

        public Login()
        {
            Utility.EnforceAdminPrivilegesWorkaround();
            InitializeComponent();
            CheckTheme();

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            Password.PasswordChar = '*';
            DoubleBuffered = true;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            CheckIfUser();
            if (userFlag)
            {
                UserButton.Text = "Login";
                welcomeLabel.Text = "Login to your account";
                ConfigButton.Text = "Delete Account";
            }

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
                if (!Directory.Exists(Paths.fileLocation))
                {
                    Directory.CreateDirectory(Paths.fileLocation);
                }

                if (!File.Exists(Paths.database))
                {
                    File.WriteAllText(Paths.database, null);
                    var con = new SQLiteConnection(Paths.database_connection);
                    con.Open();

                    var cmd = new SQLiteCommand(con)
                    {
                        CommandText = @"CREATE TABLE user(username VARCRHAR(250), user_salt VARCRHAR(250), pass VARCRHAR(250), pass_salt VARCRHAR(250), pim VARCRHAR(250), pim_salt VARCRHAR(250))"
                    };

                    var data_cmd = new SQLiteCommand(con)
                    {
                        CommandText = @"CREATE TABLE data(username VARCRHAR(250), pass VARCRHAR(250),domain VARCRHAR(250), iv VARCHAR(255))"
                    };

                    data_cmd.ExecuteNonQuery();
                    cmd.ExecuteNonQuery();
                }

            }
            catch { }
        }

        private void CheckIfUser()
        {
            try
            {
                if (File.Exists(Paths.database))
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

        public void CheckLogin(string user, string pass, int PIM)
        {
            if (int.TryParse(PIMBox.Text, out _))
            {
                if (Crypto.CheckHash(user, pass, PIM))
                {
                    MainForm mf = new MainForm(pass, user, PIM);
                    mf.Show();
                    Close();
                }
                else { statusText.Text = "Wrong username / password combination"; }
            }
        }

        private void CreateUser_Click(object sender, EventArgs e)
        {

            string password = Password.Text;
            string username = Username.Text;

            if (!userFlag)
            {

                try
                {
                    if (username == "")
                    {
                        statusText.Text = "Username must not be null";
                        throw new Exception();
                    }

                    if (int.TryParse(PIMBox.Text, out _))
                    {
                        int PIM = int.Parse(PIMBox.Text);
                        if (PIM > 100000 || PIM < 100)
                        {
                            statusText.Text = "PIM must be between 100 and 100000";
                            throw new Exception();
                        }
                    }

                    if (!int.TryParse(PIMBox.Text, out _))
                    {
                        statusText.Text = "PIM must be a number";
                        throw new Exception();
                    }

                    if (!Crypto.ValidatePassword(password))
                    {
                        statusText.Text = "Password must be at least 12 characters\n long and contain alphanumeric chars";
                        throw new Exception();
                    }

                    InitializeDataSet();
                    string[] datapass = Crypto.GenerateHash(password, Crypto.GenRandString(128));
                    string[] dataname = Crypto.GenerateHash(username, Crypto.GenRandString(128));
                    string[] PIMRead = Crypto.GenerateHash(password + username, Crypto.GenRandString(128));

                    for (int i = 0; i < int.Parse(PIMBox.Text); i++)
                    {
                        PIMRead = Crypto.GenerateHash(PIMRead[0], PIMRead[1]);
                    }

                    //Insert data into database user and pass actually switch places
                    var con = new SQLiteConnection(Paths.database_connection);
                    con.Open();
                    var cmd = new SQLiteCommand(con)
                    {
                        CommandText = $"INSERT INTO user(username, user_salt, pass, pass_salt, pim, pim_salt) VALUES('{datapass[0]}', '{datapass[1]}', '{dataname[0]}', '{dataname[1]}', '{PIMRead[0]}', '{PIMRead[1]}')"
                    };

                    cmd.ExecuteNonQuery();

                    Utility.SetFileReadAccess(Paths.database, true);
                    Application.Restart();
                }

                catch { };
            }

            else
            {
                try
                {
                    int PIM = int.Parse(PIMBox.Text);
                    CheckLogin(username, password, PIM);
                }

                catch { statusText.Text = "Input a valid number for PIM"; }
            }
        }

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
            Application.Restart();
        }

        private void CheckTheme()
        {
            if (PasswordManager.Properties.Settings.Default.DarkMode)
            {
                Colors.ChangeTheme(Controls, this, "dark");
                Colors.ChangeTheme(rightpanel.Controls, this, "dark");
                Colors.ChangeTheme(leftpanel.Controls, this, "darker");
                leftpanel.BackColor = Colors.back_darker;
            }
        }
    }
}