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
using Music_Player.Views.GenerosViews;

namespace Music_Player.ViewModels
{
    public class MinViewModel : INotifyPropertyChanged
    {


        CancionesViewModel cancionesviewmodel = new();
        UsuariosViewModel usuariosviewmodel = new();
        GenerosViewModel generosviewmodel = new();
        ArtistasViewModel artistasviewmodel = new();
        HomeViewModel homeviewmodel = new();

        UsuariosCatalogo catalogo_us = new();

        private object? _miviewmodel;

        public bool CerrarSesionUsuario { get; set; } = false;

        public Usuario Usuario { get; set; } = new();

        public bool Conectado => Usuario.Id != 0;

        // public bool Conectado => true;

        public object? ViewModelAactual
        {
            get { return _miviewmodel; }
            set { _miviewmodel = value; }
        }



        public MinViewModel()
        {
            ViewModelAactual = this;
        }


        #region COMANDOS
        public ICommand NavegarCategoriasCommand => new RelayCommand(NavegarGeneros);
        public ICommand NavegarHomeCommand => new RelayCommand(NavegarHome);
        public ICommand NavegarVerCancionesCommand => new RelayCommand(NavegarVerCanciones);
        public ICommand NavegarCancionesMegustanCommand => new RelayCommand(NavegarCancionesMegustan);
        public ICommand NavegarUsuariosCommand => new RelayCommand(NavegarUsuarios);
        public ICommand NavegarArtistasCommand => new RelayCommand(NavegarArtistas);
        public ICommand IniciarSesionCommand => new RelayCommand(IniciarSesion);
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
            NavegarHome();
        }

        private void AccionesUsuarioVIP()
        {
            NavegarHome();
        }

        private void AccionesAdministrador()
        {
            NavegarEstadisticas();
        }

        private void CerrarSesion()
        {
            Usuario = new();
            Error = "";
            ViewModelAactual = this;
            Actualizar();
        }


        private void NavegarCancionesMegustan()
        {
            MediadorViewModel.ActualizarVista(VistaPeliculas.VerPeliculasMegustan);

            //  NavigationService.Instance.NavigateTo(new CancionesMeGustanView());

            ViewModelAactual = cancionesviewmodel;


            Actualizar();
        }

        private void NavegarArtistas()
        {
            //NavigationService.Instance.NavigateTo(new VerArtistasView());
            ViewModelAactual = artistasviewmodel;

            Actualizar();
        }
        private void NavegarUsuarios()
        {
            //NavigationService.Instance.NavigateTo(new VerUsuariosView());
            ViewModelAactual = usuariosviewmodel;

            Actualizar();
        }
        private void NavegarEstadisticas()
        {
            //NavigationService.Instance.NavigateTo(new VerUsuariosView());
            ViewModelAactual = usuariosviewmodel;

            Actualizar();
        }


        private void NavegarHome()
        {
            // NavigationService.Instance.NavigateTo(new HomeView());
            ViewModelAactual = homeviewmodel;

            Actualizar();
        }

        private void NavegarGeneros()
        {
            // NavigationService.Instance.NavigateTo(new VerGenerosView());
            ViewModelAactual = generosviewmodel;

            Actualizar();
        }

        private void NavegarVerCanciones()
        {
            MediadorViewModel.ActualizarVista(VistaPeliculas.VerPeliculas);

            //NavigationService.Instance.NavigateTo(new VerCancionesView() 
            //{ 
            //    DataContext = new CancionesViewModel()
            //});

            ViewModelAactual = cancionesviewmodel;

            Actualizar();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void Actualizar(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
