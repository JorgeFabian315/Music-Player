using GalaSoft.MvvmLight.Command;
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
        public ObservableCollection<Cancion> ListaCanciones { get; set; } = new();
        public ObservableCollection<Cancion> ListaCancionesMegusta { get; set; } = new();

        public CancionesViewModel()
        {

            MediadorViewModel.VistaActualizada += MediadorViewModel_VistaActualizada;


            GetCanciones();

            Actualizar();
        }

        CancionesCatalogo _catalogo_can = new();

       public Cancion Cancion { get; set; } = new();


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

            }
        }

        private void VerAgregarCancion()
        {
            Cancion = new();
            Vista = VistaPeliculas.AgregarCancion;
            Actualizar();
        }

        private void VerCancion(int id)
        {
            Cancion = _catalogo_can.GetCancion(id);
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

        public void GetCanciones()
        {
            ListaCanciones = new();
            foreach (var item in _catalogo_can.GetCanciones())
            {
                ListaCanciones.Add(item);
            }
            Actualizar();
        }

        public void GetCancionesMeGusta()
        {
            ListaCancionesMegusta = new();
            var lista = _catalogo_can.GetCanciones().Where(x => x.MeGusta == true);

            foreach (var item in lista)
            {
                ListaCancionesMegusta.Add(item);
            }
            Actualizar();
        }

     
    }
}
