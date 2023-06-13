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
     public  class EstadisticasViewModel:BaseViewModel
    {
     
        public ObservableCollection<Genero> ListaTopGeneros { get; set; } = new();
        public ObservableCollection<VwCancionesfavoritas> ListaCancionesFavoritas { get; set; } = new();

        public EstadisticasViewModel(MusicPlayerContext context):base(context)
        {

            Cargar();
            
        }

        private void Cargar()
        {
            ListaTopGeneros.Clear();
            ListaCancionesFavoritas.Clear();

            var lista = ListaGeneros.OrderByDescending(c => c.TotalCanciones).Take(3);
            foreach (var item in lista)
            {
                ListaTopGeneros.Add(item);
            }
            foreach (var item2 in catalogo_can.GetCancionesFavoritas())
            {
                ListaCancionesFavoritas.Add(item2);
            }
            Actualizar();
        }


    }
}
