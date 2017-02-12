using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoSeletivo.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public bool Ativo { get; set; }

        public DateTime DtInclusao { get; set; }

        public virtual List<OperacaoUsuario> OperacoesUsuario { get; set; }

        public virtual List<Perfil> Perfis { get; set; }
    }
}
