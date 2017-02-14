using ProcessoSeletivo.Application.AppServices;
using ProcessoSeletivo.Application.Interfaces;
using ProcessoSeletivo.Domain.Interfaces.Repositories;
using ProcessoSeletivo.Domain.Interfaces.Services;
using ProcessoSeletivo.Domain.Services;
using ProcessoSeletivo.Infrastructure.Repositories;
using SimpleInjector;

namespace ProcessoSeletivo.Infrastructure.IoC
{
    public class SimpleInjectorContainer
    {
        public static Container RegisterServices(ScopedLifestyle lifestyle)
        {
            var container = new Container();
            if (lifestyle != null)
            {
                container.Options.DefaultScopedLifestyle = lifestyle;
            }


            container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>));
            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            container.Register<IUsuarioService, UsuarioService>();
            container.Register<IUsuarioRepository, UsuarioRepository>();


            container.Register<IPerfilService, PerfilService>();
            container.Register<IPerfilRepository, PerfilRepository>();

            container.Register(typeof(IAppServiceBase<>),typeof(AppServiceBase<>));
            container.Register<IUsuarioAppService, UsuarioAppService>();
            container.Register<IPerfilAppService, PerfilAppService>();

            //container.Verify();

            return container;
        }
    }
}
