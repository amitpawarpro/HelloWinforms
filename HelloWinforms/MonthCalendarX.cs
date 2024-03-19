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
        private readonly int _headerHeight = 20;
        private readonly Color _headerBackColor = SystemColors.ButtonFace;

        private MonthYearSelector _monthYearSelector;
        private TextBox _selectedDateTextBox;
        private TableLayoutPanel _calendarTable;
        private Panel _topPanel;
        private Panel _middlePanel;

        private List<Holiday> _holidaysList;
        private DayButton[,] _toggleButtons;
        private ToolTip _toolTip = new ToolTip() { ShowAlways = true, ToolTipIcon = ToolTipIcon.Error, BackColor = Color.LightPink };
        public MonthCalendarX()
        {
            InitializeComponent();
            InitializeCalendar();
            SetDefaults();
        }


        [EditorBrowsable()]
        [Category("Behavior")]
        public bool AllowSelectionOfHolidays { get; set; }

        private DateTime _value;

        [EditorBrowsable()]
        [Category("Behavior")]
        public DateTime Value
        {
            get { return _value; }
            set { _value = value;
                SetDateToCalendar(value.Date);
            }
        }

        private void SetDateToCalendar(DateTime value)
        {
            if (value == new DateTime()) return;
            _monthYearSelector.Value = value;
            for (int i = 0; i < 5; i++)
            {
                var button = _toggleButtons[i, (int)value.DayOfWeek];
                if ((DateTime)button.Tag == value)
                {
                    button.Checked = true;
                    break;
                }
            }
        }

        private void InitializeCalendar()
        {
            Font = new System.Drawing.Font("Courier New", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            _topPanel = new Panel();
            _topPanel.Dock = DockStyle.Top;
            _topPanel.Height = _headerHeight;
            _topPanel.BackColor = SystemColors.Control;

            _middlePanel = new Panel();
            _middlePanel.Dock = DockStyle.Fill;
            _middlePanel.BackColor = SystemColors.Control;

            _monthYearSelector = new MonthYearSelector() { Dock = DockStyle.Left };
            _monthYearSelector.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            _monthYearSelector.ValueChanged += (sender, e) => UpdateCalendar();

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

            _topPanel.Controls.Add(_monthYearSelector);

            _middlePanel.Controls.Add(_calendarTable);

            Controls.Add(_topPanel);
            Controls.Add(_middlePanel);

            _holidaysList = new List<Holiday>();
            _toggleButtons = new DayButton[6, 7];

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    _toggleButtons[i, j] = GetDayButton();
                }
            }

            // Sample holidays (you can set these through the Holidays property)
            Holidays = new List<Holiday>
        {
            new Holiday(new DateTime(2024, 1, 1), "New Year Day", Calendars.Gregorian),
            new Holiday(new DateTime(2024, 3, 29), "Good Friday", Calendars.Gregorian),

            new Holiday(new DateTime(2024, 1, 15), "Indian fest", Calendars.Indian),
            new Holiday(new DateTime(2024, 1, 15), "Gregorian fest", Calendars.Gregorian),
            new Holiday(new DateTime(2024, 1, 15), "Hebrew fest", Calendars.Hebrew),
            new Holiday(new DateTime(2024, 1, 15), "Chinese fest", Calendars.Chinese),
            new Holiday(new DateTime(2024, 1, 15), "Iranian fest", Calendars.Iranian),
            new Holiday(new DateTime(2024, 1, 15), "Islamic fest", Calendars.Islamic),
            new Holiday(new DateTime(2024, 1, 15), "Japanese fest", Calendars.Japanese),
            new Holiday(new DateTime(2024, 1, 15), "Persian fest", Calendars.Persian),

            new Holiday(new DateTime(2024, 3, 8), "Mahashivratri", Calendars.Indian),
            new Holiday(new DateTime(2024, 1, 25), "Shevat", Calendars.Hebrew),
            new Holiday(new DateTime(2024, 3, 23), "Purim", Calendars.Hebrew),
            new Holiday(new DateTime(2024, 4, 10), "Eid al Fitr", Calendars.Islamic),
            new Holiday(new DateTime(2024, 6, 16), "Eid al Adha", Calendars.Islamic),
            new Holiday(new DateTime(2024, 2, 23), "Emperor’s Birthday", Calendars.Japanese),
            new Holiday(new DateTime(2024, 4, 29), "Showa Day", Calendars.Japanese),
        };

            InitCalendar();
        }

        private void SetDefaults()
        {
            _selectedDateTextBox.Text = DateTime.Today.ToString("ddd dd-MM-yyyy");
            if (_toggleButtons[0, 0] != null)
            {
                _toggleButtons[0, 0].Checked = true; // Default to the first toggle button
            }

            _topPanel.Controls.Add(_monthYearSelector);
        }

        private void InitCalendar()
        {


            _calendarTable.Controls.Clear();
            _calendarTable.RowStyles.Clear();
            _calendarTable.RowStyles.Add(new RowStyle(SizeType.Absolute, _headerHeight));

            var dayNames = DateTimeFormatInfo.CurrentInfo.DayNames;

            for (int i = 0; i < 7; i++)
            {
                var dayButton = new DayButton
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
            if (_monthYearSelector.Value == new DateTime()) return;
            var selectedMonth = _monthYearSelector.Value.Month;
            var selectedYear = _monthYearSelector.Value.Year;

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
            if (_toggleButtons[row - 2, col] == null) _toggleButtons[row - 2, col] = GetDayButton();

            _toggleButtons[row - 2, col].Text = day.Day.ToString();

            _toggleButtons[row - 2, col].Tag = day;
            _selectedDateTextBox.Text = ((DateTime)_toggleButtons[row - 2, col].Tag).ToString("ddd dd-MMM-yyyy");

            var holidays = GetHoliday(day);

            var isWorkDay = day.DayOfWeek != DayOfWeek.Sunday && day.DayOfWeek != DayOfWeek.Saturday && holidays.Count == 0;

            _toggleButtons[row - 2, col].ForeColor = isCurrentMonth ? SystemColors.WindowText : SystemColors.GrayText;
            _toggleButtons[row - 2, col].Cursor = AllowSelectionOfHolidays ? Cursors.Default : isWorkDay ? Cursors.Default : Cursors.No;

            _toggleButtons[row - 2, col].BackgroundImage = holidays.Count == 0 ? null : Grid.GenerateBitmap(32, 32, holidays);
            _toggleButtons[row - 2, col].FlatAppearance.MouseOverBackColor = isWorkDay ? SystemColors.GradientInactiveCaption : SystemColors.Control;

            _toggleButtons[row - 2, col].BackColor = isWorkDay ? SystemColors.ButtonHighlight : SystemColors.ButtonFace;

        }

        private static string GetTooltipText(List<Holiday> holidays)
        {
            var toolTipText = string.Empty;

            if (holidays.Count > 0)
            {
                foreach (var holiday in holidays)
                {
                    toolTipText += $"{Environment.NewLine}{holiday.Description}-{holiday.Calendar.CalendarType}";
                }
            }

            return toolTipText;
        }

        private List<Holiday> GetHoliday(DateTime day)
        {
            return _holidaysList.FindAll(h => h.Date.Date == day.Date);
        }

        private DayButton GetDayButton()
        {
            var dayButton = new DayButton();
            dayButton.Size = new Size(_buttonWidth, _buttonHeight);
            dayButton.Click += (sender, e) =>
            {
                if (dayButton.Cursor == Cursors.No)
                {
                    var day = (DateTime)dayButton.Tag;
                    var holidaysText = GetTooltipText(GetHoliday(day));
                    var toolTipText = $"'{day.ToString("dddd dd MMMM yyyy")}' is a non-working day.{holidaysText}";
                    _toolTip.Show(toolTipText, _monthYearSelector, 2000);
                    _toolTip.Show(toolTipText, _monthYearSelector, 2000);
                    dayButton.Checked = false;
                    SetDateToCalendar(_value);
                    return; 
                };
                _value = (DateTime)dayButton.Tag;
                _selectedDateTextBox.Text = ((DateTime)dayButton.Tag).ToString("dd-MM-yyyy (ddd)");
                if (ValueChanged != null) ValueChanged(this, new ValueChangedEventArgs(Value));
            };
            return dayButton;
        }


        public event EventHandler ValueChanged;

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

    public class ValueChangedEventArgs: EventArgs
    {
        public DateTime Date { get; set; }
    
        public ValueChangedEventArgs( DateTime date)
        {
            Date = date;
        }
    }

}
