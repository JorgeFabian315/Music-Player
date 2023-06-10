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
namespace Music_Player.ViewModels
{
    public class MainViewModel:INotifyPropertyChanged
    {

        CancionesViewModel cancionesviewmodel = new();
        UsuariosViewModel usuariosviewmodel = new();
        GenerosViewModel generosviewmodel = new();
        ArtistasViewModel artistasviewmodel = new();
        HomeViewModel homeviewmodel = new();
        EstadisticasViewModel estadisticasViewModel = new();
        UsuariosCatalogo catalogo_us = new();


        public Usuario Usuario { get; set; } = new();

        public bool Conectado => Usuario.Id != 0;

        private object? _viewmodelactual;
        public object? ViewModelAactual
        {
            get { return _viewmodelactual; }
            set { _viewmodelactual = value; }
        }
        private UserControl _view;

        public UserControl View
        {
            get { return _view; }
            set { _view = value;
                Actualizar();
            }
        }


        public MainViewModel()
        {
            View = new LoginView();
            View.DataContext = this;
        }


        #region COMANDOS
        public ICommand NavegarCategoriasCommand => new RelayCommand(NavegarGeneros);
        public ICommand NavegarHomeCommand => new RelayCommand(NavegarHome);
        public ICommand NavegarVerCancionesCommand => new RelayCommand(NavegarVerCanciones);
        public ICommand NavegarCancionesMegustanCommand => new RelayCommand(NavegarCancionesMegustan);
        public ICommand NavegarUsuariosCommand => new RelayCommand(NavegarUsuarios);
        public ICommand NavegarArtistasCommand => new RelayCommand(NavegarArtistas);
        public ICommand IniciarSesionCommand => new RelayCommand(IniciarSesion);
        public ICommand NavegarEstadisticasCommand => new RelayCommand(NavegarEstadisticas);
        public ICommand CerrarSesionCommand => new RelayCommand(CerrarSesion);
        #endregion


        public string Error { get; private set; }

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
                        NavegarHome();
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

        private void AccionesUsuarioNormal()
        {
            View = new IndexUsuNVIPView();
            NavegarHome();
        }

        private void AccionesUsuarioVIP()
        {
            View = new IndexUsuNVIPView();
            NavegarHome();
        }

        private void AccionesAdministrador()
        {
            View = new IndexAdministradorView();
            NavegarEstadisticas();
        }

        private void CerrarSesion()
        {
            Usuario = new();
            Error = "";
            View = new LoginView();
            View.DataContext = this;
            Actualizar();
        }


        private void NavegarCancionesMegustan()
        {
            MediadorViewModel.ActualizarVista(VistaCancion.VerCancionesMegustan);

            ViewModelAactual = cancionesviewmodel;


            Actualizar();
        }

        private void NavegarArtistas()
        {
            ViewModelAactual = artistasviewmodel;
            Actualizar();
        }
        private void NavegarUsuarios()
        {
            ViewModelAactual = usuariosviewmodel;
            Actualizar();
        }
        private void NavegarEstadisticas()
        {
            ViewModelAactual = estadisticasViewModel;

            Actualizar();
        }


        private void NavegarHome()
        {
            ViewModelAactual = homeviewmodel;

            Actualizar();
        }

        private void NavegarGeneros()
        {
            ViewModelAactual = generosviewmodel;
            Actualizar();
        }

        private void NavegarVerCanciones()
        {
            MediadorViewModel.ActualizarVista(VistaCancion.VerCanciones);
            ViewModelAactual = cancionesviewmodel;
            Actualizar();
        }


        #region ACTUALIZAR CAMBIOS
        public event PropertyChangedEventHandler? PropertyChanged;
        public void Actualizar(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion ACTUALIZAR CAMBIOS
    }
}
