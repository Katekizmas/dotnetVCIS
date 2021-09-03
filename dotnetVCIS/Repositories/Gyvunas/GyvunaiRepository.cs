using Npgsql;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetVCIS.Models;

namespace dotnetVCIS.Repositories
{
    public class GyvunaiRepository : IGyvunaiRepository
    {
        private readonly PostgreSQLConfiguration _connectionString;
        public GyvunaiRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }
        public async Task<Gyvunas> GetGyvunasByIdAsync(int id_gyvunas)
        {
            var db = dbConnection();

            string query = @"
                SELECT vardas, pavadinimas AS rusis, gimimometai::TIMESTAMP::DATE, veisle, lytis, COALESCE(cipas, 'NĖRA') AS cipas, 
                id_gyvunas, fk_rusis, fk_seimininkas  FROM Gyvunas LEFT JOIN Rusis ON Gyvunas.fk_rusis = Rusis.id_rusis 
                WHERE Gyvunas.id_gyvunas = @Id_gyvunas;
            ";

            return await db.QueryFirstOrDefault(query, new { Id_gyvunas = id_gyvunas });
        }
        public async Task<Gyvunas> CreateSeimininkasGyvunasAsync(Gyvunas gyvunas)
        {
            var db = dbConnection();

            string query = @"
                INSERT INTO Gyvunas (vardas, gimimometai, veisle, lytis, cipas, fk_rusis, fk_seimininkas) 
                VALUES(@Vardas, @Gimimometai, @Veisle, @Lytis, @Cipas, @Fk_rusis, @Fk_seimininkas) 
                RETURNING id_gyvunas;
            ";

            return await db.QueryFirstOrDefaultAsync<Gyvunas>(query, new { gyvunas.vardas, gyvunas.gimimoMetai, gyvunas.veisle, gyvunas.lytis, gyvunas.cipas, gyvunas.fk_rusis, gyvunas.fk_seimininkas });
        }

        public async Task<bool> DeleteSeimininkasGyvunasAsync(Gyvunas gyvunas)
        {
            var db = dbConnection();

            string query = @"
                DELETE FROM Gyvunas WHERE id_gyvunas = @Id_gyvunas AND fk_seimininkas = @Fk_seimininkas;
            ";

            var result = await db.ExecuteAsync(query, new { gyvunas.id_gyvunas, gyvunas.fk_seimininkas});

            return result > 0;
        }

        public async Task<IEnumerable<Gyvunas>> GetGyvunaiAsync()
        {
            var db = dbConnection();

            string query = @"
                SELECT vardas, pavadinimas AS rusis, gimimometai::TIMESTAMP::DATE, veisle, lytis, COALESCE(cipas, 'NĖRA') AS cipas, 
                id_gyvunas, fk_rusis, fk_seimininkas  FROM Gyvunas LEFT JOIN Rusis ON Gyvunas.fk_rusis = Rusis.id_rusis;
            ";

            return await db.QueryAsync<Gyvunas>(query, new { });
        }

        public async Task<IEnumerable<Gyvunas>> GetSeimininkasGyvunaiAsync(int fk_seimininkas)
        {
            var db = dbConnection();

            string query = @"
                SELECT vardas, pavadinimas AS rusis, gimimometai::TIMESTAMP::DATE, veisle, lytis, COALESCE(cipas, 'NĖRA') AS cipas, 
                id_gyvunas, fk_rusis, fk_seimininkas  FROM Gyvunas LEFT JOIN Rusis ON Gyvunas.fk_rusis = Rusis.id_rusis 
                WHERE fk_seimininkas = @Fk_seimininkas ORDER BY gimimometai DESC;
            ";

            return await db.QueryAsync<Gyvunas>(query, new { Fk_seimininkas =  fk_seimininkas });
        }

        public async Task<bool> UpdateSeimininkasGyvunasAsync(Gyvunas gyvunas)
        {
            var db = dbConnection();

            string query = @"
                UPDATE Gyvunas SET vardas = @Vardas, gimimometai = @Gimimometai, veisle = @Veisle, 
                lytis = @Lytis, cipas = @Cipas, fk_rusis = @Fk_rusis 
                WHERE id_gyvunas = @Id_gyvunas AND fk_seimininkas = @Fk_seimininkas;
            ";

            var result = await db.ExecuteAsync(query, new { gyvunas.vardas, gyvunas.gimimoMetai, gyvunas.veisle, gyvunas.lytis, gyvunas.cipas, gyvunas.fk_rusis, gyvunas.id_gyvunas, gyvunas.fk_seimininkas });

            return result > 0;
        }

    }
}
