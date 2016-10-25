using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Metadata;
using System.Web.Http.Metadata.Providers;
using System.Web.Http.SelfHost;
using System.Web.Http.ValueProviders;

namespace Model绑定
{
    class Program
    {
        static void Main(string[] args)
        {
            OpenServer();
            ModelMetadata metadata = new ModelMetadata(null, null, null, null, null);

            CachedDataAnnotationsModelMetadata cached = new CachedDataAnnotationsModelMetadata(null, null);

            //var cfg = new HttpConfiguration();
            //var provider = cfg.Services.GetModelMetadataProvider();
            //foreach (var property in provider.GetMetadataForType(() => new Model { X = "1" }, typeof(Model)).Properties)
            //{
            //    Console.WriteLine($"{property.PropertyName}-{property.Model}-{property.ModelType}-{property.IsReadOnly}");
            //}

            //Console.ReadKey();

        }

        private static void OpenServer()
        {
            using (var server = new HttpSelfHostServer(new HttpSelfHostConfiguration("http://localhost:10000")))
            {
                server.Configuration.MapHttpAttributeRoutes();
                server.OpenAsync();
                Console.Read();
            }
        }
    }
}
