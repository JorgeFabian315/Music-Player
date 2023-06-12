using FluentValidation;
using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.Validaciones
{
    public class ArtistaValidator: AbstractValidator<Artista>
    {
        public ArtistaValidator() 
        {

        }

    }
}
