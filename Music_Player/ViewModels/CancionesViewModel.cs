using Music_Player.Catalogos;
using Music_Player.Models;
using Music_Player.Views;
using Music_Player.Views.Enum_CambiarVista;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.ViewModels
{
    public class CancionesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Cancion> ListaCanciones { get; set; } = new();
        public ObservableCollection<Cancion> ListaCancionesMegusta { get; set; } = new();

        CancionesCatalogo _canciones = new();

        public VistaPeliculas Vista { get; set; }
        public CancionesViewModel()
        {

            MediadorViewModel.VistaActualizada += MediadorViewModel_VistaActualizada;

            GetCanciones();

            Actualizar();
        }

        private void MediadorViewModel_VistaActualizada(VistaPeliculas vista)
        {
            Vista = vista;
            if(vista == VistaPeliculas.VerPeliculasMegustan)
                GetCancionesMeGusta();
            Actualizar();
        }

        public void GetCanciones()
        {
            ListaCanciones = new();
            foreach (var item in _canciones.GetCanciones())
            {
                ListaCanciones.Add(item);
            }
            Actualizar();
        }

        public void GetCancionesMeGusta()
        {
            ListaCancionesMegusta = new();
            var lista = _canciones.GetCanciones().Where(x => x.MeGusta == true);

            foreach (var item in lista)
            {
                ListaCancionesMegusta.Add(item);
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
