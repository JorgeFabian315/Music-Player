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
        public CancionesCatalogo catalogo_can;
        public ArtistasCatalogo catalogo_art;
        public UsuariosCatalogo catalogo_us;
        public BaseViewModel(MusicPlayerContext context)
        {
            catalogo_can = new(context);
            catalogo_art = new(context);
            catalogo_us = new(context);
            GetArtistas();
            GetGeneros();
        }


        public ObservableCollection<Cancion> ListaCanciones { get; set; } = new();
        public ObservableCollection<Cancion> ListaCancionesMegusta { get; set; } = new();
        public ObservableCollection<Genero> ListaGeneros { get; set; } = new();
        public ObservableCollection<Artista> ListaArtistas { get; set; } = new();
        public ObservableCollection<Artista> ListaTopArtistas { get; set; } = new();
        public ObservableCollection<Cancion> ListaTopCanciones { get; set; } = new();


        public void GetCanciones(int id)
        {
            ListaCanciones = new();

            foreach (var item in catalogo_can.GetCanciones(id))
            {
                ListaCanciones.Add(item);
            }

            ListaCanciones.OrderBy(c => c.FechaAgregada).ThenBy(c => c.Titulo);
            Actualizar();
        }

        public void GetCancionesMeGusta(int id)
        {
            ListaCancionesMegusta.Clear();
            var lista = ListaCanciones.Where(x => x.MeGusta == true).OrderBy(c => c.FechaAgregada);
            
            foreach (var item in lista)
            {
                ListaCancionesMegusta.Add(item);
            }
            Actualizar();
        }

        public void GetGeneros()
        {
            ListaGeneros.Clear();

            foreach (var item in catalogo_can.GetGeneros())
            {
                ListaGeneros.Add(item);
            }

            Actualizar();
        }

        public void GetArtistas()
        {
            ListaArtistas.Clear();
            foreach (var item in catalogo_art.GetArtistas())
            {
                ListaArtistas.Add(item);
            }
            Actualizar();
        }


        public void GetTopArtistas()
        {
            ListaTopArtistas.Clear();
            ListaTopCanciones.Clear();
            var lista_art = ListaArtistas.OrderByDescending(x => x.TotalCanciones).Take(6);
            var lista_can = ListaCanciones.OrderByDescending(x => x.FechaAgregada).Take(6);

            foreach (var art in lista_art)
            {
                ListaTopArtistas.Add(art);
            }
            foreach (var can in lista_can)
            {
                ListaTopCanciones.Add(can);
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
