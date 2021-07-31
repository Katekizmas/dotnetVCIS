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
    [Route("seimininkas")] // [controller] GET /seimininkai
    public class SeimininkaiController : ControllerBase
    {
        private readonly ISeimininkaiRepository repository;

        public SeimininkaiController(ISeimininkaiRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet] // GET /seimininkas
        public ActionResult<IEnumerable<SeimininkasDTO>> getSeimininkai()
        {
            var seimininkai = repository.GetSeimininkas().Select(seimininkas => seimininkas.AsDTO());

            if(seimininkai is null)
                return NotFound();

            return Ok(seimininkai);
        }
        
        [HttpGet("{id_seimininkas}")] // GET /seimininkas/{id}
        public ActionResult<Seimininkas> GetSeimininkas(Guid id_seimininkas)
        {
            var seimininkas = repository.GetSeimininkas(id_seimininkas);

            if(seimininkas is null)
                return NotFound();

            return Ok(seimininkas.AsDTO());
        }

        [HttpPost] // POST /seimininkas
        public ActionResult<SeimininkasDTO> CreateSeimininkas(CreateSeimininkasDTO seimininkasDTO)
        {
            Seimininkas seimininkas = new()
            {
                id_seimininkas = Guid.NewGuid(),
                vardas = seimininkasDTO.vardas,
                pavarde = seimininkasDTO.pavarde,
                telnr = seimininkasDTO.telnr,
                pastas = seimininkasDTO.pastas,
                slaptazodis = seimininkasDTO.slaptazodis
            };

            repository.CreateSeimininkas(seimininkas);

            return CreatedAtAction(nameof(GetSeimininkas), new { id = seimininkas.id_seimininkas }, seimininkas.AsDTO());
        }

        [HttpPut("{id_seimininkas}")] // PUT /seimininkas/{id}
        public ActionResult UpdateSeimininkas(Guid id_seimininkas, UpdateSeimininkasDTO seimininkasDTO)
        {
            var existingSeimininkas = repository.GetSeimininkas(id_seimininkas);

            if (existingSeimininkas is null)
                return NotFound();

            Seimininkas updatedSeimininkas = existingSeimininkas with
            {
                telnr = seimininkasDTO.telnr,
                slaptazodis = seimininkasDTO.slaptazodis
            };

            repository.UpdateSeimininkas(updatedSeimininkas);

            return NoContent();
        }

        [HttpDelete("{id_seimininkas}")] // DELETE /seimininkas/
        public ActionResult DeleteSeimininkas(Guid id_seimininkas)
        {
            var existingSeimininkas = repository.GetSeimininkas(id_seimininkas);

            if (existingSeimininkas is null)
                return NotFound();

            repository.DeleteSeimininkas(id_seimininkas);

            return NoContent();
        }
    }
}
