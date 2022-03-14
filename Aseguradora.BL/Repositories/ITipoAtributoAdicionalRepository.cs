using Aseguradora.BL.Models;
using System.Threading.Tasks;

namespace Aseguradora.BL.Repositories
{
    public interface ITipoAtributoAdicionalRepository:IGenericRepository<TipoAtributoAdicional>
    {
        Task<bool> DeletedCheckOnEntity(int id);
    }
   
}
