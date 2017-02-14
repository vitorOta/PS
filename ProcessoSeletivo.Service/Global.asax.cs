using ProcessoSeletivo.Infrastructure.IoC;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Collections.Generic;
using System.Web.Http;

namespace ProcessoSeletivo.Service
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
            
        }
    }
}
