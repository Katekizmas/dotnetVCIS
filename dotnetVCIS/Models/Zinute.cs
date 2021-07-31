using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetVCIS.Models
{
    public class Zinute
    {
        public int id_zinute { get; set; }
        public int fk_vizitas { get; set; }
        public int fk_siuntejas { get; set; }
        public int fk_gavejas { get; set; }
        public string zinute { get; set; }
        public string laikas { get; set; }
        public string busena { get; set; }
    }
}
