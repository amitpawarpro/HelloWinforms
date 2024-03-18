using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWinforms
{
    public class Holiday
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public Calendar Calendar { get; set; }

        public Holiday(DateTime date, string description, Calendar calendar)
        {
            Date = date;
            Description = description;
            Calendar = calendar;
        }
    }

    public class Calendar
    {
        public CalendarType CalendarType { get; set; }
        public Color Color { get; set; }

        public Calendar( CalendarType calendarType, Color color)
        {
            Color = color;
            CalendarType = calendarType;
        }
    }

    public enum CalendarType
    {
        Gregorian,
        Indian,
        Japanese,
        Islamic,
        Hebrew,
        Chinese,
        Iranian,
        Persian
    }
}
