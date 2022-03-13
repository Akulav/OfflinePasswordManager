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

        public static void changeTheme(ControlCollection Controls, Form parent)
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
    }
}
