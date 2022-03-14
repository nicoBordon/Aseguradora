using Aseguradora.BL.Models;
using Aseguradora.BL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aseguradora.BL.Services.Implements
{
    public class AtributoAdicionalService:GenericService<AtributoAdicional>,IAtributoAdicionalService
    {
        private readonly IAtributoAdicionalRepository atributoAdicionalRepository;
        public AtributoAdicionalService(IAtributoAdicionalRepository atributoAdicionalRepository):base(atributoAdicionalRepository)
        {
            this.atributoAdicionalRepository = atributoAdicionalRepository;
        }
        public async Task<IEnumerable<AtributoAdicional>> GetByPersonId(int id)
        {
            return await atributoAdicionalRepository.GetByPersonId( id);
        }
    }
}
