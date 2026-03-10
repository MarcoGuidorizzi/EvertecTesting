using PontoTuristicoApp.Models;

namespace PontoTuristicoApp.Repositories
{
        public interface IPontoTuristicoRepository
        {

             //utilizei o async para o código ficar mais limpo, para não existir sobrecarga de processamento,
            //no caso para o código ficar mais performático no sentido de aguentar mais acessos simultaneos,
            //já que as operações de banco de dados podem ser demoradas.
            Task<IEnumerable<PontoTuristicoModel>> GetAllAsync();

            // utilizei o ? ali após o Task <PontoTuristicoModel?> para indicar que o retorno pode ser nulo, ou seja,
            // caso o id não exista no banco de dados, ele pode retornar null.
            // Até porque minha Controller já está preparada para lidar com esse cenário, retornando um NotFound()
            // caso o resultado seja null.
            Task<PontoTuristicoModel?> GetByIdAsync(int id);

            Task<PontoTuristicoModel> AddAsync(PontoTuristicoModel pontoTuristico);

            Task<PontoTuristicoModel> UpdateAsync(int id, PontoTuristicoModel pontoTuristico);

            Task DeleteAsync(int id);
            
        }
}
