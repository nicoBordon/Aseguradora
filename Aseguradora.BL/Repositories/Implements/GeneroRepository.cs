using Aseguradora.BL.Data;
using Aseguradora.BL.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Aseguradora.BL.Repositories.Implements
{
    public class GeneroRepository:GenericRepository<Genero>,IGeneroRepository
    {
        private readonly AseguradoraContext aseguradoraContext;
        public GeneroRepository(AseguradoraContext aseguradoraContext):base(aseguradoraContext)
        {
            this.aseguradoraContext = aseguradoraContext;

        }
        public async Task<bool> DeletedCheckOnEntity(int id)
        {
            var flag = await aseguradoraContext.Personas.AnyAsync(x => x.GeneroID == id);
            return flag;
        }
    }
}
