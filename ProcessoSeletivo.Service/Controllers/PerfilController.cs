using ProcessoSeletivo.Application.Interfaces;
using ProcessoSeletivo.Application.ViewModel;

namespace ProcessoSeletivo.Application.WebApi
{
    public class PerfilController : ApiControllerBase<PerfilViewModel>
    {
        public PerfilController(IPerfilAppService appService) : base(appService)
        {
        }
    }
}
