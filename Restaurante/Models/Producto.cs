using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurante.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Campo Nombre es Requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Campo Precio es Requerido")]   
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "El Campo Stock es Requerido")]
        public string Stock { get; set; }
        public string Descripcion { get; set; }
    }
}
    