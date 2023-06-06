using FluentValidation;
using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.Validaciones
{
    public class UsuarioValidator: AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleSet("Nombre", () => {
                RuleFor(u => u.Nombre)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty()
                    .WithMessage("Escriba el nombre correspondiente.")
                    .MaximumLength(100)
                    .WithMessage("Ha excedido la longitud de caracteres.")
                    .NotNull();
            });

            RuleSet("Correo", () => {
                RuleFor(u => u.CorreoElectronico)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty()
                    .WithMessage("Escriba el correo electrónico.")
                    .EmailAddress()
                    .WithMessage("El correo electrónico no esta en el formato correcto.")
                    .MaximumLength(100)
                    .WithMessage("Ha excedido la longitud de caracteres.")
                    .NotNull();

            });
            RuleSet("Contraseña", () => {
                RuleFor(u => u.Contraseña)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty()
                    .WithMessage("Establezca su contraseña.")
                    .MaximumLength(100)
                    .WithMessage("Ha excedido la longitud de caracteres.")
                    .MinimumLength(2)
                    .WithMessage("La contraseña debe ser mayor a 1 caracter.")
                    .NotNull();
            });


        }
    }
}
