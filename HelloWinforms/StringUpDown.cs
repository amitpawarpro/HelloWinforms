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
    public partial class StringUpDown : UserControl
    {
        string[]? months;

        private string _value;
        [EditorBrowsable()]
        [Category("Behavior")]
        public String Value
        {
            get { return _value; }
            set
            {
                _value = value;
                nudMonthIndex.Value = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(value);
            }
        }

        public string[] Months
        {
            get { return months; }
            set
            {
                months = value;
                SetContextMenu();
            }
        }

        public event EventHandler ValueChanged;
        public event EventHandler ValueRolled;

        private void SetContextMenu()
        {
            var cmsMonths = new ContextMenuStrip();

            foreach (var month in months)
            {
                var tsMenu = new ToolStripMenuItem(month);
                tsMenu.Click += (s, e) => { nudMonthIndex.Value = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(month); };
                cmsMonths.Items.Add(tsMenu);
            }

            lblMonthName.ContextMenuStrip = cmsMonths;
            lblMonthName.MouseWheel += (s, e) => { SendKeys.Send(e.Delta > 0 ? "{UP}" : "{DOWN}"); };
            lblMonthName.Click += (s, e) => { cmsMonths.Show(Cursor.Position); };

        }

        public StringUpDown()
        {
            InitializeComponent();
            Months = DateTimeFormatInfo.CurrentInfo.MonthNames.SkipLast(1).ToArray();
            nudMonthIndex.Increment = 1;
            nudMonthIndex.Minimum = int.MinValue;
            nudMonthIndex.Maximum = int.MaxValue;
            nudMonthIndex.ValueChanged += NudMonthIndex_ValueChanged;
        }

        private void NudMonthIndex_ValueChanged(object sender, EventArgs e)
        {
            var monthIndex = (int)Math.Abs(nudMonthIndex.Value % 12);

            if (monthIndex == months.Length - 1 && lblMonthName.Text == months[0])
            {
                if (ValueRolled != null) ValueRolled(this, new ValueRolledEventArgs(false));
            }
            else if (monthIndex == 0 && lblMonthName.Text == months[months.Length - 1])
            {
                if (ValueRolled != null) ValueRolled(this, new ValueRolledEventArgs(true));
            }

            lblMonthName.Text = months[monthIndex];
            if (ValueChanged != null) ValueChanged(this, new EventArgs());
        }
    }

    public class ValueRolledEventArgs : EventArgs
    {
        public bool IsForword { get; set; }

        public ValueRolledEventArgs(bool isForword)
        {
            IsForword = isForword;
        }
    }
}
