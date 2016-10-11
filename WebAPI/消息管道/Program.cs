using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace 消息管道
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var server = new HttpSelfHostServer(new HttpSelfHostConfiguration("http://localhost:10000")))
            {
                server.Configuration.Routes.MapHttpRoute("default", "{controller}");
                server.OpenAsync();
                Console.Read();
            }

            //HttpMessageHandler handler = new HttpClientHandler();

            //DelegatingHandler delegatingHandler = new HttpServer();

            //HttpServer server = new HttpServer();
        }
    }
}
