using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWinforms
{
    public class ToggleButton : CheckBox
    {
        public string ToolTipText { get; set; }

        public ToggleButton()
        {
            TextAlign = ContentAlignment.MiddleCenter;
            Appearance = Appearance.Button;
            Dock = DockStyle.Fill;
        }
    }
}
