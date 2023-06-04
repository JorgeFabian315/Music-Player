using Music_Player.Catalogos;
using Music_Player.Models;
using Music_Player.Operaciones;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.ViewModels
{
    public class ArtistasViewModel:BaseViewModel
    {
        Artista artista;
        public ArtistasViewModel()
        {
            ActualizarListaArtistas();
        }
        public void ActualizarListaArtistas()
        {
            ListaArtistas.Clear();
            foreach (var item in catalogo_Art.GetArtistas())
            {
                ListaArtistas.Add(item);
            }
            Actualizar();
            
        }
        public void AgregarArtista()
        {

        }
        public void EliminarArtista()
        {

        }
        public void EditarArtista()
        {

        }
        public void MetodoQueHaceCosasPerronas()
        {

        }
    }
}
