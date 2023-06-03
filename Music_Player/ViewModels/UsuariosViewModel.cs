using GalaSoft.MvvmLight.Command;
using Music_Player.Catalogos;
using Music_Player.Models;
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
    public class UsuariosViewModel: INotifyPropertyChanged
    {


        public ObservableCollection<Usuario> ListaUsuarios { get; set; } = new ObservableCollection<Usuario>();
        public Usuario? usuario { get; set; }
        UsuariosCatalogo catalagousuario = new();
        public EnumUsuarioVista Vista { get; set; }

        public ICommand VerBitacorasCommand { get; set; }
        public ICommand RegresarCommand { get; set; }


        public UsuariosViewModel()
        {
            GetUsuarios();
           Vista = EnumUsuarioVista.VerUsuarios;
           VerBitacorasCommand = new RelayCommand<Usuario>(VerBitacoras);
            RegresarCommand = new RelayCommand(Regresar);
        }

        private void Regresar()
        {
            Vista = EnumUsuarioVista.VerUsuarios;
            Actualizar();
        }

        private void VerBitacoras(Usuario u)
        {
            if(u != null)
            {
                usuario = catalagousuario.GetBitacorasUsuario(u.CorreoElectronico);
                Vista = EnumUsuarioVista.VerBitacoras;
                Actualizar();
            }
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
