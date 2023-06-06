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
        public Usuario? usuario { get; set; } = new();
        public Rol? rol { get; set; }
        UsuariosCatalogo catalagousuario = new();
        RolCatalogo catalagoroles = new();
        public EnumUsuarioVista Vista { get; set; }
        public string Error { get; set; }

        public ICommand VerBitacorasCommand { get; set; }
        public ICommand RegresarCommand { get; set; }
        public ICommand VerUsuariosAdminCommand { get; set; }
        public ICommand VerUsuariosNormalCommand { get; set; }
        public ICommand VerUsuariosVIPCommand { get; set; }
        public ICommand VerAgregarUsuarioCommand { get; set; }
        public ICommand VerEliminarUsuarioCommand { get; set; }
        public ICommand AgregarUsuarioCommand { get; set; }
        public ICommand EliminarUsuarioCommand { get; set; }


        public UsuariosViewModel()
        {
            CargarBD();
            CargarRoles();
            Vista = EnumUsuarioVista.VerUsuarios;
            VerBitacorasCommand = new RelayCommand<Usuario>(VerBitacoras);
            RegresarCommand = new RelayCommand(Regresar);
            VerUsuariosAdminCommand = new RelayCommand(VerAdmins);
            VerUsuariosVIPCommand = new RelayCommand(VerVIP);
            VerUsuariosNormalCommand = new RelayCommand(VerUsuarios);
            VerAgregarUsuarioCommand = new RelayCommand(VerAgregar);
            VerEliminarUsuarioCommand = new RelayCommand<int>(VerEliminar);
            AgregarUsuarioCommand = new RelayCommand(Agregar);
            EliminarUsuarioCommand = new RelayCommand(Eliminar);
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

                Vista = EnumUsuarioVista.VerUsuarios;
                CargarBD();
                Actualizar();
            }
        }

        private void VerEliminar(int id)
        {
            usuario = catalagousuario.GetIdUsuario(id);
            Regresar();
            Actualizar();
        }

        private void VerAgregar()
        {
            usuario = new();
            Error = "";
            Vista = EnumUsuarioVista.VerAgregar;
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
            Vista = EnumUsuarioVista.VerUsuarios;
            Actualizar();
        }

        private void VerBitacoras(Usuario u)
        {
            if(u != null)
            {
                usuario = catalagousuario.GetBitacorasUsuario(u.CorreoElectronico);
                Vista = EnumUsuarioVista.VerBitacoras;
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
