using PasswordManager;
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace AuditScaner
{
    public partial class CreateData : Form
    {
        private readonly string key;
        public CreateData(string key)
        {
            InitializeComponent();
            passwordText.PasswordChar = '*';
            this.key = key;
            doneLabel.Visible = false;
        }

        private void Create_Click(object sender, EventArgs e)
        {
            string username = usernameText.Text;
            string password = passwordText.Text;
            string domain = domainText.Text;

            Utilities.SetFileReadAccess(Utilities.user_data, false);

            var con = new SQLiteConnection(Utilities.user_data_connection);
            con.Open();
            var cmd = new SQLiteCommand(con)
            {
                CommandText = "INSERT INTO data(username, pass, domain) VALUES(@user,@pass,@domain)"
            };
            cmd.Parameters.AddWithValue("@user", Crypto.Encrypt(username, key));
            cmd.Parameters.AddWithValue("@pass", Crypto.Encrypt(password, key));
            cmd.Parameters.AddWithValue("@domain", Crypto.Encrypt(domain, key));
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
    }
}