using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aseguradora.BL.DTOs
{
    public class TipoAtributoAdicionalDTO
    {
        [Required(ErrorMessage = "El  TipoAtributoAdicionalID  es obligatorio")]
        public int TipoAtributoAdicionalID { get; set; }
        [Required(ErrorMessage = "El  Nombre Tipo Atributo  es obligatorio")]
        public string NombreTipoAtributo { get; set; }
        [Required(ErrorMessage = "El es obligatorio definir si el tipo de atributo es requerido")]
        public bool RequiereDetalle { get; set; }
        [Required(ErrorMessage = "El Estado es obligatorio")]
        public bool Estado { get; set; }
        
    }
}
