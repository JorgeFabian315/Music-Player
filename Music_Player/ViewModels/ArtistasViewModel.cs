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
        public List<Vistaultrasuperperrona> Lista_Para_Ver_Los_Mas_Populars_Asi_Es { get; set; } = new();
        public Artista? artista { get; set; }
<<<<<<< HEAD
        public ArtistasViewModel()
=======
        public string Error { get; set; } = "";
        public ArtistasViewModel(MusicPlayerContext context):base(context)
>>>>>>> f33bcec5e0f2d0fb4141c63e0d9e3441d362c128
        {
            VerCancionesPorArtistaCommand = new RelayCommand<int>(VerInfoArtista);
            
            VolverCommand = new RelayCommand(Volver);
<<<<<<< HEAD
            
            VerMasPopularesCommand = new RelayCommand(Llenar_la_lista_de_nombre_cuestionable);
=======
            AgregarArtistaCommand = new RelayCommand(AgregarArtista);
            EditarArtistaCommand = new RelayCommand(EditarArtista);
            EliminarArtistaCommand = new RelayCommand(EliminarArtista);
            //VerMasPopularesCommand = new RelayCommand(Llenar_la_lista_de_nombre_cuestionable);
>>>>>>> f33bcec5e0f2d0fb4141c63e0d9e3441d362c128
            
            
        }
<<<<<<< HEAD
        public void Llenar_la_lista_de_nombre_cuestionable()
        {
            Lista_Para_Ver_Los_Mas_Populars_Asi_Es.Clear();
            foreach (var item_de_nombre_innecesariamente_largo_para_que_se_vea_mucho_codigo in catalogo_Art.GetMasPopulares())
            {
                Lista_Para_Ver_Los_Mas_Populars_Asi_Es.Add(item_de_nombre_innecesariamente_largo_para_que_se_vea_mucho_codigo);
            }
            Vista = VistaArtista.VerArtistasPorGenero;
            Actualizar();
        }
=======
        //public void Llenar_la_lista_de_nombre_cuestionable()
        //{
        //    Lista_Para_Ver_Los_Mas_Populars_Asi_Es.Clear();
        //    foreach (Vistaultrasuperperrona item_de_nombre_innecesariamente_largo_para_que_se_vea_mucho_codigo in 
        //        catalogo_art.GetMasPopulares())
        //    {
        //        Lista_Para_Ver_Los_Mas_Populars_Asi_Es.Add(item_de_nombre_innecesariamente_largo_para_que_se_vea_mucho_codigo);
        //    }
        //    Vista = VistaArtista.VerCancionesPorArtista;
        //    Actualizar();
        //}
>>>>>>> f33bcec5e0f2d0fb4141c63e0d9e3441d362c128
        
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
                ListaArtistas.Add(item);
            }
            Actualizar();

        }

        //Agregar
<<<<<<< HEAD
       
=======
        public void VerAgregarArtista()
        {
            artista = new();
            Vista = VistaArtista.AgregarArtista;
            Actualizar();
        }
        public void AgregarArtista()
        {
            if(artista!= null)
            {
                ArtistaValidator Validator = new();
                var Result = Validator.Validate(artista, options => { options.IncludeAllRuleSets(); });

                if(Result.IsValid)
                {
                    catalogo_art.AgregarArtista(artista);
                    ActualizarListaArtistas();
                    Vista = VistaArtista.VerArtistas;
                    Volver();
                }
                else
                {
                    Error = "";
                    foreach (var item in Result.Errors)
                    {
                        Error = $"{Error} {item} {Environment.NewLine}";
                    }
                    Actualizar();
                }
                
            }
            
        }

        //Eliminar
        public void VerEliminarArtista()
        {
            if(artista!= null)
            {
                Vista = VistaArtista.EliminarArtista;
                Actualizar();
            }
        }
        public void EliminarArtista()
        {
            if(artista!= null )
            {
                catalogo_art.EliminarArtista(artista);
                ActualizarListaArtistas();
                Vista = VistaArtista.VerArtistas;
                Volver();
            }
            
        }

        //Editar
        public void VerEditarArtista()
        {
            if(artista != null)
            {
                Artista Clon = new Artista()
                {
                    Nombre = artista.Nombre,
                    Id = artista.Id,
                    TotalCanciones = artista.TotalCanciones,
                    Apodo = artista.Apodo,
                    Nacionalidad = artista.Nacionalidad,
                    FechaNacimiento = artista.FechaNacimiento,
                    IdGenero = artista.IdGenero,
                    IdGeneroNavigation = artista.IdGeneroNavigation,
                    Cancion = artista.Cancion
                };
                artista = Clon;
                Vista = VistaArtista.EditarArtista;
                Actualizar();
            }
        }
        public void EditarArtista()
        {
            if(artista != null)
            {
                ArtistaValidator Validator = new();
                var Result = Validator.Validate(artista, options => { options.IncludeAllRuleSets(); });
                var exist = catalogo_art.GetArtista(artista.Id);
                if (Result.IsValid && exist != null)
                {
                    exist.Id = artista.Id;
                    exist.IdGenero = artista.IdGenero;
                    exist.Cancion = artista.Cancion;
                    exist.Nacionalidad = artista.Nacionalidad;
                    exist.FechaNacimiento = artista.FechaNacimiento;
                    exist.Nombre = artista.Nombre;
                    exist.TotalCanciones = artista.TotalCanciones;
                    exist.IdGeneroNavigation= artista.IdGeneroNavigation;
                    catalogo_art.EditarArtista(exist);
                    Vista = VistaArtista.VerArtistas;
                    Volver();
                }
                else
                {
                    Error = "";
                    foreach (var item in Result.Errors)
                    {
                        Error = $"{Error} {item} {Environment.NewLine}";
                    }
                }
                Actualizar();

            }
        }
>>>>>>> f33bcec5e0f2d0fb4141c63e0d9e3441d362c128

        //Metodo que hace cosas perronas
        public void VerInfoArtista(int a)
        {
            artista = catalogo_Art.GetArtista(a) ;
            Vista = VistaArtista.VerCancionesPorArtista;
            
            Actualizar();
        }

        
    }
}
