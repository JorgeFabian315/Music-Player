using System;
using System.Collections.Generic;

namespace Music_Player.Models;

public partial class Artista
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int? TotalCanciones { get; set; }

    public string Apodo { get; set; } = null!;

    public string Nacionalidad { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public int IdGenero { get; set; }

    public virtual ICollection<Cancion> Cancion { get; set; } = new List<Cancion>();

    public virtual Genero IdGeneroNavigation { get; set; } = null!;
}
