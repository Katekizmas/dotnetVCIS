using dotnetVCIS.Dtos;
using dotnetVCIS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetVCIS.Repositories
{
    public class PgSeimininkaiRepository : ISeimininkaiInterface
    {
        private readonly IConfiguration _configuration;
        public PgSeimininkaiRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void CreateSeimininkas(Seimininkas seimininkas)
        {
            throw new NotImplementedException();
        }

        public void DeleteSeimininkas(Guid id_seimininkas)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Seimininkas> GetSeimininkus()
        {
            string query = @"
                SELECT * FROM Seimininkas;
            ";

            List<Seimininkas> table = new List<Seimininkas>();
            using (NpgsqlConnection myConn = new NpgsqlConnection(_configuration.GetConnectionString("VeterinarijaAppCon")))
            {
                myConn.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myConn))
                {
                    NpgsqlDataReader myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        Seimininkas objSeimininkas = new()
                        {
                            //id_seimininkas = (Guid)myReader["id_seimininkas"],
                            vardas = (String)myReader["vardas"],
                            pavarde = (String)myReader["pavarde"],
                            telnr = (String)myReader["telnr"],
                            pastas = (String)myReader["pastas"],
                            slaptazodis = (String)myReader["slaptazodis"]
                        };
                        table.Add(objSeimininkas);
                    }

                    myReader.Close();
                    myConn.Close();
                }
            }
            return table;
        }

        public Seimininkas GetSeimininkas(Guid id_seimininkas)
        {
            string query = @"
                SELECT * FROM Seimininkas;
            ";

            SeimininkasDTO table = new SeimininkasDTO();
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(_configuration.GetConnectionString("VeterinarijaAppCon")))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    //table.Load(myReader);
                    while(myReader.Read())
                    {
                    }

                    myReader.Close();
                    myCon.Close();

                }
            }
            return null;
            //return new JsonResult(table);
        }

        public void UpdateSeimininkas(Seimininkas seimininkas)
        {
            throw new NotImplementedException();
        }
    }
}
