﻿using PasswordManager;
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
            Data dt = settingUtilities.getSettings();
            if (!dt.dark)
            {
                Colors.ChangeTheme(Controls, this, "light");
            }
        }
    }
}
