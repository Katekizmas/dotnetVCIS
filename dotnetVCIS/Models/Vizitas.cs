using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetVCIS.Models
{
    public class Vizitas
    {
        public int id_vizitas { get; set; }
        public int fk_seimininkas { get; set; }
        public int fk_gyvunas { get; set; }
        public int fk_specialistas { get; set; }
        public int fk_paslauga { get; set; }
        public string diena { get; set; }
        public string pradzia { get; set; }
        public string pabaiga { get; set; }
        public string pastabos { get; set; }
        public string busena { get; set; }
    }
}
