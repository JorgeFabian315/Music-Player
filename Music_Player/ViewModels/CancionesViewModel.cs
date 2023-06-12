﻿using GalaSoft.MvvmLight.Command;
using Music_Player.Catalogos;
using Music_Player.Models;
using Music_Player.Operaciones;
using Music_Player.Validaciones;
using Music_Player.Views;
using Music_Player.Views.Enum_CambiarVista;
using System;
using FluentValidation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Threading;
using AutoMapper;
using Music_Player.Profile;

namespace Music_Player.ViewModels
{
    public class CancionesViewModel : BaseViewModel
    {

        public Usuario? Usuario { get; set; }

        private IMapper _mapper;
        public CancionesViewModel(MusicPlayerContext _context) : base(_context)
        {

            _mapper = (Mapper)CancionProfile.Initialize();

            MediadorViewModel.VistaActualizada += MediadorViewModel_VistaActualizada;
            MediadorViewModel.UusarioConectado += MediadorViewModel_UusarioConectado;
        }

        private int _idGeneroViejo;
        public Cancion Cancion { get; set; }
        public Genero Genero { get; set; }


        public int Minutos { get; set; }
        public int Segundos { get; set; }
        public VistaUsuario Vista { get; set; }
        public string Error { get; set; } = "";
        public int TotalCancionesMegustas { get; set; }
        public ICommand VerCancionCommand => new RelayCommand<int>(VerCancion);
        public ICommand RegresarCommand => new RelayCommand(Regresar);
        public ICommand VerAgregarCancionCommand => new RelayCommand(VerAgregarCancion);
        public ICommand AgregarCancionCommand => new RelayCommand(AgregarCancion);
        public ICommand EliminarCancionCommand => new RelayCommand<int>(EliminarCancion);
        public ICommand VerCancionesGeneroCommand => new RelayCommand<int>(VerCancionesGenero);
        public ICommand ActualizarMeGustaCommand => new RelayCommand<bool>(ActualizarEstadoCancion);
        public ICommand VerEditarCancionCommand => new RelayCommand<int>(VerEditarCancion);

        private void VerEditarCancion(int id)
        {
            Cancion = catalogo_can.GetCancion(id);
            if (Cancion != null)
            {
                Vista = VistaUsuario.EditarCancion;
                //var clon = new Cancion()
                //{
                //    Id = Cancion.Id,
                //    Titulo = Cancion.Titulo,
                //    Duracion = Cancion.Duracion,
                //    IdArtista = Cancion.IdArtista,
                //    IdGenero = Cancion.IdGenero,
                //    IdUsuario = Cancion.IdUsuario,
                //    MeGusta = Cancion.MeGusta,
                //    FechaAgregada = Cancion.FechaAgregada,
                //    IdArtistaNavigation = Cancion.IdArtistaNavigation,
                //    IdGeneroNavigation = Cancion.IdGeneroNavigation,
                //    IdUsuarioNavigation = Cancion.IdUsuarioNavigation
                //};

                var clon = _mapper.Map<Cancion>(Cancion);

                Cancion = clon;

                _idGeneroViejo = Cancion.IdGenero;

                Actualizar();
            }
        }

        private void EliminarCancion(int id)
        {
            if (id > 0)
            {
                catalogo_can.EliminarCancion(id);
                //GetCanciones();
            }
        }

        private void AgregarCancion()
        {
            if (Cancion != null && Usuario != null)
            {
                Error = "";

                Cancion.IdUsuario = Usuario.Id;

                CancionValidator validations = new CancionValidator();
                var result = validations.Validate(Cancion, options =>
                {
                    options.IncludeAllRuleSets();
                });

                if (result.IsValid)
                {
                    if (Cancion.Id > 0)
                    {
                        var existe = catalogo_can.GetCancion(Cancion.Id);

                        if (existe != null)
                        {
                            // existe = _mapper.Map<Cancion>(Cancion);
                            catalogo_can.EditarCancion(existe, Cancion);
                            if (Cancion.Id != _idGeneroViejo)
                            {
                                catalogo_can.Recargar(_idGeneroViejo);

                            }

                        }
                    }
                    else
                    {
                        catalogo_can.AgregarCancion(Cancion);
                    }

                    catalogo_can.Recargar(Cancion.IdGenero);
                    GetCanciones(Usuario.Id);
                    Regresar();
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        Error = $"{Error} {error} {Environment.NewLine}";
                    }
                    Actualizar();
                }

            }
        }

        private void VerAgregarCancion()
        {
            Cancion = new();
            Minutos = 0;
            Segundos = 0;
            Error = "";
            Vista = VistaUsuario.AgregarCancion;
            Actualizar();
        }

        private void VerCancion(int id)
        {
            Cancion = catalogo_can.GetCancion(id);
            if (Cancion != null)
                Vista = VistaUsuario.VerCancion;
            Actualizar();
        }
        private void ActualizarEstadoCancion(bool estado)
        {
            catalogo_can.GetActualizarMeGusta(Cancion.Id, estado);
            Actualizar();
        }


        private void Regresar()
        {
            if (Vista == VistaUsuario.VerCancionesPorGenero)
                Vista = VistaUsuario.VerGeneros;
            else
                Vista = VistaUsuario.VerCanciones;
            Actualizar();
        }

        private void MediadorViewModel_VistaActualizada(VistaUsuario vista)
        {
            Vista = vista;
            if (vista == VistaUsuario.VerCancionesMegustan)
                GetCancionesMeGusta(Usuario.Id);
            else if (vista == VistaUsuario.Home)
                GetTopArtistas();
            TotalCancionesMegustas = ListaCancionesMegusta.Count;

            Actualizar();
        }
        private void MediadorViewModel_UusarioConectado(int id)
        {
            GetCanciones(id);
            Usuario = catalogo_us.GetIdUsuario(id);
        }

        private void VerCancionesGenero(int id)
        {
            Genero = catalogo_can.GetGenero(id);
            if (Genero != null)
                Vista = VistaUsuario.VerCancionesPorGenero;
            Actualizar();
        }

    }
}
