using System;
using System.Collections.Generic;

namespace Music_Player.Models;

public partial class BitacoraUsuario
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public DateTime? FechaAgregada { get; set; }

    public int IdUsuario { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
