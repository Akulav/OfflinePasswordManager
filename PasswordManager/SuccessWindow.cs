using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
