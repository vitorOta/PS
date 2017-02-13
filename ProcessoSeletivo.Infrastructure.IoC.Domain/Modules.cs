using Ninject.Modules;
using ProcessoSeletivo.Domain.Interfaces.Repositories;
using ProcessoSeletivo.Domain.Interfaces.Services;
using ProcessoSeletivo.Domain.Services;
using ProcessoSeletivo.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoSeletivo.Infrastructure.IoC.Domain
{
    public class Modules : NinjectModule
    {
        public override void Load()
        {
            Bind<IUsuarioRepository>().To<UsuarioRepository>();
            Bind<IUsuarioService>().To<UsuarioService>();

            Bind<IPerfilRepository>().To<PerfilRepository>();
            Bind<IPerfilService>().To<PerfilService>();
        }
    }
}
