using FluentValidation;
using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Music_Player.Validaciones
{
    public class CancionValidator: AbstractValidator<Cancion>
    {

        string cadena_duracion = @"/d{2}:/d{2}";
        Regex regex;
        public CancionValidator()
        {
            regex = new(cadena_duracion);

            RuleFor(c => c.Titulo)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("El título no puede estar vacío.")
                .MaximumLength(100)
                .WithMessage("El título ha excedido el tamaño establecido.")
                .MinimumLength(1);
            RuleFor(c => c.IdGenero)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Selecciona un Género musical");
            RuleFor(c => c.IdArtista)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Selecciona un Artista");

            RuleFor(c => c.IdUsuario)
                .GreaterThan(0);
            RuleFor(c => c.Duracion)
                .Must(c => regex.IsMatch(c))
                .WithMessage("Error en la duración");
        }

    }
}
