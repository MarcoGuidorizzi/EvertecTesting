using PontoTuristicoApp.Models;
using PontoTuristicoApp.Repositories;

namespace PontoTuristicoApp.Services
{
    public class ImplementationPontoTuristicoService : InterfacePontoTuristicoService
    {
        private readonly IPontoTuristicoRepository _repository;
        public ImplementationPontoTuristicoService(IPontoTuristicoRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<PontoTuristicoModel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<PontoTuristicoModel?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<PontoTuristicoModel> AddAsync(PontoTuristicoModel pontoTuristico)
        {
            return await _repository.AddAsync(pontoTuristico);
        }
        public async Task<PontoTuristicoModel> UpdateAsync(int id, PontoTuristicoModel pontoTuristico)
        {
            return await _repository.UpdateAsync(id, pontoTuristico);
        }
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
