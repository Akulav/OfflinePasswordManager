using FontAwesome.Sharp;
using Microsoft.Win32;
using PasswordManager;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AuditScaner
{
    public partial class MainForm : Form
    {
        //Fields
        private IconButton currentBtn;
        private readonly Panel leftBorderBtn;
        public Form currentChildForm;
        private readonly string currentVersion = "Program version 0.1.1";
        private string key;
        Timer t = new Timer();
        public MainForm(string key)
        {
            //Import the embedded .dll
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string resourceName = new AssemblyName(args.Name).Name + ".dll";
                string resource = Array.Find(GetType().Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                {
                    byte[] assemblyData = new byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };
            

            t.Interval = 1000;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();

            InitializeComponent();
            this.Visible = false;

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            MenuPanel.Controls.Add(leftBorderBtn);
            //Form
            MaximizedBounds = Screen.FromHandle(Handle).WorkingArea;
            //Display Windows Version
            getWindowsVersion();
            //Display program version
            labelProgramVersion.Text = currentVersion;
            //Display end of initialization
            labelProgramStatus.Text = "Program status: ok";
            //Create directory
            initializeDataSet();
            //Gets transfered the key for encryption / decryption
            this.key = key;

            this.Visible = true;

        }
        //Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        //Methods

        private void getWindowsVersion()
        {
            object os_version = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "ReleaseId", 1);

            if (os_version != null)
            {
                labelWindowsVersion.Text = "Windows Build: " + os_version.ToString();
            }

            else
            {
                labelWindowsVersion.Text = "Could not read Windows Build";
            }
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }

        private void initializeDataSet()
        {
            string root = @"C:\PasswordManager";
            string subdir = @"C:\PasswordManager\Storage";
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }


            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
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
            panelDesktop.Controls.Add(childForm);
            childForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            labelTitleOfChildForm.Text = childForm.Text;

        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void checkIntegrity()
        {

        }

        private void Dashboard_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                ActivateButton(sender, RGBColors.color1);
                currentChildForm.Close();
                labelTitleOfChildForm.Text = "Home";
            }

            Reset();
        }

        private void CreateData_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            labelTitleOfChildForm.Text = "Create Data";
            OpenChildForm(new CreateData(this.key));
        }

        private void ExportTools_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            labelTitleOfChildForm.Text = "Export Tools";
            OpenChildForm(new ImportExport());
        }

        private void ViewData_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            labelTitleOfChildForm.Text = "View Data";
            OpenChildForm(new ViewData(this.key));
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            labelTitleOfChildForm.Text = "Settings";
            OpenChildForm(new About());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            labelTitleOfChildForm.Text = "Home";
        }
        //Drag Form

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FullSize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }

            else
                WindowState = FormWindowState.Normal;
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            //get current time
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;

            //time
            string time = "";

            //padding leading zero
            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ":";

            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += ":";

            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }

            //update label
            clock.Text = time;
        }
    }
}
