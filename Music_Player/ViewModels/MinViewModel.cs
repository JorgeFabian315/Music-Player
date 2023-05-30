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
        #region Vistas 
        VerCancionesView vercancion_view = new () { DataContext = new CancionesViewModel()};
        CancionesMeGustanView cancionesmegustan_view = new() { DataContext = new CancionesViewModel()};
        VerUsuariosView verusuarios_view = new();
        HomeView home_view = new();
        CategoriasCancionesView categorias_view = new();
        #endregion

        public MinViewModel()
        {
            NavegarHome();

        }

       public UserControl? VistaPrincipal { get; set; }

        #region COMANDOS
        public ICommand NavegarCategoriasCommand => new RelayCommand(NavegarCategorias);
        public ICommand NavegarHomeCommand => new RelayCommand(NavegarHome);
        public ICommand NavegarVerCancionesCommand => new RelayCommand(NavegarVerCanciones);
        public ICommand NavegarCancionesMegustanCommand => new RelayCommand(NavegarCancionesMegustan);
        public ICommand NavegarUsuariosCommand => new RelayCommand(NavegarUsuarios);
        #endregion


        private void NavegarCancionesMegustan()
        {
            VistaPrincipal = cancionesmegustan_view;
            PropertyChange();
        }


        private void NavegarUsuarios()
        {
            VistaPrincipal = verusuarios_view;
            PropertyChange();
        }


        private void NavegarHome()
        {
            VistaPrincipal = home_view;
            PropertyChange();
        }

        private void NavegarCategorias()
        {
            VistaPrincipal = categorias_view;
            PropertyChange();
        }

        private void NavegarVerCanciones()
        {
            VistaPrincipal = vercancion_view;
            PropertyChange();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void PropertyChange(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
