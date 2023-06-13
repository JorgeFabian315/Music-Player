using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Music_Player.Catalogos;
using Music_Player.Models;
using Music_Player.Operaciones;
using Music_Player.Validaciones;
using Music_Player.Views;
using FluentValidation;
using Music_Player.Views.CancionesViews;
using Music_Player.Views.Enum_CambiarVista;
using Music_Player.Views.UsuariosView;
using System.Threading;
using Music_Player.Views.ArtistasViews;
using Microsoft.EntityFrameworkCore;

namespace Music_Player.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public static MusicPlayerContext _context = new();

        CancionesViewModel cancionesviewmodel = new(_context);
        UsuariosViewModel usuariosviewmodel = new(_context);
        ArtistasViewModel artistasviewmodel = new(_context);
        Admin_Artist_ViewModel adminartistasviewmodel = new(_context);
        EstadisticasViewModel estadisticasViewModel = new(_context);
        UsuariosCatalogo catalogo_us = new(_context);
     


        public Usuario Usuario { get; set; } = new();

        public bool Conectado => Usuario.Id != 0;
        public string Error { get; set; } = string.Empty;

        private object? _viewmodelactual;
        public object? ViewModelAactual
        {
            get { return _viewmodelactual; }
            set
            {
                _viewmodelactual = value;

                Actualizar();
            }
        }
        private UserControl? _view;

        public UserControl? View
        {
            get { return _view; }
            set
            {
                _view = value;
                Actualizar();
            }
        }


        public MainViewModel()
        {
            View = new LoginView();
            View.DataContext = this;
        }


        #region COMANDOS
        public ICommand NavegarUsuariosCommand => new RelayCommand<VistaUsuario>(NavegarUsuarios);
        public ICommand NavegarAdminCommand => new RelayCommand<VistaAdministrador>(NavegarAdministrador);
        public ICommand IniciarSesionCommand => new RelayCommand(IniciarSesion);
        public ICommand CerrarSesionCommand => new RelayCommand(CerrarSesion);
        #endregion



        private void IniciarSesion()
        {
            Error = "";
            if (Usuario != null)
            {
                UsuarioValidator rules = new();
                var result = rules.Validate(Usuario, options =>
                {
                    options.IncludeRuleSets("Correo", "Contraseña");
                });

                if (result.IsValid)
                {
                    var iniciosesion = catalogo_us.IniciarSesion(Usuario.CorreoElectronico, Usuario.Contraseña);

                    if (iniciosesion == 1)
                    {
                        Usuario = catalogo_us.GetUsuario(Usuario.CorreoElectronico) ?? new Usuario();
                        if (Thread.CurrentPrincipal is not null)
                        {
                            // var nose = Thread.CurrentPrincipal.Identity.Name;
                            if (Thread.CurrentPrincipal.IsInRole("Administrador"))
                                AccionesAdministrador();
                            if (Thread.CurrentPrincipal.IsInRole("Usuario VIP"))
                                AccionesUsuarioVIP();
                            if (Thread.CurrentPrincipal.IsInRole("Usuario"))
                                AccionesUsuarioNormal();
                        }
                    }
                    else
                        Error = (iniciosesion == 2) ? "La contraseña es incorrecta" : "El usuario no existe";
                }
                else
                    foreach (var error in result.Errors)
                    {
                        Error = $"{Error} {error} {Environment.NewLine}";
                    }

                Actualizar();
            }
        }

        #region ACCIONES USUARIOS
        private void AccionesUsuarioNormal()
        {
            View = new IndexUsuNVIPView();
            NavegarUsuarios(VistaUsuario.Home);
            MediadorViewModel.BuscarUsuario(Usuario.Id);

        }

        private void AccionesUsuarioVIP()
        {
            View = new IndexUsuNVIPView();
            NavegarUsuarios(VistaUsuario.Home);
            MediadorViewModel.BuscarUsuario(Usuario.Id);

        }

        #endregion ACCIONES USUARIOS

        #region ACCIONES ADMINISTRADOR
        private void AccionesAdministrador()
        {
            View = new IndexAdministradorView();
            NavegarAdministrador(VistaAdministrador.Estadisticas);
        }
        #endregion ACCIONES ADMINISTRADOR

        private void CerrarSesion()
        {
            Usuario = new();
            Error = "";
            View = new LoginView();
            View.DataContext = this;
            Actualizar();
        }


        #region NAVEGAR USUARIOS
        private void NavegarUsuarios(VistaUsuario vista)
        {
            if (vista == VistaUsuario.Artista)
            {
                //bvm.RecargarArtistas(bvm.ListaArtistas);
                ViewModelAactual = artistasviewmodel;
            }
            else
            {
                MediadorViewModel.ActualizarVista(vista);

                ViewModelAactual = cancionesviewmodel;
            }
        }
        #endregion NAVEGAR USUARIOS

        #region NAVEGAR ADMINISTRADOR
        private void NavegarAdministrador(VistaAdministrador vista)
        {
            if (vista == VistaAdministrador.Estadisticas)
            {
                ViewModelAactual = estadisticasViewModel;
            }
            else if (vista == VistaAdministrador.VerUsuarios)
            {
                ViewModelAactual = usuariosviewmodel;
            }
            else if (vista == VistaAdministrador.VerArtista) 
            {
                ViewModelAactual = adminartistasviewmodel;
            }
        }
        #endregion NAVEGAR ADMINISTRADOR

        #region ACTUALIZAR CAMBIOS
        public event PropertyChangedEventHandler? PropertyChanged;
        public void Actualizar(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion ACTUALIZAR CAMBIOS
    }
}
