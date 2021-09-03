using dotnetVCIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetVCIS.Repositories
{
    public interface IGyvunaiRepository
    {
        Task<Gyvunas> GetGyvunasByIdAsync(int id_gyvunas);
        Task<IEnumerable<Gyvunas>> GetGyvunaiAsync();
        Task<IEnumerable<Gyvunas>> GetSeimininkasGyvunaiAsync(int fk_seimininkas);
        Task<Gyvunas> CreateSeimininkasGyvunasAsync(Gyvunas gyvunas);
        Task<bool> UpdateSeimininkasGyvunasAsync(Gyvunas gyvunas);
        Task<bool> DeleteSeimininkasGyvunasAsync(Gyvunas gyvunas);

    }
}
