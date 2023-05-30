using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.Catalogos
{
    public class ArtistasCatalogo
    {

        MusicPlayerContext context = new();

        public IEnumerable<Artista> GetArtistas()
        {
            return context.Artista.OrderBy(artista => artista.Nombre);
        }


    }
}
