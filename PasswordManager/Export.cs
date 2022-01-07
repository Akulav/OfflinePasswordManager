using PasswordManager;
using System;
using System.Windows.Forms;

namespace SeePass
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
            if (ImportExportClass.Export()) {statusLabel.Visible = true;}
        }
    }
}
