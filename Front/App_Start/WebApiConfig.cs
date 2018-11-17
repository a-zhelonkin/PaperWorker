using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Front
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter
            {
                SerializerSettings =
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                }
            });

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
            );
        }
    }
}