using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetVCIS.Models
{
    public class Istorija
    {
        public int id_istorija { get; set; }
        public int fk_gyvunas { get; set; }
        public int fk_vizitas { get; set; }
        public float svoris { get; set; }
        public string savijauta { get; set; }
        public string nustatyta { get; set; }
        public string komentarai { get; set; }
        public string paskirtasGydymas { get; set; }
        public string laikas { get; set; }
    }
}
