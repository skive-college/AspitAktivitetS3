using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspitAktivitet.Models
{
    public class Activity
    {
        public int ID { get; set; }
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
    }
}
