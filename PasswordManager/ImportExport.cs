using PasswordManager;
using System;
using System.Windows.Forms;

namespace AuditScaner
{
    public partial class ImportExport : Form
    {
        public ImportExport()
        {
            InitializeComponent();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            ImportExportClass.export();
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            Utilities ut = new Utilities();
            ut.OpenChildForm(new ImportConfirm(), this);      
        }

    }
}
