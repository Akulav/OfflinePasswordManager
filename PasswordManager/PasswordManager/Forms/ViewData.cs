using Newtonsoft.Json;
using PasswordManager;
using PasswordManager.Utilities;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SeePass
{
    public partial class ViewData : Form
    {
        readonly Data dt = JsonConvert.DeserializeObject<Data>(File.ReadAllText(Paths.settings));
        private readonly string key;
        private readonly string secondaryKey;
        private string fullKey;
        public ViewData(string[] key)
        {
            InitializeComponent();
            this.key = key[0];
            secondaryKey = key[1];
            CheckTheme();
            GetData();
        }

        private void GetData()
        {
            fullKey = Crypto.Decrypt(key, secondaryKey);
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
                data.Rows[indexC].Cells[0].Value = Crypto.Decrypt(Table[2].ToString(), fullKey);
                data.Rows[indexC].Cells[1].Value = Crypto.Decrypt(Table[0].ToString(), fullKey);
                data.Rows[indexC].Cells[2].Value = Crypto.Decrypt(Table[1].ToString(), fullKey);
                data.Rows[indexC].Cells[3].Value = "Delete";
            }
            fullKey = null;
            Table.Close();
            cmd.Dispose();
            con.Close();
            
        }


        private void Data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            fullKey = Crypto.Decrypt(key, secondaryKey);
            if (e.ColumnIndex == data.Columns["Delete"].Index)
            {
                var con = new SQLiteConnection(Paths.database_connection);
                con.Open();
                var cmd = new SQLiteCommand(con)
                {
                    CommandText = $"DELETE FROM data WHERE username = '{Crypto.Encrypt(data.Rows[e.RowIndex].Cells[1].Value.ToString(), fullKey)}' AND " +
                    $"pass = '{Crypto.Encrypt(data.Rows[e.RowIndex].Cells[2].Value.ToString(), fullKey)}' AND " +
                    $"domain = '{Crypto.Encrypt(data.Rows[e.RowIndex].Cells[0].Value.ToString(), fullKey)}'"
                };
                cmd.ExecuteNonQuery();
                data.Rows.Remove(data.Rows[e.RowIndex]);
                cmd.Dispose();
                con.Close();
                fullKey = null;
            }
        }


        private void CheckTheme()
        {
            if (!dt.dark)
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