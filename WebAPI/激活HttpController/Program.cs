using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace 激活HttpController
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. HttpControllerDispatcher
            HttpControllerDispatcher dispatcher = new HttpControllerDispatcher(new HttpConfiguration());

            //2. HttpControllerDescriptor
            HttpControllerDescriptor descriptor = new HttpControllerDescriptor(new HttpConfiguration(), "Demo", typeof(DemoController));
            descriptor.CreateController(new HttpRequestMessage(HttpMethod.Get, "http://localhost/demo"));
        }
    }
}
