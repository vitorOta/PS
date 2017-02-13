using ProcessoSeletivo.Domain.Entities;
using ProcessoSeletivo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessoSeletivo.Domain.Interfaces.Repositories;

namespace ProcessoSeletivo.Domain.Services
{
    public class PerfilService : ServiceBase<Perfil>, IPerfilService
    {
        public PerfilService(IPerfilRepository repository) : base(repository)
        {
        }
    }
}
