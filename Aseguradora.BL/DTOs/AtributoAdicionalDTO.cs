using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aseguradora.BL.DTOs
{
    public class AtributoAdicionalDTO
    {
        [Required(ErrorMessage = "El campo AtributoAdicionalID es obligatorio")]
        public int AtributoAdicionalID { get; set; }
        [Required(ErrorMessage = "El campo PersonaID es obligatorio")]
        public  int PersonaID{ get; set; }
        [Required(ErrorMessage = "El campo es afirmativo es obligatorio")]
        public bool EsAfirmativo { get; set; }
        [StringLength(50)]
        public string DetalleAtributo { get; set; }
        [Required(ErrorMessage = "El  Tipo Atributo Adicional  es obligatorio")]
        public int TipoAtributoAdicionalID { get; set; }
        //public PersonaDTO Persona { get; set; }
        public TipoAtributoAdicionalDTO TipoAtributoAdicional { get; set; }
    }
}
