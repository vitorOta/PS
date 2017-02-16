using ProcessoSeletivo.Application.AutoMapper;
using ProcessoSeletivo.Infrastructure.IoC;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Collections.Generic;
using System.Web.Http;

namespace ProcessoSeletivo.Application.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            var container = SimpleInjectorContainer.RegisterServices(new WebApiRequestLifestyle());

            //container.Verify();


            GlobalConfiguration.Configuration.DependencyResolver =
       new SimpleInjectorWebApiDependencyResolver(container);
            GlobalConfiguration.Configure(WebApiConfig.Register);

            AutoMapperConfig.RegisterMappings();

        }
    }
}
