using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWinforms
{
    public class DayButton : RadioButton
    {
        public DayButton()
        {
            Margin = new Padding(0);
            TextAlign = ContentAlignment.MiddleCenter;
            Appearance = Appearance.Button;
            Dock = DockStyle.Fill;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderColor = Color.LightGray;
            FlatAppearance.CheckedBackColor = SystemColors.GradientActiveCaption;
            FlatAppearance.MouseOverBackColor = SystemColors.GradientInactiveCaption;
        }
    }
}
