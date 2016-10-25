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
            //OpenServer();
            //GetModelMetadata();

            //var metadata = new ModelMetadata(null, null, null, null, null);

            //var cached = new CachedDataAnnotationsModelMetadata(null, null);

            //var metadataProvider = new DataAnnotationsModelMetadataProvider();

            //var dataAnnotationsModelMetadataProvider = new DataAnnotationsModelMetadataProvider();

            var result = new ValueProviderResult(new[] { "1", "2", "3" }, "", null);
            var result2 = new ValueProviderResult(123, "", null);
            var rst = result.ConvertTo(typeof(int[]));
            var rst2 = result2.ConvertTo(typeof(int[]));
            Console.ReadKey();
        }

        /// <summary>
        /// 2.0 获取元数据
        /// </summary>
        private static void GetModelMetadata()
        {
            var provider = new HttpConfiguration().Services.GetModelMetadataProvider();
            foreach (CachedDataAnnotationsModelMetadata property in provider.GetMetadataForType(() => new Model { X = "1" }, typeof(Model)).Properties)
            {
                Console.WriteLine($"{property.GetDisplayName()}-{property.Model}-{property.ModelType}-{property.IsReadOnly}");
            }
        }

        /// <summary>
        /// 1.0 启动WebAPI
        /// </summary>
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
