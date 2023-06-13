using FluentValidation;
using GalaSoft.MvvmLight.Command;
using Music_Player.Models;
using Music_Player.Operaciones;
using Music_Player.Validaciones;
using Music_Player.Views.Enum_CambiarVista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Music_Player.ViewModels
{
    public class Admin_Artist_ViewModel : BaseViewModel
    {

        public ICommand VerAgregarArtistaCommand { get; set; }
        public ICommand VerEliminarArtistaCommand { get; set; }
        public ICommand VerEditarArtistaCommand { get; set; }
        public ICommand AgregarArtistaCommand { get; set; }
        public ICommand EditarArtistaCommand { get; set; }
        public ICommand EliminarArtistaCommand { get; set; }
        public ICommand VolverCommand { get; set; }
        public Artista? artista { get; set; }
        public VistaAdministrador Vista { get; set; } = VistaAdministrador.VerArtista;
        public string Error { get; set; } = "";
        public Admin_Artist_ViewModel()
        {
            VerAgregarArtistaCommand = new RelayCommand(VerAgregarArtista);
            VerEliminarArtistaCommand = new RelayCommand(VerEliminarArtista);
            VerEditarArtistaCommand = new RelayCommand(VerEditarArtista);
            AgregarArtistaCommand = new RelayCommand(AgregarArtista);
            EditarArtistaCommand = new RelayCommand(EditarArtista);
            EliminarArtistaCommand = new RelayCommand(EliminarArtista);
            VolverCommand = new RelayCommand(Volver);
            artista = null;
        }
        public void Volver()
        {

            Vista = VistaAdministrador.AgregarArtista;
            Actualizar();
        }
        public void VerAgregarArtista()
        {
            artista = new();
            Vista = VistaAdministrador.AgregarArtista;
            Actualizar();
        }
        public void AgregarArtista()
        {
            if (artista != null)
            {
                ArtistaValidator Validator = new();
                var Result = Validator.Validate(artista, options => { options.IncludeAllRuleSets(); });

                if (Result.IsValid)
                {
                    catalogo_art.AgregarArtista(artista);
                    ActualizarListaArtistas();
                    Vista = VistaAdministrador.VerArtista;
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
            if (artista != null)
            {
                Vista = VistaAdministrador.EliminarArtista;
                Actualizar();
            }
        }
        public void EliminarArtista()
        {
            if (artista != null)
            {
                catalogo_art.EliminarArtista(artista);
                ActualizarListaArtistas();
                Vista = VistaAdministrador.VerArtista;
                Volver();
            }

        }

        //Editar
        public void VerEditarArtista()
        {
            if (artista != null)
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
                Vista = VistaAdministrador.EditarArtista;
                Actualizar();
            }
        }
        public void EditarArtista()
        {
            if (artista != null)
            {
                ArtistaValidator Validator = new();
                var Result = Validator.Validate(artista, options => { options.IncludeAllRuleSets(); });
                var exist = catalogo_Art.GetArtista(artista.Id);
                if (Result.IsValid && exist != null)
                {
                    exist.Id = artista.Id;
                    exist.IdGenero = artista.IdGenero;
                    exist.Cancion = artista.Cancion;
                    exist.Nacionalidad = artista.Nacionalidad;
                    exist.FechaNacimiento = artista.FechaNacimiento;
                    exist.Nombre = artista.Nombre;
                    exist.TotalCanciones = artista.TotalCanciones;
                    exist.IdGeneroNavigation = artista.IdGeneroNavigation;
                    catalogo_Art.EditarArtista(exist);
                    Vista = VistaAdministrador.VerArtista;
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
        public void ActualizarListaArtistas()
        {
            ListaArtistas.Clear();
            foreach (var item in catalogo_art.GetArtistas())
            {
                ListaArtistas.Add(item);
            }
            Actualizar();

        }

    }
}

