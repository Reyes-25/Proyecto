using System.Web.Http;

namespace Proyecto._2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
<<<<<<< HEAD:Proyecto.2/Proyecto.2/App_Start/WebApiConfig.cs
            // Configuración y servicios de API Web

            // Rutas de API Web
=======
            // Configuración y servicios de Web API

            // Rutas de Web API
>>>>>>> 2c056b70096dcca3d6658c3cc7564e1fafcd26a4:Proyecto.2/App_Start/WebApiConfig.cs
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
