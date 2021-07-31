using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetVCIS.Models
{
    public class Paslauga
    {
        public int id_paslauga { get; set; }
        public string pavadinimas { get; set; }
        public string aprasymas { get; set; }
        public float kaina { get; set; }
        public List<Specialistas_Paslauga> Specialistas_Paslaugos { get; set; }
    }
}
