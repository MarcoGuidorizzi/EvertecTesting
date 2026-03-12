using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PontoTuristicoApp.Models;

namespace PontoTuristicoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PontoTuristicoController : ControllerBase
    {
        private readonly Data.AppDbContext _context;

        public PontoTuristicoController(Data.AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<PontoTuristicoModel>> AddPontoTuristico([FromBody] PontoTuristicoModel pontoTuristico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.PontosTuristicos.Add(pontoTuristico);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetPontosTuristicos), 
                new { id = pontoTuristico.Id },
                pontoTuristico
            );
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PontoTuristicoModel>>> GetPontosTuristicos()
        {
            var pontosTuristicos = await _context.PontosTuristicos.ToListAsync();
            return Ok(pontosTuristicos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PontoTuristicoModel>> GetPontosTuristicos(int id)
        {
            var pontosTuristicos = await _context.PontosTuristicos.FindAsync(id);

            if (pontosTuristicos == null)
            {
                return NotFound("Ponto Turistico não encontrado!");
            }

            return Ok(pontosTuristicos);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> UpdatePontosTuristicos(int id, [FromBody] PontoTuristicoModel pontoTuristico)
        {
            var pontosTuristicos = await _context.PontosTuristicos.FindAsync(id);

            if (pontosTuristicos == null)
            {
                return NotFound("Ponto Turistico não encontrado!");
            }

            _context.Entry(pontosTuristicos).CurrentValues.SetValues(pontoTuristico);

            await _context.SaveChangesAsync();

            return StatusCode(201, pontosTuristicos);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeletePontosTuristicos(int id)
        {
            var pontosTuristicos = await _context.PontosTuristicos.FindAsync(id);

            if (pontosTuristicos == null)
            {
                return NotFound("Ponto Turistico não encontrado!");
            }

            _context.PontosTuristicos.Remove(pontosTuristicos);

            await _context.SaveChangesAsync();

            return Ok("Ponto Turistico deletado com sucesso!");
        }
    }
}
