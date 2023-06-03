using Microsoft.EntityFrameworkCore;
using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.Catalogos
{
    public class UsuariosCatalogo
    {
        MusicPlayerContext context = new();

        public IEnumerable<Usuario> GetUsuarios()
        {
            return context.Usuario.Include(x => x.IdRolNavigation).OrderBy(x => x.Nombre);
        }

        public Usuario? GetBitacorasUsuario(string correo)
        {
            return context.Usuario.Include(x => x.BitacoraUsuario).FirstOrDefault(x => x.CorreoElectronico == correo);
        }

    }
}
