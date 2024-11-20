using System.Web.Http;

namespace Proyecto._2
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register); // Aquí se llama al registro de rutas de la API
        }
    }
}
