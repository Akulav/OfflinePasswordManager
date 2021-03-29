using System;
using System.Windows.Forms;

namespace AuditScaner
{
    public partial class SuccessWindow : Form
    {
        private string parent;
        public SuccessWindow(string parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (parent == "CreateData")
            {
                this.Close();
            }
        }
    }
}
