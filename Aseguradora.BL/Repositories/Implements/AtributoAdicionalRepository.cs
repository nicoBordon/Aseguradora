using Aseguradora.BL.Data;
using Aseguradora.BL.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Aseguradora.BL.Repositories.Implements
{
    public class AtributoAdicionalRepository : GenericRepository<AtributoAdicional>, IAtributoAdicionalRepository
    {
        private readonly AseguradoraContext aseguradoraContext;
        public AtributoAdicionalRepository(AseguradoraContext aseguradoraContext) : base(aseguradoraContext)
        {
            this.aseguradoraContext = aseguradoraContext;
        }
        public async Task<IEnumerable<AtributoAdicional>> GetByPersonId(int id)
        {
            var personas = await aseguradoraContext.AtributosAdicionales.Where(x=>x.PersonaID==id).Include("TipoAtributoAdicional").ToListAsync();
            return personas;
        }
    }
}
