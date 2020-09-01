using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaoMazzaAPI.Models {

    public class Receta {

        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        public string Notas { get; set; }
        
        public ICollection<RecetaIngrediente> Ingredientes { get; set; }

    }
}