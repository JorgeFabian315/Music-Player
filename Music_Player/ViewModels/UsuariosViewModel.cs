using FluentValidation;
using GalaSoft.MvvmLight.Command;
using Microsoft.Extensions.Options;
using Music_Player.Catalogos;
using Music_Player.Models;
using Music_Player.Operaciones;
using Music_Player.Validaciones;
using Music_Player.Views.Enum_CambiarVista;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Music_Player.ViewModels
{
    public class UsuariosViewModel: BaseViewModel
    {


        public ObservableCollection<Usuario> ListaUsuarios { get; set; } = new ObservableCollection<Usuario>();
        public ObservableCollection<Rol> ListaRoles { get; set; } = new ObservableCollection<Rol>();
        public Usuario? usuario { get; set; }
        public Rol? rol { get; set; }
        public VistaAdministrador Vista { get; set; }
        public string Error { get; set; } = string.Empty;

        public ICommand VerBitacorasCommand { get; set; }
        public ICommand RegresarCommand { get; set; }
        public ICommand VerUsuariosAdminCommand { get; set; }
        public ICommand VerUsuariosNormalCommand { get; set; }
        public ICommand VerUsuariosVIPCommand { get; set; }
        public ICommand VerAgregarUsuarioCommand { get; set; }
        public ICommand VerEliminarUsuarioCommand { get; set; }
        public ICommand VerEditarUsuarioCommand { get; set; }
        public ICommand AgregarUsuarioCommand { get; set; }
        public ICommand EliminarUsuarioCommand { get; set; }
        public ICommand EditarUsuarioCommand { get; set; }


        public UsuariosViewModel(MusicPlayerContext context):base(context)
        {

            CargarBD();
            CargarRoles();
            Vista = VistaAdministrador.VerUsuarios;
            VerBitacorasCommand = new RelayCommand<Usuario>(VerBitacoras);
            RegresarCommand = new RelayCommand(Regresar);
            VerUsuariosAdminCommand = new RelayCommand(VerAdmins);
            VerUsuariosVIPCommand = new RelayCommand(VerVIP);
            VerUsuariosNormalCommand = new RelayCommand(VerUsuarios);
            VerAgregarUsuarioCommand = new RelayCommand(VerAgregar);
            VerEliminarUsuarioCommand = new RelayCommand<int>(VerEliminar);
            VerEditarUsuarioCommand = new RelayCommand<Usuario>(VerEditar);
            AgregarUsuarioCommand = new RelayCommand(Agregar);
            EliminarUsuarioCommand = new RelayCommand(Eliminar);
            EditarUsuarioCommand = new RelayCommand(Editar);
        }

        private void Editar()
        {
            if(usuario != null)
            {
                UsuarioValidator validation = new UsuarioValidator();

                var result = validation.Validate(usuario, options =>
                {
                    options.IncludeAllRuleSets();
                });

                if (result.IsValid)
                {
                    var existe = catalogo_us.GetUs(usuario);

                    if(existe != null)
                    {
                        existe.Id = usuario.Id;
                        existe.Nombre = usuario.Nombre;
                        existe.CorreoElectronico = usuario.CorreoElectronico;
                        existe.Contraseña = usuario.Contraseña;
                        existe.IdRol = usuario.IdRol;

                        catalogo_us.Editar(existe);
                        CargarBD();
                        Regresar();
                    }
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        Error = $"{Error} {item} {Environment.NewLine}";
                    }
                    Actualizar();
                }
                Error = "";
            }
        }

        int indice = 0;
        private void VerEditar(Usuario u)
        {
            if(u != null)
            {
                Error = "";
                Vista = VistaAdministrador.VerEditar;

                Usuario clon = new()
                {
                    Id = u.Id,
                    Nombre = u.Nombre,
                    CorreoElectronico = u.CorreoElectronico,
                    Contraseña = u.Contraseña,
                    IdRol = u.IdRol
                };

                indice = ListaUsuarios.IndexOf(u);
                usuario = clon;
                Actualizar();
            }
        }

        public void CargarRoles()
        {
            ListaRoles.Clear();
            foreach (var item in catalogo_us.GetRoles())
            {
                ListaRoles.Add(item);
            }
            Actualizar();
        }

        private void Eliminar()
        {
            if(usuario != null)
            {
                catalogo_us.Eliminar(usuario);

                Vista = VistaAdministrador.VerUsuarios;
                CargarBD();
                Actualizar();
            }
        }

        private void VerEliminar(int id)
        {
            usuario = catalogo_us.GetIdUsuario(id);

            if(usuario != null)
            {
                Vista = VistaAdministrador.VerEliminar;
                Actualizar();
            }
            //Regresar();
            
        }

        private void VerAgregar()
        {
            usuario = new();
            Error = "";
            Vista = VistaAdministrador.VerAgregar;
            Actualizar();
        }

        private void Agregar()
        {
            if(usuario != null)
            {
                Error = "";

                UsuarioValidator validation = new UsuarioValidator();   

                var result = validation.Validate(usuario, options =>
                {
                    options.IncludeAllRuleSets();
                } );

                if (result.IsValid)
                {
                    catalogo_us.Agregar(usuario);
                    CargarBD();
                    Regresar();
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        Error = $"{Error} {item} {Environment.NewLine}";
                    }
                }
                Actualizar();
            }
        }

        private void VerUsuarios()
        {
            ListaUsuarios.Clear();
            foreach (var item in catalogo_us.GetUsuariosNormal())
            {
                ListaUsuarios.Add(item);
            }
            Actualizar();
        }

        private void VerVIP()
        {
            ListaUsuarios.Clear();
            foreach (var item in catalogo_us.GetUsuariosVIP())
            {
                ListaUsuarios.Add(item);
            }
            Actualizar();
        }

        private void VerAdmins()
        {
            ListaUsuarios.Clear();
            foreach (var item in catalogo_us.GetUsuariosAdmin())
            {
                ListaUsuarios.Add(item);
            }
            Actualizar();

        }

        private void Regresar()
        {
            Vista = VistaAdministrador.VerUsuarios;
            Actualizar();
        }

        private void VerBitacoras(Usuario u)
        {
            if(u != null)
            {
                usuario = catalogo_us.GetBitacorasUsuario(u.CorreoElectronico);
                Vista = VistaAdministrador.VerBitacoras;
                Actualizar();
            }
        }

        public void CargarBD()
        {
            ListaUsuarios.Clear();
            foreach (var item in catalogo_us.GetUsuarios())
            {
                ListaUsuarios.Add(item);
            }
            Actualizar();
        }
    }
}
