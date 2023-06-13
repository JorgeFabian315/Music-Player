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
        public ArtistasViewModel()
        {
            VerCancionesPorArtistaCommand = new RelayCommand<int>(VerInfoArtista);
            
            VolverCommand = new RelayCommand(Volver);
            
            VerMasPopularesCommand = new RelayCommand(Llenar_la_lista_de_nombre_cuestionable);
            
            
        }
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
        
        public void Volver()
        {
            artista = null;
            Vista = VistaArtista.VerArtistas;
            Actualizar();
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

        //Agregar
       

        //Metodo que hace cosas perronas
        public void VerInfoArtista(int a)
        {
            artista = catalogo_Art.GetArtista(a) ;
            Vista = VistaArtista.VerCancionesPorArtista;
            
            Actualizar();
        }

        
    }
}
