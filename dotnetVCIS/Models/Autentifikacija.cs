using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetVCIS.Models
{
    public class Autentifikacija
    {
        public int id_autentifikacija { get; set; }
        public int fk_seimininkas { get; set; }
        public int fk_specialistas { get; set; }
        public string pastas { get; set; }
        public string role { get; set; }
        public string galiojimoLaikas { get; set; }
    }
}
