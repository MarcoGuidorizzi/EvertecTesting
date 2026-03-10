using Microsoft.EntityFrameworkCore;
using PontoTuristicoApp.Data;
using PontoTuristicoApp.Models;
using PontoTuristicoApp.Services;

namespace PontoTuristicoApp.Repositories
{
    public class ImplementationPontoTuristicoRepository : IPontoTuristicoRepository
    {
        private readonly AppDbContext _context;
        
        public ImplementationPontoTuristicoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PontoTuristicoModel>> GetAllAsync()
        {
            return await _context.PontosTuristicos.ToListAsync();
        }
        // utilizei o ? ali após o Task <PontoTuristicoModel?> para indicar que o retorno pode ser nulo, ou seja,
        // caso o id não exista no banco de dados, ele pode retornar null.
        // Até porque minha Controller já está preparada para lidar com esse cenário, retornando um NotFound()
        // caso o resultado seja null.
        public async Task<PontoTuristicoModel?> GetByIdAsync(int id)
        {
            return await _context.PontosTuristicos.FindAsync(id);
        }

        public async Task<PontoTuristicoModel> AddAsync(PontoTuristicoModel pontoTuristico)
        {
            _context.PontosTuristicos.Add(pontoTuristico);
            await _context.SaveChangesAsync();
            return pontoTuristico;
        }

        public async Task<PontoTuristicoModel> UpdateAsync(int id, PontoTuristicoModel pontoTuristico)
        {
            // Tentando buscar o registro no banco de dados
            var existingPontoTuristico = await _context.PontosTuristicos.FindAsync(id);

            if (existingPontoTuristico == null)
            {
              throw new Exception($"Ponto Turístico com ID {id} não foi encontrado no sistema.");
            }
            //Se chegar até aqui significa que o registro foi encontrado, então podemos atualizar os campos
            existingPontoTuristico.Nome = pontoTuristico.Nome;
            existingPontoTuristico.Descricao = pontoTuristico.Descricao;
            existingPontoTuristico.Localizacao = pontoTuristico.Localizacao;
            //Salva as alterações de fato no banco de dados
            await _context.SaveChangesAsync();
            return existingPontoTuristico;
        }

        public async Task DeleteAsync(int id)
        {
            var pontoTuristico = await _context.PontosTuristicos.FindAsync(id);

            if (pontoTuristico != null)
            {
                _context.PontosTuristicos.Remove(pontoTuristico);
                await _context.SaveChangesAsync();
            }
        }
    }

}