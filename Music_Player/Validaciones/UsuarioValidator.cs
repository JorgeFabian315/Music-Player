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

            RuleSet("Correo", () => {
                RuleFor(u => u.CorreoElectronico)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty()
                    .EmailAddress()
                    .MaximumLength(100)
                    .MinimumLength(6)
                    .NotNull();
            });
            RuleSet("Contraseña", () => {
                RuleFor(u => u.Contraseña)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty()
                    .MaximumLength(100)
                    .MinimumLength(2)
                    .NotNull();
            });


        }
    }
}
