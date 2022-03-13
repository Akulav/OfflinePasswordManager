using PasswordManager;
using PasswordManager.Utilities;
using System;
using System.Windows.Forms;

namespace SeePass
{
    public partial class ImportExport : Form
    {
        public ImportExport()
        {
            InitializeComponent();
            CheckTheme();
            statusLabel.Visible = false;
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            if (ImportExportClass.Export()) { statusLabel.Visible = true; }
        }

        private void CheckTheme()
        {
            if (!PasswordManager.Properties.Settings.Default.DarkMode)
            {
                Colors.changeTheme(Controls, this);
            }
        }
    }
}
