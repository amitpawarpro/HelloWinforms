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
        public event EventHandler ProjectStageChanged;


        public string Stage
        {
            get { return ""; }
        }

        private void monthCalendarx1_DateChanged(object sender, EventArgs e)
        {
            if (isUpdating || this.DropState != eDropState.Dropped) return;

            this.CloseDropDown();
            //this.Text = this.Stage + " Stage";
            //if (ProjectStageChanged != null)
            //    ProjectStageChanged(null, null);
        }
    }
}
