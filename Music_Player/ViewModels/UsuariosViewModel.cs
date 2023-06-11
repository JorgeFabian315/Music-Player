using FluentValidation;
using GalaSoft.MvvmLight.Command;
using Microsoft.Extensions.Options;
using Music_Player.Catalogos;
using Music_Player.Models;
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
    public class UsuariosViewModel: INotifyPropertyChanged
    {


        public ObservableCollection<Usuario> ListaUsuarios { get; set; } = new ObservableCollection<Usuario>();
        public ObservableCollection<Rol> ListaRoles { get; set; } = new ObservableCollection<Rol>();
        public Usuario? usuario { get; set; }
        public Rol? rol { get; set; }
        UsuariosCatalogo catalagousuario = new();
        RolCatalogo catalagoroles = new();
        public VistaAdministrador Vista { get; set; }
        public string Error { get; set; }

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


        public UsuariosViewModel()
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
                    var existe = catalagousuario.GetUs(usuario);

                    if(existe != null)
                    {
                        existe.Id = usuario.Id;
                        existe.Nombre = usuario.Nombre;
                        existe.CorreoElectronico = usuario.CorreoElectronico;
                        existe.Contraseña = usuario.Contraseña;
                        existe.IdRol = usuario.IdRol;

                        catalagousuario.Editar(existe);
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
            foreach (var item in catalagoroles.GetRoles())
            {
                ListaRoles.Add(item);
            }
            Actualizar();
        }

        private void Eliminar()
        {
            if(usuario != null)
            {
                catalagousuario.Eliminar(usuario);

                Vista = VistaAdministrador.VerUsuarios;
                CargarBD();
                Actualizar();
            }
        }

        private void VerEliminar(int id)
        {
            usuario = catalagousuario.GetIdUsuario(id);

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
                    catalagousuario.Agregar(usuario);
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
            foreach (var item in catalagousuario.GetUsuariosNormal())
            {
                ListaUsuarios.Add(item);
            }
            Actualizar();
        }

        private void VerVIP()
        {
            ListaUsuarios.Clear();
            foreach (var item in catalagousuario.GetUsuariosVIP())
            {
                ListaUsuarios.Add(item);
            }
            Actualizar();
        }

        private void VerAdmins()
        {
            ListaUsuarios.Clear();
            foreach (var item in catalagousuario.GetUsuariosAdmin())
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
                usuario = catalagousuario.GetBitacorasUsuario(u.CorreoElectronico);
                Vista = VistaAdministrador.VerBitacoras;
                Actualizar();
            }
        }

        public void CargarBD()
        {
            ListaUsuarios.Clear();
            foreach (var item in catalagousuario.GetUsuarios())
            {
                ListaUsuarios.Add(item);
            }
            Actualizar();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void Actualizar(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
