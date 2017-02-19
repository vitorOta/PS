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
        public override void Update(Usuario entity)
        {
            var perfis = entity.Perfis;
            entity.Perfis = null;
            base.Update(entity);
            //gambiarra, eu sei. Mas o sono tá alto
            if (perfis != null && perfis.Count > 0)
            {
                entity.Perfis = perfis;
                base.Update(entity);
            }
        }

    }
}
