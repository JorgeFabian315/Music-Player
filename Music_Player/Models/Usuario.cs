using System;
using System.Collections.Generic;

namespace Music_Player.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public int IdRol { get; set; }

    public virtual ICollection<BitacoraUsuario> BitacoraUsuario { get; set; } = new List<BitacoraUsuario>();

    public virtual ICollection<Cancion> Cancion { get; set; } = new List<Cancion>();

    public virtual Rol IdRolNavigation { get; set; } = null!;
}
