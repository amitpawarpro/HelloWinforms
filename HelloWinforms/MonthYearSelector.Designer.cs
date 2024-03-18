
namespace HelloWinforms
{
    partial class MonthYearSelector
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
            this.stringUpDown1 = new HelloWinforms.StringUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // stringUpDown1
            // 
            this.stringUpDown1.Location = new System.Drawing.Point(0, 0);
            this.stringUpDown1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stringUpDown1.Months = new string[] {
        "January",
        "February",
        "March",
        "April",
        "May",
        "June",
        "July",
        "August",
        "September",
        "October",
        "November",
        "December"};
            this.stringUpDown1.Name = "stringUpDown1";
            this.stringUpDown1.Size = new System.Drawing.Size(121, 23);
            this.stringUpDown1.TabIndex = 0;
            this.stringUpDown1.Value = null;
            this.stringUpDown1.ValueRolled += new System.EventHandler(this.stringUpDown1_ValueRolled);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Courier New", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericUpDown1.Location = new System.Drawing.Point(119, 0);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(50, 18);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // MonthYearSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.stringUpDown1);
            this.Name = "MonthYearSelector";
            this.Size = new System.Drawing.Size(166, 18);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private StringUpDown stringUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}
