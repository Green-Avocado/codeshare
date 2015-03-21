using System.Net.Http.Headers;
using System.Web.Http;
using CrossCutting.MainModule.IOC;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CodeShare.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;

            json.SerializerSettings.Formatting = Formatting.Indented;

            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            json.SerializerSettings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            var container = IocUnityContainer.Instance;
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}