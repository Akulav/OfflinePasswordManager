using PasswordManager;
using System;
using System.Windows.Forms;

namespace AuditScaner
{
    public partial class ImportConfirm : Form
    {
        private string fileLocation = "C:\\PasswordManager\\";
        public ImportConfirm()
        {
            InitializeComponent();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            ImportExportClass.import(fileLocation);
        }

    }
}