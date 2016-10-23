using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace Model绑定
{
    public class DemoController : ApiController
    {
        [Route("demo/{x}/{y}/{z}")]
        public Model Get(Model model, string z)
        {
            return model;
        }

        [Route("demo/{point}")]
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
