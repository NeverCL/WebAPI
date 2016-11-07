using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;

namespace 参数绑定
{
    class Program
    {
        static void Main(string[] args)
        {
            IHttpActionSelector actionSelector;
            HttpActionContext actionContext;
            HttpParameterBinding httpParameterBinding;
            IActionValueBinder actionValueBinder;
            DefaultActionValueBinder defaultActionValueBinder;
            ModelBinderParameterBinding modelBinderParameterBinding;
        }
    }
}
