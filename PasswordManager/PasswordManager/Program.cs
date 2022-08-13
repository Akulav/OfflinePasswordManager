using System;
using System.Windows.Forms;

namespace SeePass
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Login lg = new Login();
            lg.Show();
            Application.Run();
        }
    }
}
