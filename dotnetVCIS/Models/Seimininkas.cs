using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetVCIS.Models
{
    public record Seimininkas
    {
        public int id_seimininkas { get; init; }
        public string vardas { get; init; }
        public string pavarde { get; init; }
        public string pastas { get; init; }
        public string telnr { get; init; }
        public string slaptazodis { get; init; }
    }
}
