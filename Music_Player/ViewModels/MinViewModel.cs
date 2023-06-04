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
using Music_Player.Views;
using Music_Player.Views.CancionesViews;
using Music_Player.Views.Enum_CambiarVista;
using Music_Player.Views.UsuariosView;

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


        public Usuario Usuario { get; set; } = new();

        public bool Conectado => Usuario.Id != 0;

        public object? ViewModelAactual
        {
            get { return _miviewmodel; }
            set { _miviewmodel = value; }
        }



        public MinViewModel()
        {

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

            var iniciosesion = catalogo_us.IniciarSesion(Usuario.CorreoElectronico, Usuario.Contraseña);


            if(iniciosesion == 1)
            {
                Usuario = catalogo_us.GetUsuario(Usuario.CorreoElectronico);
                NavegarHome();
            }
            else
            {

            }

        }
        private void CerrarSesion()
        {
            Usuario = new();
            Error = "";
            Actualizar();
        }


        private void NavegarCancionesMegustan()
        {
            cancionesviewmodel.Vista = VistaPeliculas.VerPeliculasMegustan;

            MediadorViewModel.ActualizarVista(cancionesviewmodel.Vista);

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
            cancionesviewmodel.Vista = VistaPeliculas.VerPeliculas;

            MediadorViewModel.ActualizarVista(cancionesviewmodel.Vista);

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
