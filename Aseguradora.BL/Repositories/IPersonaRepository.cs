using Aseguradora.BL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aseguradora.BL.Repositories
{
    public interface IPersonaRepository :IGenericRepository<Persona>
    {

        Task<bool> DeletedCheckOnEntity(int id);
        Task<Persona> GetByIdIncluyeGenero(int id);
        Task<IEnumerable<Persona>> GetAllIncluyeGenero();


    }
}
