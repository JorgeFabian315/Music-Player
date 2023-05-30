using System;
using System.Collections.Generic;

namespace Music_Player.Models;

public partial class Genero
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int? TotalCanciones { get; set; }

    public virtual ICollection<Cancion> Cancion { get; set; } = new List<Cancion>();
}
