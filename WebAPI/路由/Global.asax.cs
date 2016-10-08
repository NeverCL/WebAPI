using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace 路由
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var defaults = new RouteValueDictionary//路由变量默认值
            {
                 {"code","010"},
                 {"phone","1000000"},
            };
            var constraints = new RouteValueDictionary//路由变量约束
            {
                {"code",@"0\d{2,3}" },
                {"phone",@"\d{7,9}" },
                {"httpMethod",new HttpMethodConstraint("POST") }
            };
            var dataTokens = new RouteValueDictionary//路由相关参数,不用于处理路由匹配功能
            {
                {"defaultCode","北京" },
                {"defaultPhone","北京X电话" }
            };
            RouteTable.Routes.MapPageRoute("default", "{code}/{phone}", "~/call.aspx", false, defaults, constraints, dataTokens);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}