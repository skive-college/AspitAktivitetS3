﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspitAktivitet.Models
{
    public class User
    {
        public int ID { get; set; }
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public string Password { get; set; }

        public bool Admin { get; set; }
    }
}
