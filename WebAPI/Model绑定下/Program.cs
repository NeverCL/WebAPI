using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.ModelBinding.Binders;
using System.Web.Http.SelfHost;
using Newtonsoft.Json.Serialization;
using IValueProvider = System.Web.Http.ValueProviders.IValueProvider;

namespace Model绑定下
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var server = new HttpSelfHostServer(new HttpSelfHostConfiguration("http://localhost:10000")))
            {
                server.Configuration.MapHttpAttributeRoutes();
                server.OpenAsync();
                Console.ReadKey();
            }

            IModelBinder modelBinder;

            CompositeModelBinder compositeModelBinder;

            ModelBinderProvider modelBinderProvider;

            CompositeModelBinderProvider compositeModelBinderProvider;

            ModelBinderAttribute modelBinderAttribute;

            TypeConverterModelBinder typeConverterModelBinder;

            TypeConverterModelBinderProvider typeConverterModelBinderProvider;


            ComplexModelDto complexModelDto;

            MutableObjectModelBinder mutableObjectModelBinder;

            ComplexModelDtoModelBinder complexModelDtoModelBinder;


            CollectionModelBinder<int> collectionModelBinder;

            ArrayModelBinder<int> arrayModelBinder;

            DictionaryModelBinder<int, int> dictionaryModelBinder;
        }
    }
}
