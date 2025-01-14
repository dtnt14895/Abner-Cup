using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurante.Models
{
    public class Detalle_Venta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Id")]
        public int VentaId { get; set; }
        [Required]
        [ForeignKey("Id")]
        public int ProductoId { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public decimal Total { get; set; }
    }
}
