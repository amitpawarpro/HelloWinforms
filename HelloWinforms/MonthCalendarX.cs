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

    public partial class MonthCalendarX : UserControl
    {
        private readonly int _buttonWidth = 15;
        private readonly int _buttonHeight = 10;
        private readonly int _headerHeight = 30;
        private readonly Color _headerBackColor = Color.DarkGray;

        private ComboBox _monthComboBox;
        private NumericUpDown _yearNumericUpDown;
        private TextBox _selectedDateTextBox;
        private TableLayoutPanel _calendarTable;
        private Panel _topPanel;
        private Panel _middlePanel;
        private Panel _bottomPanel;

        private List<Holiday> _holidaysList;
        private ToggleButton[,] _toggleButtons;
        private ToolTip _toolTip = new ToolTip();
        public MonthCalendarX()
        {
            InitializeComponent();
            InitializeCalendar();
            SetDefaults();
        }

        private void InitializeCalendar()
        {
            Font = new System.Drawing.Font("Courier New", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            _topPanel = new Panel();
            _topPanel.Dock = DockStyle.Top;
            _topPanel.Height = _headerHeight;
            _topPanel.BackColor = SystemColors.ControlDarkDark;

            _middlePanel = new Panel();
            _middlePanel.Dock = DockStyle.Fill;
            _middlePanel.BackColor = SystemColors.ControlDark;

            _bottomPanel = new Panel();
            _bottomPanel.Dock = DockStyle.Bottom;
            _bottomPanel.Height = _headerHeight;
            _bottomPanel.BackColor = SystemColors.ControlDarkDark;

            _monthComboBox = new ComboBox();
            _monthComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _monthComboBox.Items.AddRange(Enum.GetNames(typeof(Months)));
            _monthComboBox.SelectedIndex = DateTime.Today.Month - 1; // Default to current month
            _monthComboBox.SelectedIndexChanged += (sender, e) => UpdateCalendar();

            _yearNumericUpDown = new NumericUpDown();
            _yearNumericUpDown.Minimum = 1900;
            _yearNumericUpDown.Maximum = 2100;
            _yearNumericUpDown.Value = DateTime.Today.Year; // Default to current year
            _yearNumericUpDown.Dock = DockStyle.Right;
            _yearNumericUpDown.TextAlign = HorizontalAlignment.Right;
            _yearNumericUpDown.ValueChanged += (sender, e) => UpdateCalendar();

            _selectedDateTextBox = new TextBox();
            _selectedDateTextBox.ReadOnly = true;
            _selectedDateTextBox.BackColor = SystemColors.Window;
            _selectedDateTextBox.Dock = DockStyle.Fill;
            _selectedDateTextBox.TextAlign = HorizontalAlignment.Center;
            _selectedDateTextBox.Visible = true;

            _calendarTable = new TableLayoutPanel();
            //_calendarTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            _calendarTable.RowStyles.Add(new RowStyle(SizeType.Absolute, _headerHeight));
            _calendarTable.Dock = DockStyle.Fill;

            for (int i = 0; i < 7; i++)
            {
                _calendarTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / 7));
            }

            _topPanel.Controls.Add(_monthComboBox);
            _topPanel.Controls.Add(_yearNumericUpDown);

            _middlePanel.Controls.Add(_calendarTable);

            _bottomPanel.Controls.Add(_selectedDateTextBox);

            Controls.Add(_topPanel);
            Controls.Add(_middlePanel);
            Controls.Add(_bottomPanel);

            _holidaysList = new List<Holiday>();
            _toggleButtons = new ToggleButton[6, 7];

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    _toggleButtons[i, j] = GetToggleButton();
                }
            }

            // Sample holidays (you can set these through the Holidays property)
            Holidays = new List<Holiday>
        {
            new Holiday(new DateTime(2024, 1, 1), "New Year Day"),
             new Holiday(new DateTime(2024, 7, 11), "Amit's Day"),
            new Holiday(new DateTime(2024, 12, 25), "Christmas"),
            new Holiday(new DateTime(2024, 7, 4), "Independence Day"),
            new Holiday(new DateTime(2024, 9, 2), "Labor Day")
        };

            InitCalendar();
        }

        private void SetDefaults()
        {
            _selectedDateTextBox.Text = DateTime.Today.ToString("dd-MM-yyyy (ddd)");
            if (_toggleButtons[0, 0] != null)
            {
                //_toggleButtons[0, 0].Checked = true; // Default to the first toggle button
            }

            _monthComboBox.SelectedIndex = 0;
        }

        private void InitCalendar()
        {


            _calendarTable.Controls.Clear();
            _calendarTable.RowStyles.Clear();
            _calendarTable.RowStyles.Add(new RowStyle(SizeType.Absolute, _headerHeight));

            var dayNames = DateTimeFormatInfo.CurrentInfo.DayNames;

            for (int i = 0; i < 7; i++)
            {
                var dayButton = new Button
                {
                    Text = dayNames[i].Substring(0, 3),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = _headerBackColor,
                    ForeColor = Color.White,
                    Enabled = false
                };
                _calendarTable.Controls.Add(dayButton, i, 1);
            }
            for (int row = 2; row <= 7; row++)
            {
                _calendarTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / 6));

                for (int col = 0; col < 7; col++)
                {
                    _calendarTable.Controls.Add(_toggleButtons[row - 2, col], col, row);
                }
            }
        }

        private void UpdateCalendar()
        {
            if (_monthComboBox.SelectedItem == null) return;

            var selectedMonth = (Months)Enum.Parse(typeof(Months), _monthComboBox.SelectedItem.ToString());
            var selectedYear = (int)_yearNumericUpDown.Value;
            var firstDayOfMonth = new DateTime(selectedYear, (int)selectedMonth, 1);
            var daysInMonth = DateTime.DaysInMonth(selectedYear, (int)selectedMonth);

            var currentDay = firstDayOfMonth;

            // Calculate the number of days to show from the previous month
            int daysBefore = ((int)currentDay.DayOfWeek - (int)DayOfWeek.Sunday + 7) % 7; // Ensure positive value
            for (int row = 2; row <= 7; row++)
            {
                _calendarTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / 6));

                for (int col = 0; col < 7; col++)
                {
                    if ((row - 2) * 7 + col < daysBefore)
                    {
                        // Display toggle buttons for the previous month
                        var prevMonthDay = firstDayOfMonth.AddDays(-daysBefore + (row - 2) * 7 + col);
                        DisplayToggleButton(row, col, prevMonthDay, false);
                    }
                    else if ((row - 2) * 7 + col - daysBefore < daysInMonth)
                    {
                        // Display toggle buttons for the current month
                        var currentMonthDay = firstDayOfMonth.AddDays((row - 2) * 7 + col - daysBefore);
                        DisplayToggleButton(row, col, currentMonthDay, true);
                    }
                    else
                    {
                        // Display toggle buttons for the next month
                        var nextMonthDay = firstDayOfMonth.AddMonths(1).AddDays((row - 2) * 7 + col - daysBefore - daysInMonth);
                        DisplayToggleButton(row, col, nextMonthDay, false);
                    }
                }
            }
        }

        private void DisplayToggleButton(int row, int col, DateTime day, bool isCurrentMonth)
        {
            if (_toggleButtons[row - 2, col] == null)
            {
                _toggleButtons[row - 2, col] = GetToggleButton();
            }
            _toggleButtons[row - 2, col].Text = day.Day.ToString();

            _toggleButtons[row - 2, col].Tag = day;
            _selectedDateTextBox.Text = ((DateTime)_toggleButtons[row - 2, col].Tag).ToString("ddd dd-MMM-yyyy");

            string toolTip = GetToolTip(day);
            _toggleButtons[row - 2, col].ForeColor = string.IsNullOrEmpty(toolTip) ? Color.Black : Color.Red;

            _toolTip.SetToolTip(_toggleButtons[row - 2, col], toolTip);
            _toggleButtons[row - 2, col].BackColor = isCurrentMonth ? SystemColors.Control : Color.FromArgb(200, 200, 200);
        }

        private string GetToolTip(DateTime day)
        {
            if (day.DayOfWeek == DayOfWeek.Sunday || day.DayOfWeek == DayOfWeek.Saturday) return day.DayOfWeek.ToString();
            Holiday holiday = _holidaysList.FirstOrDefault(h => h.Date.Date == day.Date);
            if (holiday != null) return holiday.Description;

            return string.Empty;
        }

        private ToggleButton GetToggleButton()
        {
            var toggleButton = new ToggleButton();
            toggleButton.Size = new Size(_buttonWidth, _buttonHeight);
            toggleButton.Click += (sender, e) =>
            {
                if (toggleButton.ForeColor == Color.Red) { toggleButton.Checked = false; return; };
                foreach (ToggleButton button in _toggleButtons)
                {
                    if (button != null)
                    {
                        button.Checked = false;
                    }
                }
                _selectedDateTextBox.Text = ((DateTime)toggleButton.Tag).ToString("dd-MM-yyyy (ddd)");

            };
            return toggleButton;
        }

        public List<Holiday> Holidays
        {
            get { return _holidaysList; }
            set
            {
                _holidaysList = value;
                UpdateCalendar();
            }
        }

        private void EnhancedCalendar_Paint(object sender, PaintEventArgs e)
        {
            // Draw border for the main control
            using (Pen pen = new Pen(Color.Black, 2))
            {
                e.Graphics.DrawRectangle(pen, this.ClientRectangle.X, this.ClientRectangle.Y,
                    this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);
            }
        }
    }
}
