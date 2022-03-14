using Aseguradora.BL.Models;
using System.Threading.Tasks;

namespace Aseguradora.BL.Repositories
{
    public interface IGeneroRepository:IGenericRepository<Genero>
    {
        Task<bool> DeletedCheckOnEntity(int id);
    }
}
