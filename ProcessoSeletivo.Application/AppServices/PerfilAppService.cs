using ProcessoSeletivo.Application.Interfaces;
using ProcessoSeletivo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessoSeletivo.Domain.Interfaces.Services;
using ProcessoSeletivo.Application.ViewModel;

namespace ProcessoSeletivo.Application.AppServices
{
    public class PerfilAppService : AppServiceBase<PerfilViewModel, Perfil>, IPerfilAppService
    {
        public PerfilAppService(IPerfilService service) : base(service)
        {
        }
    }
}
