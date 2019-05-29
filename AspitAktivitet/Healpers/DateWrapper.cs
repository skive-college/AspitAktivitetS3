using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspitAktivitet.Healpers
{
    public class DateWrapper
    {
        
        public DateWrapper(DateTime d)
        {
            Week = Util.getWeek(d);
            Date = d;
        }

        public int Week { get; private set; }

        public DateTime Date { get; private set; }
    }
}
