using Microsoft.EntityFrameworkCore;

namespace PaoMazzaAPI.Models {

    public class PaoMazzaAPIContext : DbContext {
        
        public PaoMazzaAPIContext(DbContextOptions<PaoMazzaAPIContext> options) : base(options) {

        }

        public DbSet<Unidad> Unidades { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Receta> Recetas { get; set; }
        public DbSet<RecetaIngrediente> RecetaIngredientes { get; set; }
        public DbSet<UnidadTipo> UnidadTipos { get; set; }

    }
}