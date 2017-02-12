using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoSeletivo.Domain.Entities
{
    public class OperacaoUsuario
    {
        //(ID_OPERACAO_ACESSO, DT_LOG, ID_USUARIO)

        public int Id { get; set; }
        public DateTime DtLog { get; set; }

        public int UsuarioId { get; set; }

        public virtual Usuario Usuario{ get; set; }



    }
}
