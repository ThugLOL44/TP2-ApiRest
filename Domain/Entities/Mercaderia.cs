using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Mercaderia
    {
        public int MercaderiaId { get; set; }

        public string Nombre { get; set; }
        public int TipoMercaderiaId { get; set; }
        public double Precio { get; set; }
        public string Ingredientes { get; set; }
        public string Preparacion { get; set; }
        public string Imagen { get; set; }
        public ICollection<ComandaMercaderia> ComandaMercaderia { get; set; }
        public TipoMercaderia TipoMercaderia { get; set; }
    }
}
