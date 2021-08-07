using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetVCIS.DTOS
{
    public record UpdateSeimininkasDTO
    {
        [Required]
        public string telnr { get; init; }
        /*[Required]
        public string slaptazodis { get; init; }*/
    }
}
