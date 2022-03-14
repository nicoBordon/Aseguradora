using Aseguradora.BL.Models;
using Aseguradora.BL.Repositories;
using System.Threading.Tasks;

namespace Aseguradora.BL.Services.Implements
{
    public class GeneroService:GenericService<Genero>,IGeneroService
    {
        private readonly IGeneroRepository generoRepository;
        public GeneroService(IGeneroRepository generoRepository):base(generoRepository)
        {
            this.generoRepository = generoRepository;
        }
        public async Task<bool> DeletedCheckOnEntity(int id)
        {

            return await generoRepository.DeletedCheckOnEntity(id);

        }
    }
}
