using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using System.Web.Http;

namespace cyoaCreator
{
    internal class ApiStartup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.UseFileServer(new FileServerOptions
            {
                RequestPath = PathString.Empty,
                FileSystem = new PhysicalFileSystem(@".\Content"),
            });

            appBuilder.Use(typeof(OwinLogger));

            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute(name: "default", routeTemplate: "{controller}", defaults: new { ip = RouteParameter.Optional });

            config.MapHttpAttributeRoutes();

            appBuilder.UseWebApi(config);

        }
    }
}
