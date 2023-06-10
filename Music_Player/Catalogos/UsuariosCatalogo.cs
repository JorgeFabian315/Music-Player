using Microsoft.EntityFrameworkCore;
using Music_Player.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
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

        public Usuario? GetUs(Usuario u)
        {
            Usuario? existe = context.Usuario.Find(u.Id);

            if(existe != null)
            {
                return existe;  
            }
            else
            {
                return null;
            }
        }

        public Usuario? GetIdUsuario(int id)
        {
            return context.Usuario.Find(id);
        }

        public Usuario? GetUsuario(string correo)
        {
            return context.Usuario.Include(d => d.BitacoraUsuario).
                Include(x => x.IdRolNavigation).FirstOrDefault(c => c.CorreoElectronico == correo);
        }




        public int IniciarSesion(string correo, string contraseña) 
        {
            string comando = $"select fn_InicioSeion('{correo}','{contraseña}')";

            var y = ((IEnumerable<int>)context.Database.
            SqlQueryRaw<int>(comando,  correo, contraseña)
            .AsAsyncEnumerable<int>()).First();

            if(y == 1)
            {
                var us = GetUsuario(correo);
                if(us != null)
                    EstablecerTipoUusuario(us);
            }

            return y;
        }


        private void EstablecerTipoUusuario(Usuario u)
        {
            // Crear una identidad con el nombre del usuario 
            GenericIdentity user = new GenericIdentity(u.CorreoElectronico);
            if (user is not null)
            {
                // Creamos los roles
                string[] roles = new string[]
                {
                    u.IdRolNavigation.Nombre
                };
                // Creamos la credencial 
                GenericPrincipal credencial_usuario = new GenericPrincipal(user, roles);
                // Asignamos la credencial a la aplicacion
                Thread.CurrentPrincipal = credencial_usuario;
            }

        }

        public void Agregar(Usuario u)
        {
            context.Usuario.Add(u);
            context.SaveChanges();
        }

        public void Eliminar(Usuario u)
        {
            context.Usuario.Remove(u);
            context.SaveChanges();
        }

        public void Editar(Usuario u)
        {
            context.Usuario.Update(u);
            context.SaveChanges();
        }
        public IEnumerable<Usuario> GetUsuariosAdmin()
        {
            return context.Usuario.Where(x => x.IdRolNavigation.Nombre == "Administrador");
        }

        public IEnumerable<Usuario> GetUsuariosVIP()
        {
            return context.Usuario.Where(x => x.IdRolNavigation.Nombre == "Usuario VIP");
        }

        public IEnumerable<Usuario> GetUsuariosNormal()
        {
            return context.Usuario.Where(x => x.IdRolNavigation.Nombre == "Usuario");
        }
    }
}
