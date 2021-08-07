using dotnetVCIS.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnetVCIS.Repositories
{
    public interface ISeimininkaiRepository
    {
        Task<IEnumerable<Seimininkas>> GetSeimininkus();
        Task<Seimininkas> GetSeimininkasByEmail(string pastas);
        Task<Seimininkas> GetSeimininkasByID(int id_seimininkas);
        Task<Seimininkas> CreateSeimininkas(Seimininkas seimininkas);
        Task<bool> UpdateSeimininkas(Seimininkas seimininkas);
        Task<bool> DeleteSeimininkas(int id_seimininkas);
    }
}