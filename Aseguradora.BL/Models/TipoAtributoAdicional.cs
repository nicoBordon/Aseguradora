using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aseguradora.BL.Models
{
    [Table("TipoAtributoAdicional",Schema="dbo")]
    public class TipoAtributoAdicional
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TipoAtributoAdicionalID { get; set; }
        public string NombreTipoAtributo { get; set; }
        public bool RequiereDetalle { get; set; }
        public bool Estado { get; set; }
        public ICollection<AtributoAdicional> AtributosAdicionales{ get; set; }

    }
}
