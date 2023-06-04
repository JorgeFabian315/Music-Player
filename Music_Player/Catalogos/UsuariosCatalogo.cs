using Microsoft.EntityFrameworkCore;
using Music_Player.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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


        public int IniciarSesion(string correo, string contraseña) 
        {
            string comando = $"select fn_InicioSeion('{correo}','{contraseña}')";

            var y = ((IEnumerable<int>)context.Database.
            SqlQueryRaw<int>(comando,  correo, contraseña)
            .AsAsyncEnumerable<int>()).First();


            return y;
        }

        public Usuario? GetUsuario(string correo)
        {
            return context.Usuario.Include(d => d.BitacoraUsuario).
                Include(x => x.IdRolNavigation).FirstOrDefault(c => c.CorreoElectronico == correo);
        }
    }
}
