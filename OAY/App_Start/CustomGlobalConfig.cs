using System.Web.Http;
using System.Web.Http.Validation.Providers;
using Newtonsoft.Json.Serialization;

namespace OAY
{
    public class CustomGlobalConfig
    {
        public static void Customize(HttpConfiguration config)
        {
            //fixes issus with overly-aggressive validation provider
            config.Services.RemoveAll(
                typeof(System.Web.Http.Validation.ModelValidatorProvider),
                v => v is InvalidModelValidatorProvider);

            //fixes så all info mellom klient og server er json
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

          //  config.Filters.Add(new ValidationActionFilter());
            

           
        }
    }
}
