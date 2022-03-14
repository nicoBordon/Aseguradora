using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aseguradora.BL.Models
{
    [Table("Persona", Schema = "dbo")]
    public class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int PersonaID { get; set; }
        public string NombreCompleto { get; set; }
        
        public string Identificador { get; set; }
        public DateTime Nacimiento { get; set; }
        [ForeignKey("Genero")]
        public int GeneroID { get; set; }
        public Genero Genero { get; set; }
        public bool Estado { get; set; }
        public ICollection<AtributoAdicional> AtributosAdicionales{ get; set; }
        

    }
}
