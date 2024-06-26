
using FluentValidation.Validators;
using Microsoft.EntityFrameworkCore;
using Music_Player.Models;
using MySqlConnector;
﻿using Music_Player.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.Catalogos
{
    public class ArtistasCatalogo
    {

        private readonly MusicPlayerContext _context = new();

        public ArtistasCatalogo(MusicPlayerContext context)
        {
            _context = context;
        }
        public IEnumerable<Vistaultrasuperperrona> GetPopulares()
        {

           return _context.Vistaultrasuperperrona.OrderBy(x => x.Genero);

        }
        //public string? GetImagen(string nombre)
        //{
        //    var a = _context.Artista.FirstOrDefault(x => x.Nombre == nombre);
        //    return a.Fotografia;
        //}

        public IEnumerable<Artista> GetArtistas()
        {
            return _context.Artista.OrderBy(artista => artista.Nombre);
        }
        public Artista? GetArtista(int id)
        {
            return _context.Artista.FirstOrDefault(x=>x.Id == id);
        }
        public IEnumerable<Cancion> GetCancionesPorArtistas(int id)
        {
            return _context.Cancion.OrderBy(x => x.IdArtista == id);
        }
        //public void AgregarArtista(Artista a)
        //{
        //    _context.Add(a);
        //    _context.SaveChanges();
        //    _context.Entry(a).Reload();
        //}
        //public void EliminarArtista(Artista a)
        //{
        //    _context.Remove(a);
        //    _context.SaveChanges();
        //    _context.Entry(a).Reload();
        //}
        //public void EditarArtista(Artista a)
        //{
        //    _context.Remove(a);
        //    _context.SaveChanges();
        //    _context.Entry(a).Reload();
        //}

        //public void Reload(Artista a)
        //{
        //    context.Entry(a).Reload();
        //}
    }
}
