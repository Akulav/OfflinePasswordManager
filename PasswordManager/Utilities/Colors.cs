using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace PasswordManager.Utilities
{
    class Colors
    {
        public static readonly Color back_light = Color.FromArgb(41, 128, 185);
        public static readonly Color back_dark = Color.FromArgb(34, 33, 74);
        public static readonly Color back_darker = Color.FromArgb(31, 30, 68);

        public static void ChangeTheme(ControlCollection Controls, Form parent, string theme)
        {
            if (theme == "light")
            {
                parent.BackColor = SystemColors.Control;

                for (int i = 0; i < Controls.Count; i++)
                {
                    if (Controls[i] is Label)
                    {
                        Controls[i].ForeColor = back_light;
                    }

                    else if (Controls[i] is IconButton)
                    {
                        Controls[i].BackColor = SystemColors.Control;
                        Controls[i].ForeColor = back_light;
                    }

                }
            }

            else if (theme == "dark")
            {
                parent.BackColor = back_dark;

                for (int i = 0; i < Controls.Count; i++)
                {
                    if (Controls[i] is Label)
                    {
                        Controls[i].ForeColor = Color.Gainsboro;
                        Controls[i].BackColor = back_dark;
                    }

                    else if (Controls[i] is IconButton)
                    {
                        Controls[i].BackColor = back_dark;
                        Controls[i].ForeColor = Color.Gainsboro;
                    }

                    else if (Controls[i] is Panel)
                    {
                        Controls[i].BackColor = back_dark;
                    }

                }
            }
        }
    }
}
