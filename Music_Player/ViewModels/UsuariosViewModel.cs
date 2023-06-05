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
        //public ObservableCollection<Usuario> ListaAdmin { get; set; } = new ObservableCollection<Usuario>();
        public Usuario? usuario { get; set; }
        UsuariosCatalogo catalagousuario = new();
        public EnumUsuarioVista Vista { get; set; }

        public ICommand VerBitacorasCommand { get; set; }
        public ICommand RegresarCommand { get; set; }
        public ICommand VerUsuariosAdminCommand { get; set; }
        public ICommand VerUsuariosNormalCommand { get; set; }
        public ICommand VerUsuariosVIPCommand { get; set; }
        public ICommand VerAgregarUsuarioCommand { get; set; }
        public ICommand AgregarUsuarioCommand { get; set; }


        public UsuariosViewModel()
        {
            GetUsuarios();
            VerAdmins();
            Vista = EnumUsuarioVista.VerUsuarios;
            VerBitacorasCommand = new RelayCommand<Usuario>(VerBitacoras);
            RegresarCommand = new RelayCommand(Regresar);
            VerUsuariosAdminCommand = new RelayCommand(VerAdmins);
            VerUsuariosVIPCommand = new RelayCommand(VerVIP);
            VerUsuariosNormalCommand = new RelayCommand(VerUsuarios);
            VerAgregarUsuarioCommand = new RelayCommand(VerAgregar);
            AgregarUsuarioCommand = new RelayCommand(Agregar);
        }

        private void VerAgregar()
        {
            Vista = EnumUsuarioVista.VerAgregar;
            Actualizar();
        }

        private void Agregar()
        {
            if(usuario != null)
            {
                catalagousuario.Agregar(usuario);
                Actualizar();
            }
        }

        private void VerUsuarios()
        {
            ListaUsuarios.Clear();
            foreach (var item in catalagousuario.GetUsuariosNormal())
            {
                ListaUsuarios.Add(item);
            }
            Actualizar();
        }

        private void VerVIP()
        {
            ListaUsuarios.Clear();
            foreach (var item in catalagousuario.GetUsuariosVIP())
            {
                ListaUsuarios.Add(item);
            }
            Actualizar();
        }

        private void VerAdmins()
        {
            ListaUsuarios.Clear();
            foreach (var item in catalagousuario.GetUsuariosAdmin())
            {
                ListaUsuarios.Add(item);
            }
            Actualizar();

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
