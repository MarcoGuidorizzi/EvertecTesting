using Microsoft.AspNetCore.Mvc;
using PontoTuristicoApp.Models;
using PontoTuristicoApp.Services;

namespace PontoTuristicoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PontoTuristicoController : ControllerBase
    {
        private readonly InterfacePontoTuristicoService _service;
        public PontoTuristicoController(InterfacePontoTuristicoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PontoTuristicoModel>>> Get()
        {
            var pontosTuristicos = await _service.GetAllAsync();
            return Ok(pontosTuristicos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PontoTuristicoModel>> Get(int id)
        {
            var pontosTuristicos = await _service.GetByIdAsync(id);
            if (pontosTuristicos == null)
            {
                return NotFound("Ponto Turistico não encontrado!");
            }
            return Ok(pontosTuristicos);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PontoTuristicoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    message = "Dados inválidos",
                    errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }

            await _service.AddAsync(model);
            return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PontoTuristicoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _service.UpdateAsync(id, model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
