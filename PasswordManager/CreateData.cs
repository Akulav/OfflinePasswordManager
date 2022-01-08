using PasswordManager;
using System;
using System.Data.SQLite;
using System.Drawing;
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
            Utilities.SetFileReadAccess(Utilities.user_data, false);
            var con = new SQLiteConnection(Utilities.user_data_connection);
            con.Open();
            var cmd = new SQLiteCommand(con)
            {
                CommandText = $"INSERT INTO data(username, pass, domain) VALUES('{Crypto.Encrypt(usernameText.Text, key)}','{Crypto.Encrypt(passwordText.Text, key)}','{Crypto.Encrypt(domainText.Text, key)}')"
            };
            cmd.ExecuteNonQuery();
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
                BackColor = SystemColors.Control;
                doneLabel.ForeColor = Color.FromArgb(41, 128, 185);
                user.ForeColor = Color.FromArgb(41, 128, 185);
                pass.ForeColor = Color.FromArgb(41, 128, 185);
                domain.ForeColor = Color.FromArgb(41, 128, 185);
                create.ForeColor = Color.FromArgb(41, 128, 185);
                create.BackColor = SystemColors.Control;
            }
        }
    }
}