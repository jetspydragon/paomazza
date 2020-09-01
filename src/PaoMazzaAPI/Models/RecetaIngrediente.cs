using System.ComponentModel.DataAnnotations;

namespace PaoMazzaAPI.Models {
    
    public class RecetaIngrediente {

        [Required]
        public int Id { get; set; }

        [Required]
        public Receta Receta { get; set; }

        [Required]
        public Ingrediente Ingrediente { get; set; }

        [Required]
        public float Cantidad { get; set; }

        [Required]
        public Unidad Unidad { get; set; }
        
        public string Notas { get; set; }
    }
}