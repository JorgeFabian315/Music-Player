using GalaSoft.MvvmLight.Command;
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
    public class GenerosViewModel : BaseViewModel
    {




        GenerosCatalogo cgenero = new();

        public Genero? Genero { get; set; }

        public VistaGeneros Vista { get; set; } = VistaGeneros.VerGeneros;
        public GenerosViewModel()
        {
        }

        public ICommand VerCancionesGeneroCommand => new RelayCommand<int>(VerCancionesGenero);
        public ICommand RegresarCommand => new RelayCommand(Regresar);

        private void Regresar()
        {
            Vista = VistaGeneros.VerGeneros;
            Actualizar();
        }

        private void VerCancionesGenero(int id)
        {
            Genero = cgenero.GetGenero(id);
            if (Genero != null)
                Vista = VistaGeneros.VerCancionesPorGenero;
            Actualizar();
        }

      
    }
}
