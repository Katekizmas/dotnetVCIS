using dotnetVCIS.Dtos;
using dotnetVCIS.DTOS;
using dotnetVCIS.Models;
using dotnetVCIS.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetVCIS.Controllers
{
    //
    [ApiController]
    [Route("seimininkas")] // [controller] /seimininkas
    public class SeimininkaiController : ControllerBase
    {
        private readonly ISeimininkaiRepository _repository;

        public SeimininkaiController(ISeimininkaiRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet] // GET /seimininkas
        public async Task<ActionResult<IEnumerable<SeimininkasDTO>>> GetSeimininkus()
        {
            //var seimininkai = repository.GetSeimininkus().Select(seimininkas => seimininkas.AsDTO());
            var seimininkai = await _repository.GetSeimininkus();
            Console.WriteLine(seimininkai);
            if(seimininkai is null)
                return NotFound();

            return Ok(seimininkai);
        }

        [HttpGet("{pastas}")] // GET /seimininkas/{pastas}
        public async Task<ActionResult<SeimininkasDTO>> GetSeimininkasByEmail(string pastas)
        {
            if (pastas is null)
                return BadRequest();

            var seimininkas = await _repository.GetSeimininkasByEmail(pastas);

            if(seimininkas is null)
                return NotFound();

            return Ok(seimininkas.AsDTO());
        }

        [HttpPost] // POST /seimininkas
        public async Task<ActionResult<SeimininkasDTO>> CreateSeimininkas(CreateSeimininkasDTO seimininkasDTO)
        {
            if (seimininkasDTO is null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            Seimininkas seimininkas = new()
            {
                vardas = seimininkasDTO.vardas,
                pavarde = seimininkasDTO.pavarde,
                telnr = seimininkasDTO.telnr,
                pastas = seimininkasDTO.pastas,
                slaptazodis = seimininkasDTO.slaptazodis
            };

            var insertedSeimininkas = await _repository.CreateSeimininkas(seimininkas);

            return Created("Created", insertedSeimininkas);
        }

        [HttpPut("{id_seimininkas}")] // PUT /seimininkas/{id} // Poto paimti id iš body.
        public async Task<ActionResult> UpdateSeimininkas(int id_seimininkas, UpdateSeimininkasDTO seimininkasDTO)
        {
            var existingSeimininkas = await _repository.GetSeimininkasByID(id_seimininkas);

            if (existingSeimininkas is null)
                return NotFound();

            Seimininkas updatedSeimininkas = existingSeimininkas with
            {
                telnr = seimininkasDTO.telnr,
                //slaptazodis = seimininkasDTO.slaptazodis
            };

            await _repository.UpdateSeimininkas(updatedSeimininkas);

            return NoContent();
        }

        [HttpDelete("{id_seimininkas}")] // DELETE /seimininkas/
        public async Task<ActionResult> DeleteSeimininkas(int id_seimininkas)
        {
            var existingSeimininkas = await _repository.GetSeimininkasByID(id_seimininkas);

            if (existingSeimininkas is null)
                return NotFound();

            await _repository.DeleteSeimininkas(id_seimininkas);

            return NoContent();
        }
    }
}
