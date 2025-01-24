using FluentValidation;
using Restaurante.Models;

namespace Restaurante.Validators
{
    public class Validator : AbstractValidator<Cliente>
    {
        public Validator() 
        {
            RuleFor(cliente => cliente.Nombre).NotNull().Length(3, 50);
            RuleFor(cliente => cliente.Apellido).NotNull().Length(3, 50);
            RuleFor(cliente => cliente.Correo).NotNull().EmailAddress();
            RuleFor(cliente => cliente.Telefono).NotNull().Matches(@"^\d{10}$").WithMessage("El telefono no es valido");
            RuleFor(cliente => cliente.Direccion).NotNull().Length(3, 50);
        }
    }
}
