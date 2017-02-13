using ProcessoSeletivo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProcessoSeletivo.Application.Interfaces;

namespace ProcessoSeletivo.Service.Controllers
{
    public class PerfilController : ApiControllerBase<Perfil>
    {
        public PerfilController(IPerfilAppService appService) : base(appService)
        {
        }
    }
}
