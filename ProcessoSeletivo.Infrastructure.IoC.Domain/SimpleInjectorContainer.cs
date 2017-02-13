using ProcessoSeletivo.Application.AppServices;
using ProcessoSeletivo.Application.Interfaces;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoSeletivo.Infrastructure.IoC.Domain
{
    public class SimpleInjectorContainer
    {
        public static Container RegisterServices()
        {
            var container = new Container();
            container.Register<IUsuarioAppService, UsuarioAppService>();
            container.Register<IPerfilAppService, PerfilAppService>();

            container.Verify();
            return container;
        }
    }
}
