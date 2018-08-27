using System.Collections.Generic;
using OAY.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace OAY.Web.ViewModels
{
    public class BildegalleriViewModel
    {
        public string Hovedbilde { get; set; }
        public IList<BildegalleriImage> Bilder{ get; set; }
 
        //serialisering for bruk i knockout
        public string BilderJson
        {
            get
            {
                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };


                var bilder = JsonConvert.SerializeObject(this.Bilder, settings);

                return bilder;
            }
        }

        public Bildegalleri Bildegalleri { get; set; }
    

        //i config.cs og under appSettings i web.config
        //definerer statiske verdier - her relativ sti til bilder
        public string ImageUrlPrefix(int id)
        {
            var prefix = Config.BildegalleriImagesFolderPath;
            return prefix + id + ".jpg";
        }
    }
}
