using dotnetVCIS.Dtos;
using dotnetVCIS.Models;
using System.Collections.Generic;

namespace dotnetVCIS
{
    public static  class Extensions
    {
        public static SeimininkasDTO AsDTO(this Seimininkas seimininkas)
        {
            return new SeimininkasDTO(seimininkas.id_seimininkas, seimininkas.vardas, seimininkas.pavarde, seimininkas.telnr, seimininkas.pastas, seimininkas.slaptazodis);
        }
        public static GyvunasDTO AsDTO(this Gyvunas gyvunas)
        {
            return new GyvunasDTO(gyvunas.id_gyvunas, gyvunas.vardas, gyvunas.gimimoMetai, gyvunas.veisle, gyvunas.lytis, gyvunas.cipas, gyvunas.rusis);
        }
    }
}
