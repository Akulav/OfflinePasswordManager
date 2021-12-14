using PasswordManager;
using System.IO;
using System.Windows.Forms;

namespace AuditScaner
{
    public partial class ViewData : Form
    {
        private readonly string key;
        public ViewData(string key)
        {
            InitializeComponent();
            this.key = key;
            GetData();
        }

        private string[] GetFileList()
        {
            return Directory.GetFiles(Utilities.viewDataLocation);
        }

        private void GetData()
        {
            string[] fileList = GetFileList();

            for (int i = 0; i < fileList.Length; i++)
            {
                string[] data = File.ReadAllLines(fileList[i]);
                var indexC = this.data.Rows.Add();
                this.data.Rows[indexC].Cells[0].Value = Crypto.Decrypt(data[2], key);
                this.data.Rows[indexC].Cells[1].Value = Crypto.Decrypt(data[0], key);
                this.data.Rows[indexC].Cells[2].Value = Crypto.Decrypt(data[1], key);
                this.data.Rows[indexC].Cells[3].Value = "Delete";
            }
        }

        private void Data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string[] list = GetFileList();
            if (e.ColumnIndex == data.Columns["Delete"].Index)
            {
                int currentRow = e.RowIndex;
                Utilities.SetFileReadAccess(list[currentRow], false);
                string oldData = File.ReadAllText(list[currentRow]);
                string newData = Crypto.Encrypt(oldData, Crypto.GenerateRandomFileName(100));
                File.WriteAllText(list[currentRow], newData);
                File.Delete(list[currentRow]);
                Controls.Clear();
                InitializeComponent();
                GetData();
            }
        }
    }
}