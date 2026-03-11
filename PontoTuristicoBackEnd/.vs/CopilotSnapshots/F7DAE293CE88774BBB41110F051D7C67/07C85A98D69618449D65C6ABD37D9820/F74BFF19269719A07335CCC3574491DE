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
            //se meu model state não for válido, ou seja, se os dados que eu recebi não forem válidos,
            //eu vou retornar um bad request, com o meu model state, para o cliente saber o que deu errado a validação dos dados recebidos.
            //no caso a model state me assegura que a validação que coloquei na model (required) por exemplo, está sendo respeitada,
            //ou seja, se eu recebi um ponto turistico sem nome, a model state vai me dizer que o nome é obrigatório,
            //e eu vou retornar um bad request para o cliente, informando que o nome é obrigatório.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.PontosTuristicos.Add(pontoTuristico);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetPontosTuristicos), 
                new { id = pontoTuristico.Id },
                new {message = "Ponto turístico criado com sucesso!", data = pontoTuristico}
            );
        }

        [HttpGet]
        //Estou usando async e await pois o acesso ao banco não é instantaneo, quando for chamar essa requisicao ao banco, preciso esperar ele retornar, para o meu codigo continuar executando.
        //vou esperar o banco retornar uma lista, enquanto nao retorna, o meu codigo nao continua. Pois se eu não colocar o await ele vai esperar o retorno automaticamente, mas o banco sempre tem um delay
        //entao preciso travar o codigo, esperando a resposta chegar, para depois continuar a execução do meu codigo. Se eu não fizer isso, o meu codigo vai continuar executando, e quando chegar na linha de return, o banco ainda não vai ter retornado a lista, e ai vai dar um erro.
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