using PasswordManager;
using System;
using System.Drawing;
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
            if (ImportExportClass.Export()) {statusLabel.Visible = true;}
        }

        private void CheckTheme()
        {
            if (!PasswordManager.Properties.Settings.Default.DarkMode)
            {
                BackColor = SystemColors.Control;
                exportButton.ForeColor = Color.FromArgb(41, 128, 185);
                exportButton.BackColor = SystemColors.Control;
                statusLabel.ForeColor = Color.FromArgb(41, 128, 185);
            }
        }
    }
}
