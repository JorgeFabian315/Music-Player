using Music_Player.Views.Enum_CambiarVista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.ViewModels
{
   public static class MediadorViewModel
    {
        public static event Action<VistaUsuario>? VistaActualizada;

        public static void ActualizarVista(VistaUsuario vista)
        {
            VistaActualizada?.Invoke(vista);
        }
    }
}
