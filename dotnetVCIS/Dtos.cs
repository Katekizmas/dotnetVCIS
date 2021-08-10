using System.ComponentModel.DataAnnotations;
using System;

namespace dotnetVCIS.Dtos
{
    // All Seimininkas.cs related DTOS
    public record SeimininkasDTO(int id_seimininkas, string vardas, string pavarde, string pastas, string telnr, string slaptazodis);
    public record CreateSeimininkasDTO([Required] int id_seimininkas, [Required] string vardas, [Required] string pavarde, [Required] string pastas, [Required] string telnr, [Required] string slaptazodis);
    public record UpdateSeimininkasDTO([Required] string telnr/*, [Required] string slaptazodis*/);

    // Other DTOS
    // ..........
}
