using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoSeletivo.Domain.Entities
{
    public class Perfil
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public virtual List<UsuarioPerfil> Usuarios { get; set; }

        public Perfil()
        {
            Ativo = true;
        }

    }
}
