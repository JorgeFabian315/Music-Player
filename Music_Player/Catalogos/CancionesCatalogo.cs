using Microsoft.EntityFrameworkCore;
using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.Catalogos
{
    public class CancionesCatalogo
    {
        MusicPlayerContext context = new();


        public IEnumerable<Cancion> GetCanciones()
        {
           return context.Cancion.Include(c => c.IdArtistaNavigation)
                .Include(c => c.IdGeneroNavigation)
                .OrderBy(can => can.Titulo);
        }


        public Cancion GetCancion(int id)
        {
            var cancion = context.Cancion.Find(id);

            if (cancion != null)
                return cancion;
            else
                return new Cancion();
        }

    }
}
