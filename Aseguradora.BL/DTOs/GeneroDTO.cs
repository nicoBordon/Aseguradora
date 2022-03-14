using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Aseguradora.BL.DTOs
{
    public class GeneroDTO
    {
        [Required(ErrorMessage = "El  ID genero es obligatorio")]
        public int GeneroID { get; set; }
        [Required(ErrorMessage = "El  nombre del genero  es obligatorio")]
        [StringLength(50)]
        public string Descripcion { get; set; }
        
    }
}
