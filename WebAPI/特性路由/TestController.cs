using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace 特性路由
{
    public class TestController : ApiController
    {
        [Route("test/get",Name = "default2")]
        public string Get()
        {
            return "Heelo";
        }
    }
}
