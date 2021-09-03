using System.ComponentModel.DataAnnotations;
using System;

namespace dotnetVCIS.Dtos
{
    // Seimininkas.cs related DTOS
    public record SeimininkasDTO(int id_seimininkas, string vardas, string pavarde, string pastas, string telnr, string slaptazodis);
    public record CreateSeimininkasDTO([Required] int id_seimininkas, [Required] string vardas, [Required] string pavarde, [Required] string pastas, [Required] string telnr, [Required] string slaptazodis);
    public record UpdateSeimininkasDTO([Required] string telnr/*, [Required] string slaptazodis*/);

    // Gyvunas.cs related DTOS
    public record GyvunasDTO(int id_gyvunas, string vardas, string gimimoMetai, string veisle, string lytis, string cipas, string rusis);
    public record CreateGyvunasDTO(int fk_rusis, string vardas, string gimimoMetai, string veisle, string lytis, string cipas);
    public record UpdateGyvunasDTO(int id_gyvunas, int fk_rusis, string vardas, string gimimoMetai, string veisle, string lytis, string cipas);
    public record GyvunasReturningIdDTO(int id_gyvunas);
    // ..........
}
