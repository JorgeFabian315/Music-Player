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

        // scaffold-dbcontext "server=localhost; database=Music_Player; password=root; user=root" Pomelo.EntityFrameworkCore.MySql -OutputDir "Models" -Force -NoPluralize

        private readonly MusicPlayerContext _context;
        public CancionesCatalogo(MusicPlayerContext context)
        {
            _context = context;
        }

        public IEnumerable<Cancion> GetCanciones(int id)
        {
            return _context.Cancion
                 .Include(c => c.IdArtistaNavigation)
                 .Where(c => c.IdUsuario == id)
                 .OrderByDescending(c => c.FechaAgregada)
                 .ThenBy(c => c.Titulo); 
        }


        public Cancion GetCancion(int id = 1)
        {
            var cancion = _context.Cancion
                .Include(c => c.IdGeneroNavigation)
                .FirstOrDefault(c => c.Id == id);
            if (cancion != null)
                return cancion;
            else
                return new Cancion();
        }
        public void AgregarCancion(Cancion cancion)
        {
            _context.Cancion.Add(cancion);
            _context.SaveChanges();
        }

        public void GetActualizarMeGusta(int id, bool estado)
        {
            _context.Cancion.Where(c => c.Id == id)
                .ExecuteUpdate(c => c.SetProperty(f => f.MeGusta, estado));
        }

        //public void EliminarCancion(int id)
        //{
        //    context.Cancion.Where(c => c.Id == id).ExecuteDelete();
        //}


        public void EliminarCancion(Cancion can)
        {
          _context.Database.ExecuteSqlRaw($"CALL sp_EliminarCancion ({can.Id})");
          _context.SaveChanges();
        }

        //public void ReloadGeneros(Genero g)
        //{
        //    _context.Entry(g).Reload();
        //}
        //public void EliminarCancion(Cancion c)
        //{
        //    context.Entry(g).Reload();
        //}
        public void ReloadCanciones(Cancion c)
        {
            _context.Entry(c).Reload();
        }
        public IEnumerable<Genero> GetGeneros()
        {
            return _context.Genero.OrderByDescending(x => x.TotalCanciones);
        }
        public Genero GetGenero(int id)
        {
            var genero = _context.Genero.Include(x => x.Cancion).FirstOrDefault(x => x.Id == id);
            if (genero != null)
                return genero;
            else
                return new Genero();
        }

        public void EditarCancion(Cancion exis, Cancion c)
        {
            _context.Entry(exis).CurrentValues.SetValues(c);

            _context.Cancion.Update(exis);
            _context.SaveChanges();  
        }

        public void Recargar(int id)
        {
            var g = _context.Genero.Find(id);
            if(g != null)
                _context.Entry(g).Reload();
        }

        public IEnumerable<VwCancionesfavoritas> GetCancionesFavoritas()
        {
            return _context.VwCancionesfavoritas;
        }
        public int TotalCanciones()
        {
            return _context.Cancion.Count();
        }
    }
}
