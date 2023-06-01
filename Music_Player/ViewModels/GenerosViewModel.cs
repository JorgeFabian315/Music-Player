using Music_Player.Catalogos;
using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.ViewModels
{
    public class GenerosViewModel : INotifyPropertyChanged
    {


        public ObservableCollection<Genero> ListaGeneros { get; set; } = new();

        GenerosCatalogo cgenero = new();
        public GenerosViewModel()
        {
            GetGeneros();
        }


        private void GetGeneros()
        {
            ListaGeneros.Clear();



            foreach (var item in cgenero.GetGeneros())
            {
                ListaGeneros.Add(item);
            }

            Actualizar();
        }



        public event PropertyChangedEventHandler? PropertyChanged;

        public void Actualizar(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
