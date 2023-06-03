using Microsoft.EntityFrameworkCore;
using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.Catalogos
{
    public class GenerosCatalogo
    {

        MusicPlayerContext context = new();

        // scaffold-dbcontext "server=localhost; database=Music_Player; password=root; user=root" Pomelo.EntityFrameworkCore.MySql -OutputDir "Models" -Force -NoPluralize

        public IEnumerable<Genero> GetGeneros()
        {
            return context.Genero.OrderByDescending(x => x.TotalCanciones);
        }
        public Genero GetGenero(int id)
        {
            var genero = context.Genero.Include(x => x.Cancion).FirstOrDefault(x => x.Id == id);
            if (genero != null)
                return genero;
            else
                return new Genero();
        }
    }
}
