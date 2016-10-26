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
using System.Web.Http.ValueProviders.Providers;

namespace Model绑定
{
    class Program
    {
        static void Main(string[] args)
        {
            //OpenServer();
            //GetModelMetadata();

            #region ModelMetadata
            ModelMetadata metadata;

            CachedDataAnnotationsModelMetadata cachedDataAnnotationsModelMetadata;

            DataAnnotationsModelMetadataProvider dataAnnotationsModelMetadataProvider;
            #endregion

            #region ValueProviderFactory
            ValueProviderFactory valueProviderFactory;

            RouteDataValueProviderFactory routeDataValueProviderFactory;

            QueryStringValueProviderFactory queryStringValueProviderFactory;

            CompositeValueProviderFactory compositeValueProviderFactory;

            new HttpConfiguration().Services.GetValueProviderFactories();
            #endregion


            Console.ReadKey();
        }

        /// <summary>
        /// 3.0 ValueProvider
        /// </summary>
        private static void CallValueProvider()
        {
            var result = new ValueProviderResult(new[] { "1", "2", "3" }, "", null);
            var result2 = new ValueProviderResult(123, "", null);
            var result3 = new ValueProviderResult(new List<string> { "1", "2", "3" }, "1,2,3", null);
            var rst = result.ConvertTo(typeof(int[]));
            var rst2 = result2.ConvertTo(typeof(int[]));
            var rst3 = result3.ConvertTo(typeof(int[]));

            var list = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("foot", "1"),
                new KeyValuePair<string, string>("foot", "2"),
                new KeyValuePair<string, string>("foot", "3")
            };

            var provider = new NameValuePairsValueProvider(list, null);
            rst3 = provider.GetValue("foot").ConvertTo(typeof(int[]));

            RouteDataValueProvider routeDataValueProvider;

            QueryStringValueProvider queryStringValueProvider;

            CompositeValueProvider compositeValueProvider;
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
