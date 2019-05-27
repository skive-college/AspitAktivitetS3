using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspitAktivitet.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Navn { get; set; }

        public bool Admin { get; set; }
    }
}
