using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoSeletivo.Domain.Entities
{
    public class UsuarioPerfil
    {
        public int UsuarioId { get; set; }
        public int PerfilId { get; set; }

        public bool? Ativo { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Perfil Perfil { get; set; }

    }
}
