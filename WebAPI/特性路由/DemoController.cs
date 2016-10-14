using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace 特性路由
{
    [RoutePrefix("api/demo")]
    public class DemoController : ApiController
    {
        [Route("hello")]
        public string Get()
        {
            return "Hello";
        }


        [Route("get")]
        public string Get2()
        {
            return "Hello";
        }
    }
}
