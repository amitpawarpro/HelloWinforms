using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWinforms
{
    public partial class MonthYearSelector : UserControl
    {
        public MonthYearSelector()
        {
            InitializeComponent();
            numericUpDown1.Increment = 1;
            numericUpDown1.Minimum = int.MinValue;
            numericUpDown1.Maximum = int.MaxValue;
            numericUpDown1.Value = 2024;
        }

        private void stringUpDown1_ValueRolled(object sender, EventArgs e)
        {
            if (((ValueRolledEventArgs)e).IsForword) 
                numericUpDown1.Value++;
            else
                numericUpDown1.Value--;
        }
    }
}
