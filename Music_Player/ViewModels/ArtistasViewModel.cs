using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Music_Player.Catalogos;
using Music_Player.Models;
using Music_Player.Operaciones;
using Music_Player.Views.Enum_CambiarVista;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Music_Player.ViewModels
{
    public class ArtistasViewModel:BaseViewModel
    {
        public ICommand  VerCancionesPorArtistaCommand { get; set; }
         public ICommand AgregarArtistaCommand { get; set; }
        public ICommand EditarArtistaCommand { get; set; }
        public ICommand EliminarArtistaCommand { get; set; }
        public VistaArtista Vista { get; set; } = VistaArtista.VerArtistas;
        Artista artista;
        public ArtistasViewModel()
        {
            //ActualizarListaArtistas();
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
