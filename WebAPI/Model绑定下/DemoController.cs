using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.ModelBinding.Binders;

namespace Model绑定下
{
    public class DemoController : ApiController
    {
        [Route("demo/get")]
        public string Get()
        {
            return "Hello World";
        }

        [Route("get/{x}/{y}/{z}")]
        public IEnumerable<Model> Get(Model model, [ModelBinder(Name = "m")] Model model2)
        {
            yield return model;
            yield return model2;
        }


        [Route("get")]
        public IEnumerable<int> Get([ModelBinder]IEnumerable<int> strs)
        {
            return strs;
        }

        [Route("get")]
        public int[] Get(int[] strs)
        {
            return strs;
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
