using PontoTuristicoApp.Models;

namespace PontoTuristicoApp.Repositories
{
        public interface IPontoTuristicoRepository
        {

        //utilizei o async para o código ficar mais limpo, para não existir sobrecarga de processamento,
        //no caso para o código ficar mais performático no sentido de aguentar mais acessos simultaneos,
        //já que as operações de banco de dados podem ser demoradas.
        Task<IEnumerable<PontoTuristicoModel>> GetAllAsync();

            Task<PontoTuristicoModel> GetByIdAsync(int id);

            Task<PontoTuristicoModel> AddAsync(PontoTuristicoModel pontoTuristico);

            Task<PontoTuristicoModel> UpdateAsync(int id, PontoTuristicoModel pontoTuristico);

            Task DeleteAsync(int id);
            
        }
}
