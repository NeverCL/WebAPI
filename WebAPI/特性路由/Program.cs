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
                ShowAttrRoute(server.Configuration.Routes);
                ShowSubRoutesTokens(server.Configuration.Routes);
                ShowRoutes(server.Configuration.Routes);
                server.OpenAsync();
                Console.Read();
            }
        }

        private static void ShowSubRoutesTokens(HttpRouteCollection routes)
        {
            foreach (var subRoute in routes.GetSubRoutes())
            {
                Console.WriteLine(subRoute.RouteTemplate);
                foreach (var dataToken in subRoute.DataTokens)
                {
                    Console.WriteLine("{0,-12}{1}", dataToken.Key, dataToken.Value);
                }
                Console.WriteLine();
            }
        
        }

        private static void ShowAttrRoute(HttpRouteCollection routes)
        {
            var subRoutes = routes.GetSubRoutes();
            if (subRoutes == null)
            {
                Console.WriteLine("未注册特性路由");
                return;
            }
            ShowRoutes(subRoutes);
        }

        private static void ShowRoutes(IEnumerable<IHttpRoute> routes)
        {
            Console.WriteLine("{0,-10}{1}", "类型名称", "模板");
            foreach (var route in routes)
            {
                Console.WriteLine("{0,-10}{1}", route.GetType().Name, route.RouteTemplate);
                Console.WriteLine();
            }
        }
    }

    public static class RouteCollectionExt
    {
        public static IEnumerable<IHttpRoute> GetSubRoutes(this HttpRouteCollection routes)
        {
            var route = routes["MS_attributerouteWebApi"];
            var prop = route.GetType().GetProperty("SubRoutes", BindingFlags.Instance | BindingFlags.NonPublic);
            var subRoutes = prop.GetValue(route) as IEnumerable<IHttpRoute>;
            return subRoutes;
        }
    }
}
