using Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.Catalogos
{
    public class RolCatalogo
    {
        MusicPlayerContext context = new();

        public IEnumerable<Rol> GetRoles()
        {
            foreach (var rol in context.Rol)
            {
                yield return rol;
            }
        }
    }
}
