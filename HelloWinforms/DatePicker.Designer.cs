
namespace HelloWinforms
{
    partial class DatePicker
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatePicker));
            this.panel1 = new System.Windows.Forms.Panel();
            this.monthCalendarx1 = new HelloWinforms.MonthCalendarX();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.monthCalendarx1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 150);
            this.panel1.TabIndex = 0;
            // 
            // monthCalendarx1
            // 
            this.monthCalendarx1.AllowSelectionOfHolidays = false;
            this.monthCalendarx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monthCalendarx1.Font = new System.Drawing.Font("Courier New", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.monthCalendarx1.Location = new System.Drawing.Point(0, 0);
            this.monthCalendarx1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.monthCalendarx1.Name = "monthCalendarx1";
            this.monthCalendarx1.Size = new System.Drawing.Size(150, 150);
            this.monthCalendarx1.TabIndex = 0;
            this.monthCalendarx1.Value = new System.DateTime(((long)(0)));
            this.monthCalendarx1.ValueChanged += new System.EventHandler(this.monthCalendarx1_DateChanged);
            // 
            // DatePicker
            // 
            this.AnchorSize = new System.Drawing.Size(150, 21);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "DatePicker";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MonthCalendarX monthCalendarx1;
    }
}
