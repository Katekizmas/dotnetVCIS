using dotnetVCIS.Dtos;
using dotnetVCIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetVCIS
{
    public static  class Extensions
    {
        public static SeimininkasDTO AsDTO(this Seimininkas seimininkas)
        {
            return new SeimininkasDTO
            {
                id_seimininkas = seimininkas.id_seimininkas,
                vardas = seimininkas.vardas,
                pavarde = seimininkas.pavarde,
                telnr = seimininkas.telnr,
                pastas = seimininkas.pastas,
                slaptazodis = seimininkas.slaptazodis
            };
        }
    }
}
