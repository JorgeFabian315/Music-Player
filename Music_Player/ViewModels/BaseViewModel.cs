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
            GetArtistas();
            GetGeneros();
            GetCanciones();
            GetTopArtistas();

        }

        public CancionesCatalogo  catalogo_can = new();
        public ArtistasCatalogo catalogo_Art = new();
        UsuariosCatalogo catalogo_us = new();


        public  ObservableCollection<Cancion> ListaCanciones { get; set; } = new();
        public ObservableCollection<Cancion> ListaCancionesMegusta { get; set; } = new();
        public ObservableCollection<Genero> ListaGeneros { get; set; } = new();
        public ObservableCollection<Artista> ListaArtistas { get; set; } = new();
        public ObservableCollection<Artista> ListaTopArtistas { get; set; } = new();
        public ObservableCollection<Cancion> ListaTopCanciones { get; set; } = new();







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
            ListaArtistas = new();
            foreach (var item in  catalogo_Art.GetArtistas())
            {
                ListaArtistas.Add(item);
            }
            Actualizar();
        }

        //public void RecargarArtistas(ObservableCollection<Artista> lista)
        //{
        //    foreach (var item in lista)
        //    {
        //        catalogo_Art.Reload(item);
        //    }
        //    Actualizar();
        //}

        //public void RecargarCanciones(ObservableCollection<Cancion> lista)
        //{
        //    foreach (var item in lista)
        //    {
        //        catalogo_can.ReloadCanciones(item);
        //    }
        //    Actualizar();
        //}

        //public void RecargarGeneros(ObservableCollection<Genero> lista)
        //{
        //    foreach (var item in lista)
        //    {
        //        catalogo_can.Reload(item);
        //    }
        //    Actualizar();
        //}

        public event PropertyChangedEventHandler? PropertyChanged;

        public void Actualizar(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
    }
}
