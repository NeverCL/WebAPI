using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace Model绑定
{
    [RoutePrefix("demo")]
    public class DemoController : ApiController
    {
        [Route("get/{x?}/{y?}/{z?}")]
        public IEnumerable<int> Get(int x, int y, int z)
        {
            yield return x;
            yield return y;
            yield return z;
        }

        [Route("get2/{x}/{y}/{z}")]
        public Model Get(Model model)
        {
            return model;
        }

        [Route("get/{point}")]
        public Point Get(Point point)
        {
            return point;
        }

    }

    [ModelBinder]
    public class Model
    {
        public string X { get; set; }
        public string Y { get; set; }
        public string Z { get; set; }
    }
}
