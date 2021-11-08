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

        private void NoButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            ImportExportClass.Import(Utilities.fileLocation);
        }

    }
}