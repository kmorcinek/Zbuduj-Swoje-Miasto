using System.Diagnostics;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace KMorcinek.TheCityCardGame.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Set JSON format as default for WebAPI
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Serialize with camelCase formatter for JSON.
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            var settings = jsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            FormatAsIndentedInDebug(settings);
        }

        [Conditional("DEBUG")]
        static void FormatAsIndentedInDebug(JsonSerializerSettings settings)
        {
            settings.Formatting = Formatting.Indented;
        }
    }
}
