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
    public class ArtistasViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Artista> ListaArtistas { get; set; } = new();


        ArtistasCatalogo catalogo_artistas = new();
        public ArtistasViewModel()
        {
            GetArtistas();
        }

        public void GetArtistas()
        {
            ListaArtistas = new();
            foreach (var item in catalogo_artistas.GetArtistas())
            {
                ListaArtistas.Add(item);
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
