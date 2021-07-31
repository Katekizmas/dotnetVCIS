using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetVCIS.Models
{
    public class Specialistas_Paslauga
    {
        public int fk_paslauga { get; set; }
        public Paslauga Paslauga { get; set; }
        public int fk_specialistas { get; set; }
        public Specialistas Specialistas { get; set; }
    }
}
