using System.Web.Http;
using Servicio.App_Start;
using System.Web;

namespace Servicio
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
