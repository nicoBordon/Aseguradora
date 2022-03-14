using Aseguradora.BL.Models;
using Aseguradora.BL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aseguradora.BL.Services.Implements
{
    public class PersonaService:GenericService<Persona>,IPersonaService
    {
        private readonly IPersonaRepository personaRepository;
        public PersonaService(IPersonaRepository personaRepository):base(personaRepository)
        {
            this.personaRepository = personaRepository;
        }
        public async Task<bool> DeletedCheckOnEntity(int id) {

            return await personaRepository.DeletedCheckOnEntity(id);
                
        }
        public async Task<Persona> GetByIdIncluyeGenero(int id)
        {
            return await personaRepository.GetByIdIncluyeGenero(id);
        }
        public async Task<IEnumerable<Persona>> GetAllIncluyeGenero()
        {
            return await personaRepository.GetAllIncluyeGenero();
        }
    }
}
