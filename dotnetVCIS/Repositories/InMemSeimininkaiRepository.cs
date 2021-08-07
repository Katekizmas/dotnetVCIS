using dotnetVCIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnetVCIS.Repositories
{

    /*public class InMemSeimininkaiRepository : ISeimininkaiInterface
    {
        private readonly List<Seimininkas> seimininkai = new()
        {
            new Seimininkas
            {
                id_seimininkas = Guid.NewGuid(),
                vardas = "Paulius1",
                pavarde = "Norkus1",
                telnr = "+37061234696",
                pastas = "paulius.norkus@gmail.com1",
                slaptazodis = "paunor1"
            },
            new Seimininkas
            {
                id_seimininkas = Guid.NewGuid(),
                vardas = "Paulius2",
                pavarde = "Norkus2",
                telnr = "+37061234696",
                pastas = "paulius.norkus@gmail.com2",
                slaptazodis = "paunor1"
            },
            new Seimininkas
            {
                id_seimininkas = Guid.NewGuid(),
                vardas = "Paulius3",
                pavarde = "Norkus3",
                telnr = "+37061234696",
                pastas = "paulius.norkus@gmail.com3",
                slaptazodis = "paunor1"
            }
        };

        

        public IEnumerable<Seimininkas> GetSeimininkus()
        {
            return seimininkai;
        }
        public Seimininkas GetSeimininkas(Guid id_seimininkas)
        {
            return seimininkai.SingleOrDefault(seimininkas => seimininkas.id_seimininkas == id_seimininkas);
        }
        public void CreateSeimininkas(Seimininkas seimininkas)
        {
            seimininkai.Add(seimininkas);
        }
        public void UpdateSeimininkas(Seimininkas seimininkas)
        {
            var index = seimininkai.FindIndex(existingSeimininkas => existingSeimininkas.id_seimininkas == seimininkas.id_seimininkas);
            seimininkai[index] = seimininkas;
        }

        public void DeleteSeimininkas(Guid id_seimininkas)
        {
            var index = seimininkai.FindIndex(existingSeimininkas => existingSeimininkas.id_seimininkas == id_seimininkas);
            seimininkai.RemoveAt(index);
        }
    }*/
}
