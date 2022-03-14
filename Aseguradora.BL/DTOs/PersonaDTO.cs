using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Aseguradora.BL.DTOs
{
    public class PersonaDTO
    {
        [Required(ErrorMessage = "El campo idPersona es Requerido")]
        public int PersonaID { get; set; }

        
        [Required(ErrorMessage = "El campo nombre completo es obligatorio")]
        [StringLength(100)]
        public string NombreCompleto { get; set; }
        [Required(ErrorMessage = "El campo Identificador es obligatorio")]
        [StringLength(50)]
        public string Identificador { get; set; }

        [Required(ErrorMessage = "El campo Genero es obligatorio")]
        public int GeneroID { get; set; }
        
        [Required]
        public bool Estado { get; set; }
        
        [Required(ErrorMessage = "El campo fecha de nacimiento es obligatorio")]
        public DateTime Nacimiento { get; set; }
        public int Edad
        {
            get
            {
                int edad = DateTime.Now.Year - Nacimiento.Year;
                if ((Nacimiento.Month > DateTime.Now.Month) || (Nacimiento.Month == DateTime.Now.Month && Nacimiento.Day > DateTime.Now.Day))
                    edad--;
                return edad;
            }
        }

   

        public GeneroDTO Genero {
            get;set;
        
        }
        //public ICollection<AtributoAdicionalDTO> AtributosAdicionales { get; set; }
    }
}
