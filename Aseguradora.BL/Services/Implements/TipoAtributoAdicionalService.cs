using Aseguradora.BL.Models;
using Aseguradora.BL.Repositories;
using System.Threading.Tasks;

namespace Aseguradora.BL.Services.Implements
{
    public class TipoAtributoAdicionalService:GenericService<TipoAtributoAdicional>,ITipoAtributoAdicionalService
    {
        private readonly ITipoAtributoAdicionalRepository tipoAtributoAdicionalRepository;
        public TipoAtributoAdicionalService(ITipoAtributoAdicionalRepository tipoAtributoAdicionalRepository):base(tipoAtributoAdicionalRepository)
        {
            this.tipoAtributoAdicionalRepository = tipoAtributoAdicionalRepository;
        }
        public async Task<bool> DeletedCheckOnEntity(int id) {
            return await tipoAtributoAdicionalRepository.DeletedCheckOnEntity(id);
        }
    }
}
