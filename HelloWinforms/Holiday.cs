using System;
using System.Collections.Generic;
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

    public enum Calendar
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
