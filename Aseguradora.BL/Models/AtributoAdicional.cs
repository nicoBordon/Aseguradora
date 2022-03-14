using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aseguradora.BL.Models
{
    
    [Table("AtributoAdicional", Schema = "dbo")]
    public class AtributoAdicional
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AtributoAdicionalID { get; set; }
        [ForeignKey("Persona")]
        public int PersonaID { get; set; }
        public Persona Persona { get; set; }
        public bool EsAfirmativo { get; set; }
        public string DetalleAtributo { get; set; }

        [ForeignKey("TipoAtributoAdicional")]
        public int TipoAtributoAdicionalID { get; set; }
        public TipoAtributoAdicional TipoAtributoAdicional { get; set; }

    }
}
