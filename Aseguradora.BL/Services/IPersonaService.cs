using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aseguradora.BL.Models;

namespace Aseguradora.BL.Services
{
    public interface IPersonaService:IGenericService<Persona>
    {
        Task<bool> DeletedCheckOnEntity(int id);
        Task<Persona> GetByIdIncluyeGenero(int id);
        Task<IEnumerable<Persona>> GetAllIncluyeGenero();
    }
}
