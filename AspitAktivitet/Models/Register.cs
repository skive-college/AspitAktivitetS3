using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspitAktivitet.Models
{
    public class Register
    {
        [Key, Column(Order = 0)]
        public int UserID { get; set; }

        [Key, Column(Order = 1)]
        public int ActivityID { get; set; }

        [Key, Column(Order = 2)]
        public DateTime Date { get; set; }
    }
}
