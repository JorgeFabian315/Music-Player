using Microsoft.EntityFrameworkCore;
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
        public Artista? GetArtista(int id)
        {
            //return context.Artista.FirstOrDefault(x=>x.Id == id);
            return context.Artista.Include(x=>x.Cancion.OrderBy(w=>w.Titulo)).FirstOrDefault(x => x.Id == id);
        }
        //public IEnumerable<Cancion> GetCancionesPorArtistas(int id)
        //{
        //    return context.Cancion.OrderBy(x => x.IdArtista == id);
        //}
        public void AgregarArtista(Artista a)
        {
            context.Add(a);
            context.SaveChanges();
            context.Entry(a).Reload();
        }
        public void EliminarArtista(Artista a)
        {
            context.Remove(a);
            context.SaveChanges();
            context.Entry(a).Reload();
        }
        public void EditarArtista(Artista a)
        {
            context.Remove(a);
            context.SaveChanges();
            context.Entry(a).Reload();
        }


    }
}
