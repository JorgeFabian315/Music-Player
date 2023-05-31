using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Music_Player.Views.CancionesViews;
using Music_Player.Views.UsuariosView;

namespace Music_Player.ViewModels
{
    public class MinViewModel: INotifyPropertyChanged
    {


        CancionesViewModel cancionesviewmodel = new();
        UsuariosViewModel usuariosviewmodel = new();
        GenerosViewModel generosviewmodel = new();
        ArtistasViewModel artistasviewmodel = new();


        private object _miviewmodel;

        public object ViewModelAactual
        {
            get { return _miviewmodel; }
            set { _miviewmodel = value; }
        }



        public MinViewModel()
        {
            ViewModelAactual = cancionesviewmodel;
        }


        #region COMANDOS
        public ICommand NavegarCategoriasCommand => new RelayCommand(NavegarGeneros);
        //public ICommand NavegarHomeCommand => new RelayCommand(NavegarHome);
        public ICommand NavegarVerCancionesCommand => new RelayCommand(NavegarVerCanciones);
        public ICommand NavegarCancionesMegustanCommand => new RelayCommand(NavegarCancionesMegustan);
        public ICommand NavegarUsuariosCommand => new RelayCommand(NavegarUsuarios);
        #endregion


        private void NavegarCancionesMegustan()
        {
            ViewModelAactual = cancionesviewmodel;
            PropertyChange();
        }


        private void NavegarUsuarios()
        {
            ViewModelAactual  = usuariosviewmodel;
            PropertyChange();
        }


        //private void NavegarHome()
        //{
        //    VistaPrincipal = home_view;
        //    PropertyChange();
        //}

        private void NavegarGeneros()
        {
            ViewModelAactual = generosviewmodel;
            PropertyChange();
        }

        private void NavegarVerCanciones()
        {
            ViewModelAactual = cancionesviewmodel;
            PropertyChange();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void PropertyChange(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
