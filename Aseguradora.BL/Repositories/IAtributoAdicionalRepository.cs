using Aseguradora.BL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aseguradora.BL.Repositories
{
    public interface IAtributoAdicionalRepository:IGenericRepository<AtributoAdicional>
    {
        Task<IEnumerable<AtributoAdicional>> GetByPersonId(int id);
    }
  
}
