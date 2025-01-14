using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurante.Models
{
    public class Venta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Range(typeof(DateTime), "01/01/2020", "12/31/2025")]
        public DateTime Fecha { get; set; }
        [Required]
        public decimal Total { get; set; }
        [Required]
        [field: ForeignKey("Id")]
        public int ClienteId { get; set; }
    }
}
