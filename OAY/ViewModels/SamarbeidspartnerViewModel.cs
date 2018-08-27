using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OAY.Models;

namespace OAY.Web.ViewModels
{
    public class SamarbeidspartnerViewModel : ViewModelBase
    {

 
        public Samarbeidspartner Samarbeidspartner { get; set; }

        public bool ErNy { get; set; }

        public string Hovedbilde { get; set; }


        public List<SamarbeidspartnerImage> Bilder { get; set; }
        //serialisering for bruk i knockout
        public string BilderJson
        {
            get
            {
                JsonSerializerSettings settings = new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                var bilder = JsonConvert.SerializeObject(this.Bilder, settings);

                return bilder;
            }
        }

        public string ImageUrlPrefix
        {
            get { return Config.SamarbeidspartnerImagesUrlPrefix; }
        }
    }
}