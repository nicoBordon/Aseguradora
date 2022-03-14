using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aseguradora.BL.Models
{
    [Table("Genero",Schema ="dbo")]
    public class Genero
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GeneroID { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Persona> Personas { get; set; }
    }
}
