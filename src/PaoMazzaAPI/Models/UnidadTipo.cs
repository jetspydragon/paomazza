using System.ComponentModel.DataAnnotations;

namespace PaoMazzaAPI.Models {
    
    public class UnidadTipo {

        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Tipo { get; set; }
    }
}