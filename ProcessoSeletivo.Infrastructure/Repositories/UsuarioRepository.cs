using ProcessoSeletivo.Domain.Entities;
using ProcessoSeletivo.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoSeletivo.Infrastructure.Repositories
{
    public class UsuarioRepository :RepositoryBase<Usuario>, IUsuarioRepository
    {
        public override void Add(Usuario entity)
        {
            entity.DtInclusao = DateTime.Now;
            base.Add(entity);
        }
    }
}
