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
    public class UsuariosViewModel: INotifyPropertyChanged
    {

        public ObservableCollection<Usuario> ListaUsuarios { get; set; } = new ObservableCollection<Usuario>();
        public Usuario? usuario { get; set; }
        UsuariosCatalogo catalagousuario = new();


        public UsuariosViewModel()
        {
            GetUsuarios();
        }

        public void GetUsuarios()
        {
            ListaUsuarios.Clear();
            foreach (var item in catalagousuario.GetUsuarios())
            {
                ListaUsuarios.Add(item);
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
