using PasswordManager;
using PasswordManager.Utilities;
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace SeePass
{
    public partial class CreateData : Form
    {
        private readonly string key;
        public CreateData(string key)
        {
            InitializeComponent();
            CheckTheme();
            this.key = key;
        }

        private void Create_Click(object sender, EventArgs e)
        {
            Utility.SetFileReadAccess(Paths.user_data, false);
            var con = new SQLiteConnection(Paths.user_data_connection);
            con.Open();
        tryAgain:
            byte[] iv = Crypto.GenerateIV();
            string string_iv = System.Text.Encoding.Default.GetString(iv);
            var cmd = new SQLiteCommand(con)
            {
                CommandText = $"INSERT INTO data(username, pass, domain, iv) VALUES('{Crypto.Encrypt(usernameText.Text, key, iv)}','{Crypto.Encrypt(passwordText.Text, key, iv)}','{Crypto.Encrypt(domainText.Text, key, iv)}','{string_iv}')"
            };
            try
            {
                cmd.ExecuteNonQuery();
            }

            catch { goto tryAgain; }
            con.Close();
            Reset();
            doneLabel.Visible = true;
        }

        private void Reset()
        {
            usernameText.Text = null;
            passwordText.Text = null;
            domainText.Text = null;
        }

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Create_Click(null, null);
            }
        }

        private void CheckTheme()
        {
            if (!PasswordManager.Properties.Settings.Default.DarkMode)
            {
                Colors.ChangeTheme(Controls, this, "light");
            }
        }
    }
}