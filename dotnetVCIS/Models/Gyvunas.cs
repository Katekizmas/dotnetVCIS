using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetVCIS.Models
{
    public class Gyvunas
    {
        public int id_gyvunas { get; set; }
        public int fk_seimininkas { get; set; }
        public int fk_rusis { get; set; }
        public string vardas { get; set; }
        public string gimimoMetai { get; set; }
        public string veisle { get; set; }
        public string lytis { get; set; }
        public string cipas { get; set; }
    }
}
