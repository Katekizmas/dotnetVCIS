using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetVCIS.Models
{
    public class Specialistas
    {
        public int id_specialistas { get; set; }
        public string pareigos { get; set; }
        public string role { get; set; }
        public string darboLaikasNuo { get; set; }
        public string darboLaikasIki { get; set; }
        public string pastabos { get; set; }
        public List<Specialistas_Paslauga> Specialistas_Paslaugos { get; set; }
    }
}
