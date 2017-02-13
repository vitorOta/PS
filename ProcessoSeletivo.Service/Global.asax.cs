using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Routing;

namespace ProcessoSeletivo.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DependencyResolver.SetResolver();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            
        }
    }
}
