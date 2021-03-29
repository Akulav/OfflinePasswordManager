using PasswordManager;
using System;
using System.Windows.Forms;

namespace AuditScaner
{
    public partial class ImportConfirm : Form
    {
        public ImportConfirm()
        {
            InitializeComponent();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            Crypto.erase();
            ImportExportClass.import();
            Application.Restart();
        }      
             
    }
}