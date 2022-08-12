using Newtonsoft.Json;
using PasswordManager;
using PasswordManager.Resources;
using PasswordManager.Utilities;
using System;
using System.IO;
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
            Data dt = JsonConvert.DeserializeObject<Data>(File.ReadAllText(Paths.settings));
            if (!dt.dark)
            {
                Colors.ChangeTheme(Controls, this, "light");
            }
        }
    }
}
