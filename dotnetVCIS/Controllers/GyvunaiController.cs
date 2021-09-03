using dotnetVCIS.Dtos;
using dotnetVCIS.Models;
using dotnetVCIS.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetVCIS.Controllers
{
    [Route("api/gyvunas")]
    [ApiController]
    public class GyvunaiController : ControllerBase
    {
        private readonly IGyvunaiRepository _repository;

        public GyvunaiController(IGyvunaiRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet] //GET /gyvunas
        [Authorize]
        public async Task<ActionResult<IEnumerable<GyvunasDTO>>> GetGyvunaiAsync()
        {
            var gyvunai = (await _repository.GetGyvunaiAsync())
                            .Select(gyvunas => gyvunas.AsDTO());

            if (gyvunai is null)
                return NotFound();

            return Ok(gyvunai);
        }
        
        [HttpGet("vartotojo")] // Reiketu pakeisti
        public async Task<ActionResult<IEnumerable<GyvunasDTO>>> GetSeimininkasGyvunaiAsync(int fk_seimininkas)
        {
            var gyvunai = (await _repository.GetSeimininkasGyvunaiAsync(fk_seimininkas))
                            .Select(gyvunas => gyvunas.AsDTO());

            if (gyvunai is null)
                return NotFound();

            return Ok(gyvunai);
        }

        [HttpDelete("{id_gyvunas}")]
        public async Task<ActionResult> DeleteSeimininkasGyvunasAsync(int id_gyvunas)
        {
            var existingGyvunas = await _repository.GetGyvunasByIdAsync(id_gyvunas);

            if (existingGyvunas is null)
                return NotFound();
            //if logika patikrinti ar tas seimininkas istrina savo gyvuna, o ne kito
            await _repository.DeleteSeimininkasGyvunasAsync(existingGyvunas);

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<GyvunasDTO>> CreateSeimininkasGyvunasAsync(CreateGyvunasDTO gyvunasDTO, int fk_seimininkas)
        {
            if (gyvunasDTO is null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            Gyvunas gyvunas = new()
            {
                fk_rusis = gyvunasDTO.fk_rusis,
                fk_seimininkas = fk_seimininkas,
                vardas = gyvunasDTO.vardas,
                gimimoMetai = gyvunasDTO.gimimoMetai,
                veisle = gyvunasDTO.veisle,
                lytis = gyvunasDTO.lytis,
                cipas = gyvunasDTO.cipas
            };

            var insertedGyvunas = await _repository.CreateSeimininkasGyvunasAsync(gyvunas);

            return Created("Created", insertedGyvunas);
        }
        [HttpPut("{id_gyvunas}")] // PUT /seimininkas/{id} // Poto paimti id iš body.
        public async Task<ActionResult> UpdateSeimininkasAsync(UpdateGyvunasDTO gyvunasDTO)
        {
            var existingGyvunas = await _repository.GetGyvunasByIdAsync(gyvunasDTO.id_gyvunas);

            if (existingGyvunas is null)
                return NotFound();

            existingGyvunas.fk_rusis = gyvunasDTO.fk_rusis;
            existingGyvunas.vardas = (string.IsNullOrEmpty(gyvunasDTO.vardas) ? existingGyvunas.vardas : gyvunasDTO.vardas);
            existingGyvunas.gimimoMetai = (string.IsNullOrEmpty(gyvunasDTO.gimimoMetai) ? existingGyvunas.gimimoMetai : gyvunasDTO.gimimoMetai);
            existingGyvunas.veisle = (string.IsNullOrEmpty(gyvunasDTO.veisle) ? existingGyvunas.veisle : gyvunasDTO.veisle);
            existingGyvunas.lytis = (string.IsNullOrEmpty(gyvunasDTO.lytis) ? existingGyvunas.lytis : gyvunasDTO.lytis);
            existingGyvunas.cipas = (string.IsNullOrEmpty(gyvunasDTO.cipas) ? existingGyvunas.cipas : gyvunasDTO.cipas);

            await _repository.UpdateSeimininkasGyvunasAsync(existingGyvunas);

            return NoContent();
        }
    }
}
