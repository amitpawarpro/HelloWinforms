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

        public Holiday(DateTime date, string description)
        {
            Date = date;
            Description = description;
        }
    }
}
