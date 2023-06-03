﻿using GalaSoft.MvvmLight.Command;
using Music_Player.Catalogos;
using Music_Player.Models;
using Music_Player.Operaciones;
using Music_Player.Views;
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
    public class CancionesViewModel : BaseViewModel
    {

        public CancionesViewModel()
        {

            MediadorViewModel.VistaActualizada += MediadorViewModel_VistaActualizada;


            Actualizar();
        }

       public Cancion Cancion { get; set; } = new();

        public int Minutos { get; set; }
        public int Segundos { get; set; }
        public VistaPeliculas Vista { get; set; }

        public int TotalCancionesMegustas { get; set; } 

        public ICommand VerCancionCommand => new RelayCommand<int>(VerCancion);
        public ICommand RegresarCommand => new RelayCommand(Regresar);
        public ICommand VerAgregarCancionCommand => new RelayCommand(VerAgregarCancion);
        public ICommand AgregarCancionCommand => new RelayCommand(AgregarCancion);

        private void AgregarCancion()
        {
            if (Cancion != null)
            {
                Cancion.Duracion = $"{Minutos}:{Segundos}";
                Cancion.IdUsuario = 1;
                catalogo_can.AgregarCancion(Cancion);
                GetCanciones();
                Regresar();
            }
        }

        private void VerAgregarCancion()
        {
            Cancion = new();
            Minutos = 0;
            Segundos = 0;
            Vista = VistaPeliculas.AgregarCancion;
            Actualizar();
        }

        private void VerCancion(int id)
        {
            Cancion = catalogo_can.GetCancion(id);
            if (Cancion != null)
                Vista = VistaPeliculas.VerCancion;
            Actualizar();
        }

        private void Regresar()
        {
            Vista = VistaPeliculas.VerPeliculas;
            Actualizar();
        }

        private void MediadorViewModel_VistaActualizada(VistaPeliculas vista)
        {
            Vista = vista;
            if (vista == VistaPeliculas.VerPeliculasMegustan)
                GetCancionesMeGusta();

           TotalCancionesMegustas = ListaCancionesMegusta.Count;

            Actualizar();
        }



     

     
    }
}
