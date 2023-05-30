using Music_Player.Catalogos;
using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.ViewModels
{
    public class CancionesViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<Cancion> ListaCanciones { get; set; } = new();
        public ObservableCollection<Cancion> ListaCancionesMegusta { get; set; } = new();

        CancionesCatalogo _canciones = new();
        public CancionesViewModel()
        {
            GetCanciones();
            GetCancionesMeGusta();
        }




        public void GetCanciones()
        {
            ListaCanciones = new();
            foreach (var item in _canciones.GetCanciones())
            {
                ListaCanciones.Add(item);
            }
            PropertyChange();
        }

        public void GetCancionesMeGusta()
        {
            ListaCancionesMegusta = new();
            var lista = _canciones.GetCanciones().Where(x => x.MeGusta == 0);

            foreach (var item in lista)
            {
                ListaCancionesMegusta.Add(item);
            }
            PropertyChange();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void PropertyChange(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }











    }
}
