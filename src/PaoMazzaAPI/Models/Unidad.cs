using System.ComponentModel.DataAnnotations;

namespace PaoMazzaAPI.Models {

    public class Unidad {

        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(10)]
        public string Abrev { get; set; }

        [Required]
        public UnidadTipo Tipo { get; set; }

        [Required]
        public float RelBase { get; set; }
    }
}