using FluentValidation;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Music_Player.Catalogos;
using Music_Player.Models;
using Music_Player.Operaciones;
using Music_Player.Validaciones;
using Music_Player.Views.ArtistasViews;
using Music_Player.Views.Enum_CambiarVista;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Music_Player.ViewModels
{
    public class ArtistasViewModel:BaseViewModel
    {

        public ICommand  VerCancionesPorArtistaCommand { get; set; }     
        public ICommand VolverCommand { get; set; }    
        public ICommand VerMasPopularesCommand { get; set; }
        public VistaArtista Vista { get; set; } = VistaArtista.VerArtistas;
        public List<Populares> Lista_Populares { get; set; } = new();
        
        public Artista? artista { get; set; }

        public ArtistasViewModel(MusicPlayerContext context):base(context)
        {
            VerMasPopularesCommand = new RelayCommand(LlenarListaPopulares);
            VerCancionesPorArtistaCommand = new RelayCommand<int>(VerInfoArtista);
            VolverCommand = new RelayCommand(Volver);
            ActualizarListaArtistas();
            
        }

        public string Error { get; set; } = "";
        int a = 1;
        public void LlenarListaPopulares()
        {
            a = 1;
            Lista_Populares.Clear();
            foreach (var item in catalogo_art.GetPopulares())
            {
                var e = ListaArtistas.FirstOrDefault(x => x.Nombre == item.Nombre);
                string? img = e.Fotografia;
                if (img == null) { img = "https://www.salonlfc.com/wp-content/uploads/2018/01/image-not-found-scaled.png"; }
                Populares p = new Populares
                {
                    Rank = a,
                    Imagen = img,
                    Vista = item
                };
                
                
                Lista_Populares.Add(p);
                a++;
            }
            Vista = VistaArtista.VerArtistasPorGenero;
            
            Actualizar();
        }

    


        public void Volver()
        {
            artista = null;
            Vista = VistaArtista.VerArtistas;
            Actualizar();
        }
        public void ActualizarListaArtistas()
        {
            ListaArtistas.Clear();
            foreach (var item in catalogo_art.GetArtistas())
            {
                if(item.Fotografia == null)
                {
                    item.Fotografia = "https://www.salonlfc.com/wp-content/uploads/2018/01/image-not-found-scaled.png";
                }
                ListaArtistas.Add(item);
            }
            Actualizar();

        }


        //public void VerAgregarArtista()
        //{
        //    artista = new();
        //    Vista = VistaArtista.AgregarArtista;
        //    Actualizar();
        //}
        //public void AgregarArtista()
        //{
        //    if(artista!= null)
        //    {
        //        ArtistaValidator Validator = new();
        //        var Result = Validator.Validate(artista, options => { options.IncludeAllRuleSets(); });

        //        if(Result.IsValid)
        //        {
        //            catalogo_art.AgregarArtista(artista);
        //            ActualizarListaArtistas();
        //            Vista = VistaArtista.VerArtistas;
        //            Volver();
        //        }
        //        else
        //        {
        //            Error = "";
        //            foreach (var item in Result.Errors)
        //            {
        //                Error = $"{Error} {item} {Environment.NewLine}";
        //            }
        //            Actualizar();
        //        }
                
        //    }
            
        //}

        //Eliminar
        //public void VerEliminarArtista()
        //{
        //    if(artista!= null)
        //    {
        //        Vista = VistaArtista.EliminarArtista;
        //        Actualizar();
        //    }
        //}
        //public void EliminarArtista()
        //{
        //    if(artista!= null )
        //    {
        //        catalogo_art.EliminarArtista(artista);
        //        ActualizarListaArtistas();
        //        Vista = VistaArtista.VerArtistas;
        //        Volver();
        //    }
            
        //}

        //Editar
        //public void VerEditarArtista()
        //{
        //    if(artista != null)
        //    {
        //        Artista Clon = new Artista()
        //        {
        //            Nombre = artista.Nombre,
        //            Id = artista.Id,
        //            TotalCanciones = artista.TotalCanciones,
        //            Apodo = artista.Apodo,
        //            Nacionalidad = artista.Nacionalidad,
        //            FechaNacimiento = artista.FechaNacimiento,
        //            IdGenero = artista.IdGenero,
        //            IdGeneroNavigation = artista.IdGeneroNavigation,
        //            Cancion = artista.Cancion
        //        };
        //        artista = Clon;
        //        Vista = VistaArtista.EditarArtista;
        //        Actualizar();
        //    }
        //}
        //public void EditarArtista()
        //{
        //    if(artista != null)
        //    {
        //        ArtistaValidator Validator = new();
        //        var Result = Validator.Validate(artista, options => { options.IncludeAllRuleSets(); });
        //        var exist = catalogo_art.GetArtista(artista.Id);
        //        if (Result.IsValid && exist != null)
        //        {
        //            exist.Id = artista.Id;
        //            exist.IdGenero = artista.IdGenero;
        //            exist.Cancion = artista.Cancion;
        //            exist.Nacionalidad = artista.Nacionalidad;
        //            exist.FechaNacimiento = artista.FechaNacimiento;
        //            exist.Nombre = artista.Nombre;
        //            exist.TotalCanciones = artista.TotalCanciones;
        //            exist.IdGeneroNavigation= artista.IdGeneroNavigation;
        //            catalogo_art.EditarArtista(exist);
        //            Vista = VistaArtista.VerArtistas;
        //            Volver();
        //        }
        //        else
        //        {
        //            Error = "";
        //            foreach (var item in Result.Errors)
        //            {
        //                Error = $"{Error} {item} {Environment.NewLine}";
        //            }
        //        }
        //        Actualizar();

        //    }
        //}


        //Metodo que hace cosas perronas
        public void VerInfoArtista(int a)
        {
            artista = catalogo_art.GetArtista(a) ;
            Vista = VistaArtista.VerCancionesPorArtista;
            
            Actualizar();
        }

        
    }
    public class Populares
    {
        public int Rank { get; set; }
        public string? Imagen { get; set; } 
        public Vistaultrasuperperrona Vista { get; set; }
    }
}
