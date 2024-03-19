using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWinforms
{
    public partial class MonthYearSelector : UserControl
    {
        private DateTime _value;

        [EditorBrowsable()]
        [Category("Behavior")]
        public DateTime Value
        {
            get { return _value; }
            set
            {
                _value = value;
                numericUpDown1.Value = value.Year;
                stringUpDown1.Value = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList()[value.Month-1];
            }
        }

        public event EventHandler ValueChanged;

        public MonthYearSelector()
        {
            InitializeComponent();
            numericUpDown1.Increment = 1;
            numericUpDown1.Minimum = int.MinValue;
            numericUpDown1.Maximum = int.MaxValue;
            numericUpDown1.Value = 2024;

            numericUpDown1.ValueChanged += Date_ValueChanged;
            stringUpDown1.ValueChanged += Date_ValueChanged;
        }

        private void Date_ValueChanged(object sender, EventArgs e)
        {
            var monthIndex = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(stringUpDown1.Value);
            if (monthIndex < 0) return;
            _value = new DateTime((int)numericUpDown1.Value, monthIndex+1, 1);
            if(ValueChanged!=null) ValueChanged(this, new EventArgs());
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
