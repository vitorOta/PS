using ProcessoSeletivo.Application.AppServices;
using ProcessoSeletivo.Application.Interfaces;
using SimpleInjector;

namespace ProcessoSeletivo.Infrastructure.IoC.Application
{
    public class SimpleInjectorContainer
    {
        public static Container RegisterServices()
        {
            var container = new Container();

            container.Register<IUsuarioAppService, UsuarioAppService>();
            container.Register<IPerfilAppService, PerfilAppService>();

            //container.Verify();

            return container;
        }
    }
}
