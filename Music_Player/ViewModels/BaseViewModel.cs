using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music_Player.Catalogos;
using Music_Player.Views.Enum_CambiarVista;

namespace Music_Player.Operaciones
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        public BaseViewModel()
        {
            GetCanciones();
            GetArtistas();
            GetGeneros();

        }

        
        public CancionesCatalogo  catalogo_can = new();
        public GenerosCatalogo  catalogo_gen = new();
        public ArtistasCatalogo catalogo_Art = new();
        
        public event PropertyChangedEventHandler? PropertyChanged;

        public  ObservableCollection<Cancion> ListaCanciones { get; set; } = new();
        public ObservableCollection<Cancion> ListaCancionesMegusta { get; set; } = new();
        public ObservableCollection<Genero> ListaGeneros { get; set; } = new();
        public ObservableCollection<Artista> ListaArtistas { get; set; } = new();


        public void GetCanciones()
        {
            ListaCanciones = new();
            
            foreach (var item in catalogo_can.GetCanciones())
            {
                ListaCanciones.Add(item);
            }
            Actualizar();
        }
        public void GetCancionesMeGusta()
        {
            ListaCancionesMegusta = new();
            var lista = catalogo_can.GetCanciones().Where(x => x.MeGusta == true);

            foreach (var item in lista)
            {
                ListaCancionesMegusta.Add(item);
            }
            Actualizar();
        }
        public void Actualizar(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void GetGeneros()
        {
            ListaGeneros.Clear();

            foreach (var item in catalogo_gen.GetGeneros())
            {
                ListaGeneros.Add(item);
            }

            Actualizar();
        }
        public void GetArtistas()
        {
            ListaArtistas = new();
            foreach (var item in  catalogo_Art.GetArtistas())
            {
                ListaArtistas.Add(item);
            }
            Actualizar();
        }

    }
}
