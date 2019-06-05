using AspitAktivitet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspitAktivitet.Healpers;

namespace AspitAktivitet.Models
{
    public class Planned
    {
        
        [Key, Column(Order = 1)]
        public int ActivtyID { get; set; }

        [Key, Column(Order = 0)]
        public DateTime Date { get; set; }

        
        public int WeekNumber
        {
            get
            {
                return Util.getWeek(Date);
            }
            private set
            {
                WeekNumber = Util.getWeek(Date);
            }
        }
    }
}
