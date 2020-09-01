namespace PaoMazzaAPI.Models {

    public class Ingrediente {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public float Stock { get; set; }
        public Unidad StockUnidad { get; set; }
        public float Costo { get; set; }
        public Unidad CostoUnidad { get; set; }
        public string Notas { get; set; }
    }
}