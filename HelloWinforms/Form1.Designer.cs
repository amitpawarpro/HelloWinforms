
namespace HelloWinforms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.monthCalendarx1 = new HelloWinforms.MonthCalendarX();
            this.datePicker1 = new HelloWinforms.DatePicker();
            this.SuspendLayout();
            // 
            // monthCalendarx1
            // 
            this.monthCalendarx1.Font = new System.Drawing.Font("Courier New", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.monthCalendarx1.Location = new System.Drawing.Point(11, 11);
            this.monthCalendarx1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.monthCalendarx1.Name = "monthCalendarx1";
            this.monthCalendarx1.Size = new System.Drawing.Size(271, 276);
            this.monthCalendarx1.TabIndex = 0;
            // 
            // datePicker1
            // 
            this.datePicker1.AnchorSize = new System.Drawing.Size(121, 21);
            this.datePicker1.BackColor = System.Drawing.Color.White;
            this.datePicker1.DockSide = HelloWinforms.DropDownControl.eDockSide.Left;
            this.datePicker1.Location = new System.Drawing.Point(471, 104);
            this.datePicker1.Name = "datePicker1";
            this.datePicker1.Size = new System.Drawing.Size(121, 21);
            this.datePicker1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.datePicker1);
            this.Controls.Add(this.monthCalendarx1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private MonthCalendarX monthCalendarx1;
        private DatePicker datePicker1;
    }
}

