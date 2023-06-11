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
        private readonly MusicPlayerContext _context;
        public UsuariosCatalogo(MusicPlayerContext context)
        {
            _context = context;
        }


        public IEnumerable<Usuario> GetUsuarios()
        {
            return _context.Usuario.Include(x => x.IdRolNavigation).OrderBy(x => x.Nombre);
        }

        public Usuario? GetBitacorasUsuario(string correo)
        {
            return _context.Usuario.Include(x => x.BitacoraUsuario).FirstOrDefault(x => x.CorreoElectronico == correo);
        }

        public Usuario? GetUs(Usuario u)
        {
            Usuario? existe = _context.Usuario.Find(u.Id);

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
            return _context.Usuario.Find(id);
        }

        public Usuario? GetUsuario(string correo)
        {
            return _context.Usuario.Include(d => d.BitacoraUsuario).
                Include(x => x.IdRolNavigation).FirstOrDefault(c => c.CorreoElectronico == correo);
        }




        public int IniciarSesion(string correo, string contraseña) 
        {
            string comando = $"select fn_InicioSeion('{correo}','{contraseña}')";

            var y = ((IEnumerable<int>)_context.Database.
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
            _context.Usuario.Add(u);
            _context.SaveChanges();
        }

        public void Eliminar(Usuario u)
        {
            _context.Usuario.Remove(u);
            _context.SaveChanges();
        }

        public void Editar(Usuario u)
        {
            _context.Usuario.Update(u);
            _context.SaveChanges();
        }
        public IEnumerable<Usuario> GetUsuariosAdmin()
        {
            return _context.Usuario.Where(x => x.IdRolNavigation.Nombre == "Administrador");
        }

        public IEnumerable<Usuario> GetUsuariosVIP()
        {
            return _context.Usuario.Where(x => x.IdRolNavigation.Nombre == "Usuario VIP");
        }

        public IEnumerable<Usuario> GetUsuariosNormal()
        {
            return _context.Usuario.Where(x => x.IdRolNavigation.Nombre == "Usuario");
        }
        public IEnumerable<Rol> GetRoles()
        {
            foreach (var rol in _context.Rol)
            {
                yield return rol;
            }
        }
    }
}
