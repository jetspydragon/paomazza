using System.Collections.Generic;

namespace PaoMazzaAPI.Models {

    public class Receta {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Notas { get; set; }
        public IEnumerable<Ingrediente> Ingredientes { get; set; }

    }
}