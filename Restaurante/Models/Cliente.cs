using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurante.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="El Campo Nombre es Requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Campo Apellido es Requerido")]
        public string Apellido { get; set; }
        [EmailAddress(ErrorMessage ="Tiene que ser un correo valido")]
        public string Correo { get; set; }
        [Phone(ErrorMessage = "Tiene que ser un numero de telefono valido")]
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }
}
