using ProcessoSeletivo.Domain.Interfaces.Repositories;
using ProcessoSeletivo.Domain.Interfaces.Services;
using ProcessoSeletivo.Domain.Services;
using ProcessoSeletivo.Infrastructure.Repositories;
using SimpleInjector;
using SimpleInjector.Diagnostics;

namespace ProcessoSeletivo.Infrastructure.IoC.Domain
{
    public class SimpleInjectorContainer
    {
        public static Container RegisterServices()
        {
            var container = new Container();


            
            container.Register<IUsuarioService, UsuarioService>();
            container.Register<IUsuarioRepository, UsuarioRepository>();


            container.Register<IPerfilService, PerfilService>();
            container.Register<IPerfilRepository, PerfilRepository>();

            //container.Verify();
            return container;
        }
    }
}
