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
           return context.Cancion.Include(c => c.IdArtistaNavigation).OrderBy(can => can.Titulo);
        }
    }
}
