using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aseguradora.BL.Models;

namespace Aseguradora.BL.Services
{
    public interface ITipoAtributoAdicionalService:IGenericService<TipoAtributoAdicional>
    {
        Task<bool> DeletedCheckOnEntity(int id);
    }
}
