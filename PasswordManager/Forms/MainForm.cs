using FontAwesome.Sharp;
using PasswordManager;
using PasswordManager.Utilities;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SeePass
{
    public partial class MainForm : Form
    {
        //Fields
        private IconButton currentBtn;
        private readonly Panel leftBorderBtn;
        public Form currentChildForm;
        private readonly string fullKey;

        public MainForm(string key, string username, int PIM)
        {
            //Loads the form
            InitializeComponent();

            leftBorderBtn = new Panel
            {
                Size = new Size(7, 60)
            };
            MenuPanel.Controls.Add(leftBorderBtn);
            //Form
            winVer.Text = Utility.GetWindowsVersion();
            MaximizedBounds = Screen.FromHandle(Handle).WorkingArea;
            //Gets transfered the key for encryption / decryption

            fullKey = Crypto.FinalKey(key + username, key, PIM);
            CheckTheme();

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
        private void Timer_Tick(object sender, EventArgs e)
        {
            clock.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void CheckTheme()
        {
            if (!PasswordManager.Properties.Settings.Default.DarkMode)
            {
                MenuPanel.BackColor = Colors.back_light;
                panelTitleBar.BackColor = Colors.back_light;
                panelDesktop.BackColor = SystemColors.Control;
                labelTitleOfChildForm.ForeColor = Color.White;
                winVer.ForeColor = Colors.back_light;
                clock.ForeColor = Colors.back_light;
                Minimize.IconColor = Color.White;
                Exit.IconColor = Color.White;
            }
        }
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                if (PasswordManager.Properties.Settings.Default.DarkMode)
                {
                    currentBtn.BackColor = Colors.back_darker;
                }
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
                if (PasswordManager.Properties.Settings.Default.DarkMode)
                {
                    currentBtn.BackColor = Colors.back_darker;
                }
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }


        private void Dashboard_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                ActivateButton(sender, RGBColors.color1);
                currentChildForm.Close();
                labelTitleOfChildForm.Text = "Home";
            }
        }

        private void CreateData_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            labelTitleOfChildForm.Text = "Create Data";
            OpenChildForm(new CreateData(fullKey));
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
            OpenChildForm(new ViewData(fullKey));
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            labelTitleOfChildForm.Text = "Settings";
            OpenChildForm(new Config());
        }
        //Drag Form

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void PanelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}