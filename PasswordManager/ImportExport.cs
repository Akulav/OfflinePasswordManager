using PasswordManager;
using System;
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
            ImportExportClass.export();
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
