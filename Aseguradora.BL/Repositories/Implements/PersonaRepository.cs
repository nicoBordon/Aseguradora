using Aseguradora.BL.Data;
using Aseguradora.BL.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Aseguradora.BL.Repositories.Implements
{
    public class PersonaRepository :GenericRepository<Persona>,IPersonaRepository
    {
        private readonly AseguradoraContext aseguradoraContext;
        public PersonaRepository(AseguradoraContext aseguradoraContext):base(aseguradoraContext)
        {
            this.aseguradoraContext = aseguradoraContext;
        }
        public async Task<bool> DeletedCheckOnEntity(int id)
        {
            var flag =await aseguradoraContext.AtributosAdicionales.AnyAsync(x=>x.PersonaID==id);
            return flag;
        }
        public async Task<Persona> GetByIdIncluyeGenero(int id)
        {
            var persona = await aseguradoraContext.Personas.Include("Genero").FirstOrDefaultAsync(x=>x.PersonaID==id);
            return persona;
        }
        public async Task<IEnumerable< Persona>> GetAllIncluyeGenero()
        {
            var personas = await aseguradoraContext.Personas.Include("Genero").ToListAsync();
            return personas;
        }

    }
}
