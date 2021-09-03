using dotnetVCIS.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnetVCIS.Repositories
{
    public interface ISeimininkaiRepository
    {
        Task<IEnumerable<Seimininkas>> GetSeimininkaiAsync();
        Task<Seimininkas> GetSeimininkasByEmailAsync(string pastas);
        Task<Seimininkas> GetSeimininkasByIdAsync(int id_seimininkas);
        Task<Seimininkas> CreateSeimininkasAsync(Seimininkas seimininkas);
        Task<bool> UpdateSeimininkasAsync(Seimininkas seimininkas);
        Task<bool> DeleteSeimininkasAsync(int id_seimininkas);
    }
}