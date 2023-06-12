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
        public ICommand VerAgregarArtistaCommand { get; set; }
        public ICommand VerEliminarArtistaCommand { get; set; }
        public ICommand VerEditarArtistaCommand { get; set; }
        public ICommand VolverCommand { get; set; }
        public ICommand AgregarArtistaCommand { get; set; }
        public ICommand EditarArtistaCommand { get; set; }
        public ICommand EliminarArtistaCommand { get; set; }
        public ICommand VerMasPopularesCommand { get; set; }
        public VistaArtista Vista { get; set; } = VistaArtista.VerArtistas;
        public List<Vistaultrasuperperrona> Lista_Para_Ver_Los_Mas_Populars_Asi_Es { get; set; } = new();
        public Artista? artista { get; set; }
        public string Error { get; set; } = "";
        public ArtistasViewModel(MusicPlayerContext context):base(context)
        {
            VerCancionesPorArtistaCommand = new RelayCommand<Artista>(VerInfoArtista);
            VerAgregarArtistaCommand = new RelayCommand(VerAgregarArtista);
            VerEliminarArtistaCommand = new RelayCommand(VerEliminarArtista);
            VerEditarArtistaCommand = new RelayCommand(VerEditarArtista);
            VolverCommand = new RelayCommand(Volver);
            AgregarArtistaCommand = new RelayCommand(AgregarArtista);
            EditarArtistaCommand = new RelayCommand(EditarArtista);
            EliminarArtistaCommand = new RelayCommand(EliminarArtista);
            //VerMasPopularesCommand = new RelayCommand(Llenar_la_lista_de_nombre_cuestionable);
            
        }
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

        //Metodo que hace cosas perronas
        public void VerInfoArtista(Artista a)
        {
            artista = a;
            Vista = VistaArtista.VerCancionesPorArtista;
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

    }
}
