﻿using Music_Player.Views.Enum_CambiarVista;
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
        public static event Action<int>? UusarioConectado;

        public static void BuscarUsuario(int id)
        {
            UusarioConectado?.Invoke(id);
        }
        public static event Action? AlActualizarEstadisticas;

        public static void ActualizarEstadisticas()
        {
            AlActualizarEstadisticas?.Invoke();
        }
    }
}
