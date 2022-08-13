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
        private readonly string secondaryKey;
        private string fullKey;
        public CreateData(string[] key)
        {
            InitializeComponent();
            CheckTheme();
            this.key = key[0];
            secondaryKey = key[1];
        }

        private void Create_Click(object sender, EventArgs e)
        {
            fullKey = Crypto.Decrypt(key, secondaryKey);
            Utility.SetFileReadAccess(Paths.database, false);
            var con = new SQLiteConnection(Paths.database_connection);
            con.Open();

            var cmd = new SQLiteCommand(con)
            {
                CommandText = $"INSERT INTO data(username, pass, domain) VALUES('{Crypto.Encrypt(usernameText.Text, fullKey)}','{Crypto.Encrypt(passwordText.Text, fullKey)}','{Crypto.Encrypt(domainText.Text, fullKey)}')"
            };

            {
                cmd.ExecuteNonQuery();
            }
            cmd.Dispose();
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
            Data dt = settingUtilities.getSettings();
            if (!dt.dark)
            {
                Colors.ChangeTheme(Controls, this, "light");
            }
        }
    }
}