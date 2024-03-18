using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWinforms
{
    class Calendars
    {
        public static Calendar Gregorian = new Calendar(CalendarType.Gregorian, Color.Pink);
        public static Calendar Indian = new Calendar(CalendarType.Indian, Color.LightGreen);
        public static Calendar Japanese = new Calendar(CalendarType.Japanese, Color.Orange);
        public static Calendar Hebrew = new Calendar(CalendarType.Hebrew, Color.LightBlue);
        public static Calendar Iranian = new Calendar(CalendarType.Iranian, Color.Cyan);
        public static Calendar Chinese = new Calendar(CalendarType.Chinese, Color.Magenta);
        public static Calendar Islamic = new Calendar(CalendarType.Islamic, Color.Violet);
        public static Calendar Persian = new Calendar(CalendarType.Persian, Color.Teal);
    }
}
