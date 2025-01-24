using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurante.Models
{
    public class Venta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VentaId { get; set; }
  
        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }

        public int ClienteId { get; set; }
        //relacion
        public virtual Cliente Cliente { get; set; }
    }
}
