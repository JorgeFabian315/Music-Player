using Music_Player.Models;
using Music_Player.Operaciones;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ObservableCollection<Artista> ListaTopArtistas { get; set; } = new();
        public ObservableCollection<Cancion> ListaTopCanciones { get; set; } = new();
        public HomeViewModel()
        {

            GetTopArtistas();
        }





        public void GetTopArtistas()
        {
            ListaTopArtistas.Clear();
            ListaTopCanciones.Clear();
            var lista_art =  ListaArtistas.OrderByDescending(x => x.TotalCanciones).Take(6);
            var lista_can =  ListaCanciones.OrderByDescending(x => x.FechaAgregada).Take(6);

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
