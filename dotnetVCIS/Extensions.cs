using dotnetVCIS.Dtos;
using dotnetVCIS.Models;

namespace dotnetVCIS
{
    public static  class Extensions
    {
        public static SeimininkasDTO AsDTO(this Seimininkas seimininkas)
        {
            return new SeimininkasDTO(seimininkas.id_seimininkas, seimininkas.vardas, seimininkas.pavarde, seimininkas.telnr, seimininkas.pastas, seimininkas.slaptazodis);
        }
    }
}
