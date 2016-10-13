using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace Action的选择
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpActionDescriptor actionDescriptor = new ReflectedHttpActionDescriptor(new HttpControllerDescriptor(), null);
            HttpParameterDescriptor parameterDescriptor = new ReflectedHttpParameterDescriptor(actionDescriptor, null);
            IHttpActionSelector selector = new ApiControllerActionSelector();
        }
    }
}
