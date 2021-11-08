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
            statusLabel.Visible = false;
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            ImportExportClass.Export();
            statusLabel.Visible = true;
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            Utilities ut = new Utilities();
            ut.OpenChildForm(new ImportConfirm(), this);      
        }

    }
}
