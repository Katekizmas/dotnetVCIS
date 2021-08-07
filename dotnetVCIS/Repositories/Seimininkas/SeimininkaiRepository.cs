using Dapper;
//using dotnetVCIS.DTOS;
using dotnetVCIS.Models;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnetVCIS.Repositories
{
    public class SeimininkaiRepository : ISeimininkaiRepository
    {
        private readonly PostgreSQLConfiguration _connectionString;
        public SeimininkaiRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Seimininkas>> GetSeimininkusAsync()
        {
            var db = dbConnection();

            string query = @"
                SELECT * FROM Seimininkas;
            ";

            return await db.QueryAsync<Seimininkas>(query, new { });
        }

        public async Task<Seimininkas> GetSeimininkasByEmailAsync(string pastas)
        {
            var db = dbConnection();

            string query = @"
                SELECT * FROM Seimininkas WHERE pastas = @Pastas;
            ";

            return await db.QueryFirstOrDefaultAsync<Seimininkas>(query, new { Pastas = pastas });
        }

        public async Task<Seimininkas> GetSeimininkasByIdAsync(int id_seimininkas)
        {
            var db = dbConnection();

            string query = @"
                SELECT * FROM Seimininkas WHERE id_seimininkas = @Id_seimininkas;
            ";

            return await db.QueryFirstOrDefaultAsync<Seimininkas>(query, new { Id_seimininkas = id_seimininkas });
        }

        public async Task<Seimininkas> CreateSeimininkasAsync(Seimininkas seimininkas)
        {
            var db = dbConnection();

            string query = @"
                INSERT INTO seimininkas(vardas, pavarde, pastas, telnr, slaptazodis) VALUES(@Vardas, @Pavarde, @Pastas, @Telnr, @Slaptazodis) RETURNING id_seimininkas;
            ";

            return await db.QueryFirstOrDefaultAsync<Seimininkas>(query, new { seimininkas.vardas, seimininkas.pavarde, seimininkas.pastas, seimininkas.telnr, seimininkas.slaptazodis });
        }

        public async Task<bool> UpdateSeimininkasAsync(Seimininkas seimininkas)
        {
            var db = dbConnection();

            string query = @"
                UPDATE seimininkas SET telnr = @Telnr WHERE id_seimininkas = @Id_seimininkas;
            ";

            var result = await db.ExecuteAsync(query, new { seimininkas.telnr, seimininkas.id_seimininkas });

            return result > 0;
        }

        public async Task<bool> DeleteSeimininkasAsync(int id_seimininkas)
        {
            var db = dbConnection();

            string query = @"
                DELETE FROM seimininkas WHERE id_seimininkas = @Id_seimininkas;
            ";

            var result = await db.ExecuteAsync(query, new { Id_seimininkas = id_seimininkas });

            return result > 0;
        }
    }
}
