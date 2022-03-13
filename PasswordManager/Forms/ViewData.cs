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
            var con = new SQLiteConnection(Paths.user_data_connection);
            con.Open();
            var cmd = new SQLiteCommand(con)
            {
                CommandText = @"SELECT * FROM data"
            };
            var Table = cmd.ExecuteReader();

            while (Table.Read())
            {
                var indexC = data.Rows.Add();
                byte[] iv = Utility.getBytes(Table[3].ToString());
                data.Rows[indexC].Cells[0].Value = Crypto.Decrypt(Table[2].ToString(), key, iv);
                data.Rows[indexC].Cells[1].Value = Crypto.Decrypt(Table[0].ToString(), key, iv);
                data.Rows[indexC].Cells[2].Value = Crypto.Decrypt(Table[1].ToString(), key, iv);
                data.Rows[indexC].Cells[4].Value = Table[3].ToString();
                data.Rows[indexC].Cells[3].Value = "Delete";
            }
            Table.Close();
        }


        private void Data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == data.Columns["Delete"].Index)
            {
                byte[] iv = Utility.getBytes(data.Rows[e.RowIndex].Cells[4].Value.ToString());
                var con = new SQLiteConnection(Paths.user_data_connection);
                con.Open();
                var cmd = new SQLiteCommand(con)
                {
                    CommandText = $"DELETE FROM data WHERE username = '{Crypto.Encrypt(data.Rows[e.RowIndex].Cells[1].Value.ToString(), key, iv)}' AND " +
                    $"pass = '{Crypto.Encrypt(data.Rows[e.RowIndex].Cells[2].Value.ToString(), key, iv)}' AND " +
                    $"domain = '{Crypto.Encrypt(data.Rows[e.RowIndex].Cells[0].Value.ToString(), key, iv)}'"
                };
                cmd.ExecuteNonQuery();
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