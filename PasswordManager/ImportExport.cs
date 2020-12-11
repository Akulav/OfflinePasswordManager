using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuditScaner
{
    public partial class ImportExport : Form
    {
        private Form currentChildForm;
        public ImportExport()
        {
            InitializeComponent();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string startPath = @"c:\PasswordManager";
                    string zipPath = fbd.SelectedPath+@"\data.zip";

                    ZipFile.CreateFromDirectory(startPath, zipPath);
                   
                }
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ImportConfirm());
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.Controls.Add(childForm);
            childForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }
    }
}
