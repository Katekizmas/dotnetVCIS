using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetVCIS.Models
{
    public class Skiepas
    {
        public int id_skiepas { get; set; }
        public int fk_vizitas { get; set; }
        public string pavadinimas { get; set; }
        public string laikas { get; set; }
    }
}
