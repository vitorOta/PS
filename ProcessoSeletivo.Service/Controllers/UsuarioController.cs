using ProcessoSeletivo.Application.Interfaces;
using ProcessoSeletivo.Domain.Entities;
using System.Collections.Generic;

namespace ProcessoSeletivo.Service.Controllers
{
    public class UsuarioController : ApiControllerBase<Usuario>
    {
        
        public UsuarioController(IUsuarioAppService appService) : base(appService)
        {
        }
    }

}
