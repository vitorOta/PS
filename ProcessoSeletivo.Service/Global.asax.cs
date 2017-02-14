
using SimpleInjector;
using System.Web.Http;
using System.Web.Mvc;

namespace ProcessoSeletivo.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new Container();
            container.RegisterCollection(
                ProcessoSeletivo.Infrastructure.IoC.Domain.SimpleInjectorContainer.RegisterServices(),
                ProcessoSeletivo.Infrastructure.IoC.Application.SimpleInjectorContainer.RegisterServices());

            //container.Verify();


            DependencyResolver.SetResolver(container);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            
        }
    }
}
