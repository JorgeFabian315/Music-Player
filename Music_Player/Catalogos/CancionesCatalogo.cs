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
        // scaffold-dbcontext "server=localhost; database=Music_Player; password=root; user=root" Pomelo.EntityFrameworkCore.MySql -OutputDir "Models" -Force -NoPluralize


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
        public void AgregarCancion(Cancion cancion)
        {
            context.Cancion.Add(cancion);
            context.SaveChanges();
        }


        public void EliminarCancion(int id)
        {
            context.Cancion.Where(c => c.Id == id).ExecuteDelete();
        }


        //public void EliminarCancion(Cancion c)
        //{
        //    context.Database.ExecuteSqlRaw($"CALL sp_EliminarCancion ({c.Id})");
        //    context.SaveChanges();
        //}

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
