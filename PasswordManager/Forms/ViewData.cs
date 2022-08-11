using PasswordManager;
using PasswordManager.Utilities;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace SeePass
{
    public partial class ViewData : Form
    {
        private readonly string key;
        public ViewData(string key)
        {
            InitializeComponent();
            this.key = key;
            CheckTheme();
            GetData();
        }

        private void GetData()
        {
            var con = new SQLiteConnection(Paths.database_connection);
            con.Open();
            var cmd = new SQLiteCommand(con)
            {
                CommandText = @"SELECT * FROM data"
            };
            var Table = cmd.ExecuteReader();

            while (Table.Read())
            {
                var indexC = data.Rows.Add();
                byte[] iv = Utility.GetBytes(PasswordManager.Properties.Settings.Default.encryptVector);
                data.Rows[indexC].Cells[0].Value = Crypto.Decrypt(Table[2].ToString(), key);
                data.Rows[indexC].Cells[1].Value = Crypto.Decrypt(Table[0].ToString(), key);
                data.Rows[indexC].Cells[2].Value = Crypto.Decrypt(Table[1].ToString(), key);
                data.Rows[indexC].Cells[3].Value = "Delete";
            }
            Table.Close();
            con.Close();
        }


        private void Data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == data.Columns["Delete"].Index)
            {
                var con = new SQLiteConnection(Paths.database_connection);
                con.Open();
                var cmd = new SQLiteCommand(con)
                {
                    CommandText = $"DELETE FROM data WHERE username = '{Crypto.Encrypt(data.Rows[e.RowIndex].Cells[1].Value.ToString(), key)}' AND " +
                    $"pass = '{Crypto.Encrypt(data.Rows[e.RowIndex].Cells[2].Value.ToString(), key)}' AND " +
                    $"domain = '{Crypto.Encrypt(data.Rows[e.RowIndex].Cells[0].Value.ToString(), key)}'"
                };
                cmd.ExecuteNonQuery();
                con.Close();
                data.Rows.Remove(data.Rows[e.RowIndex]);
            }
        }


        private void CheckTheme()
        {
            if (!PasswordManager.Properties.Settings.Default.DarkMode)
            {

                DataGridViewCellStyle style = new DataGridViewCellStyle
                {
                    BackColor = SystemColors.Control,
                    ForeColor = Colors.back_light
                };
                data.RowsDefaultCellStyle = style;
                data.BackgroundColor = SystemColors.Control;
                data.ColumnHeadersDefaultCellStyle = style;
            }
        }
    }
}