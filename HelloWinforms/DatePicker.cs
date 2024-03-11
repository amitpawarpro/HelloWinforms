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
    public partial class DatePicker : DropDownControl
    {
        private bool isUpdating;
        public DatePicker()
        {
            InitializeComponent();
            InitializeDropDown(panel1);
            isUpdating = false;
        }
        public event EventHandler ValueChanged;

        public bool AllowSelectionOfHolidays
        {
            get { return monthCalendarx1.AllowSelectionOfHolidays; }
            set { monthCalendarx1.AllowSelectionOfHolidays = value; }
        }


        public DateTime Value
        {
            get { return monthCalendarx1.Value; }
            set { monthCalendarx1.Value = value;
                Text = monthCalendarx1.Value.ToShortDateString();
            }
        }

        private void monthCalendarx1_DateChanged(object sender, EventArgs e)
        {
            if (isUpdating || this.DropState != eDropState.Dropped) return;
            Value = ((ValueChangedEventArgs)e).Date;
            this.CloseDropDown();
            if (ValueChanged != null) ValueChanged(this, e);
        }
    }
}
