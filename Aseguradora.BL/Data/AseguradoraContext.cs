using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aseguradora.BL.Models;

namespace Aseguradora.BL.Data
{
    public class AseguradoraContext : DbContext
    {
        private static AseguradoraContext aseguradoraContext = null;
        public AseguradoraContext()
            :base("AseguradoraContext")
        {
            
        }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<AtributoAdicional> AtributosAdicionales { get; set; }
        public DbSet<TipoAtributoAdicional> TiposAtributosAdicionales { get; set; }
        public static AseguradoraContext Create() {
            if (aseguradoraContext == null)
            {
                aseguradoraContext = new AseguradoraContext();
            }
            return aseguradoraContext;
            //return new AseguradoraContext();
        }
    }
}
