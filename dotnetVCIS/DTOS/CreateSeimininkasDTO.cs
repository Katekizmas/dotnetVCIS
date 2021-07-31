using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetVCIS.DTOS
{
    public record CreateSeimininkasDTO
    {
        [Required]
        public string vardas { get; init; }
        [Required]
        public string pavarde { get; init; }
        [Required]
        public string pastas { get; init; }
        [Required]
        public string telnr { get; init; }
        [Required]
        public string slaptazodis { get; init; }
    }
}
