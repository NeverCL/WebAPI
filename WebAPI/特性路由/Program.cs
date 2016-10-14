using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;
using System.Web.Http.SelfHost;

namespace 特性路由
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Route Attr
            //IHttpRouteInfoProvider route = new RouteAttribute();

            //RoutePrefixAttribute prefix = new RoutePrefixAttribute("api");

            //HttpConfigurationExtensions.MapHttpAttributeRoutes(new HttpConfiguration());
            EnableRouteAttr();


        }

        private static void EnableRouteAttr()
        {
            using (var server = new HttpSelfHostServer(new HttpSelfHostConfiguration("http://localhost:10000")))
            {
                server.Configuration.MapHttpAttributeRoutes();
                server.Configuration.Routes.MapHttpRoute("default", "{controller}");
                server.Configuration.EnsureInitialized();
                server.OpenAsync();
                Console.Read();
            }
        }
    }
}
