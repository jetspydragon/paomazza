using System.ComponentModel.DataAnnotations;

namespace PaoMazzaAPI.Models {

    public class Ingrediente {

        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; }

        [Required]
        public float Stock { get; set; }

        [Required]
        public Unidad Unidad { get; set; }

        [Required]
        public float Costo { get; set; }

        [Required]
        public Unidad CostoUnidad { get; set; }

        public string Notas { get; set; }
    }
}