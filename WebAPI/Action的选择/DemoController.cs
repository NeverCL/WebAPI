using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Action的选择
{
    public class DemoController : ApiController
    {
        public string Get(int x)
        {
            return x + Guid.NewGuid().ToString();
        }

        public string Get(int x, int y)
        {
            return x + Guid.NewGuid().ToString();
        }

        public string Get(string x, string y)
        {
            return x + y;
        }

        public string Get(string x, string y, string z)
        {
            return x + y + z;
        }
    }
}
