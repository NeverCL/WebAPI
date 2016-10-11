using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;
using System.Web.Http.SelfHost.Channels;

namespace 消息管道
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1. Web API管道对象
            //HttpMessageHandler handler = new HttpClientHandler();

            //DelegatingHandler delegatingHandler = new HttpServer();

            //HttpServer server = new HttpServer(); 
            #endregion

            using (var server = new MyHttpSelfHostServer("http://localhost:10000"))
            {
                server.Configuration.Routes.MapHttpRoute("default", "{controller}");
                server.OpenAsync();
                Console.Read();
            }
        }

        #region 3. ByHttpBinding
        static void ByHttpBinding()
        {
            var binding = new HttpBinding();
            var listener = binding.BuildChannelListener<IReplyChannel>(new Uri("http://localhost:10000"));
            listener.Open();//开启监听

            var reply = listener.AcceptChannel();
            reply.Open();//开启通信通道

            while (true)
            {
                var request = reply.ReceiveRequest();//接受到请求
                request.Reply(CreateMessage());//回复消息
            }
        }

        static Message CreateMessage()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent("Hello");
            var type = Type.GetType("System.Web.Http.SelfHost.Channels.HttpMessage,System.Web.Http.SelfHost");
            return (Message)Activator.CreateInstance(type, response);
        }
        #endregion

        /// <summary>
        /// 2. Self Host
        /// </summary>
        private static void SelfHost()
        {
            using (var server = new HttpSelfHostServer(new HttpSelfHostConfiguration("http://localhost:10000")))
            {
                server.Configuration.Routes.MapHttpRoute("default", "{controller}");
                server.OpenAsync();
                Console.Read();
            }
        }
    }

    public class MyHttpSelfHostServer : HttpServer
    {
        private string _url;
        public MyHttpSelfHostServer(string url)
        {
            _url = url;
        }

        public async void OpenAsync()
        {
            var binding = new HttpBinding();
            var listener = binding.BuildChannelListener<IReplyChannel>(new Uri(_url));
            listener.Open();//开启监听
            var reply = listener.AcceptChannel();
            reply.Open();//开启通信通道
            while (true)
            {
                var request = reply.ReceiveRequest();//接受到请求
                //获取HttpRequestMessage
                var method = request.RequestMessage.GetType().GetMethod("GetHttpRequestMessage");
                var requestMessage = method.Invoke(request.RequestMessage, new object[] { true }) as HttpRequestMessage;
                var response = await base.SendAsync(requestMessage, new CancellationTokenSource().Token);
                request.Reply(CreateMessage(response));//回复消息
            }
        }

        Message CreateMessage(HttpResponseMessage response)
        {
            var type = Type.GetType("System.Web.Http.SelfHost.Channels.HttpMessage,System.Web.Http.SelfHost");
            return (Message)Activator.CreateInstance(type, response);
        }
    }
}
