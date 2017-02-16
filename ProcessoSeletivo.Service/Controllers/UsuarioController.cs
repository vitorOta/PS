using ProcessoSeletivo.Application.Interfaces;
using ProcessoSeletivo.Application.ViewModel;

namespace ProcessoSeletivo.Application.WebApi
{
    public class UsuarioController : ApiControllerBase<UsuarioViewModel>
    {
        
        public UsuarioController(IUsuarioAppService appService) : base(appService)
        {
        }
    }

}
