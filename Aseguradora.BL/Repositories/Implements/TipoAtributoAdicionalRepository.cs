using Aseguradora.BL.Data;
using Aseguradora.BL.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Aseguradora.BL.Repositories.Implements
{
    public class TipoAtributoAdicionalRepository:GenericRepository<TipoAtributoAdicional>,ITipoAtributoAdicionalRepository
    {
        private readonly AseguradoraContext aseguradoraContext;
        public TipoAtributoAdicionalRepository(AseguradoraContext aseguradoraContext):base(aseguradoraContext)
        {
            this.aseguradoraContext = aseguradoraContext;
        }
        public async Task<bool> DeletedCheckOnEntity(int id)
        {
            var flag = await aseguradoraContext.AtributosAdicionales.AnyAsync(x => x.TipoAtributoAdicionalID== id);
            return flag;
        }
    }
    
}
