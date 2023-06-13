using System;
using System.Collections.Generic;

namespace Music_Player.Models;

public partial class Cancion
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public bool? MeGusta { get; set; }

    public int IdArtista { get; set; }

    public DateTime? FechaAgregada { get; set; }

    public int IdGenero { get; set; }

    public int IdUsuario { get; set; }

    public string Duracion { get; set; } = null!;

    public string? Caratula { get; set; }

    public virtual Artista IdArtistaNavigation { get; set; } = null!;

    public virtual Genero IdGeneroNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
