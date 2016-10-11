using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace 消息管道
{
    public class DemoController : ApiController
    {
        public IEnumerable<string> Get()
        {
            var cfg = new HttpConfiguration();
            cfg.MessageHandlers.Add(new Handler1());
            cfg.MessageHandlers.Add(new Handler1());
            cfg.MessageHandlers.Add(new Handler1());
            var server = new MyServer(cfg);
            server.Initialize();
            return GetHandlers(server);
        }

        private IEnumerable<string> GetHandlers(MyServer server)
        {
            DelegatingHandler next = server;
            yield return next.ToString();
            while (next.InnerHandler != null)
            {
                yield return next.InnerHandler.ToString();
                next = next.InnerHandler as DelegatingHandler;
                if (next == null)
                    break;
            }
        }
    }
    class MyServer : HttpServer
    {
        public MyServer(HttpConfiguration cfg) : base(cfg) { }

        public new void Initialize()
        {
            base.Initialize();
        }
    }
    class Handler1 : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
