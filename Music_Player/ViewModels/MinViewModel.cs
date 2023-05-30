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

        public MinViewModel()
        {
            NavegarHome();
        }

       public UserControl VistaPrincipal { get; set; }

        #region COMANDOS
        public ICommand NavegarCategoriasCommand => new RelayCommand(NavegarCategorias);
        public ICommand NavegarHomeCommand => new RelayCommand(NavegarHome);
        public ICommand NavegarVerCancionesCommand => new RelayCommand(NavegarVerCanciones);
        public ICommand NavegarCancionesMegustanCommand => new RelayCommand(NavegarCancionesMegustan);
        public ICommand NavegarUsuariosCommand => new RelayCommand(NavegarUsuarios);
        #endregion


        private void NavegarCancionesMegustan()
        {
            VistaPrincipal = new CancionesMeGustanView();
            PropertyChange();
        }


        private void NavegarUsuarios()
        {
            VistaPrincipal = new VerUsuariosView();
            PropertyChange();
        }


        private void NavegarHome()
        {
            VistaPrincipal = new HomeView();

            PropertyChange();
        }

        private void NavegarCategorias()
        {
            VistaPrincipal = new CategoriasCancionesView();
            PropertyChange();
        }

        private void NavegarVerCanciones()
        {
            VistaPrincipal = new VerCancionesView();
            PropertyChange();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void PropertyChange(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
