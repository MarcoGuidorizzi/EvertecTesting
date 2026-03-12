using PontoTuristicoApp.Models;

namespace PontoTuristicoApp.Repositories
{
        public interface IPontoTuristicoRepository
        {
            Task<IEnumerable<PontoTuristicoModel>> GetAllAsync();

            Task<PontoTuristicoModel?> GetByIdAsync(int id);

            Task<PontoTuristicoModel> AddAsync(PontoTuristicoModel pontoTuristico);

            Task<PontoTuristicoModel> UpdateAsync(int id, PontoTuristicoModel pontoTuristico);

            Task DeleteAsync(int id);
            
        }
}
