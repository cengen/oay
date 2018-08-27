using System.Collections.Generic;
using OAY.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace OAY.Web.ViewModels
{
    //public class BatturerListViewModel : ViewModelBase
    public class BatturerListViewModel
    {
        public IList<Battur> Batturer { get; set; }
        //serialisering for bruk i knockout
        public string BatturerJson
        {
            get
            {
                JsonSerializerSettings settings = new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                var batturer = JsonConvert.SerializeObject(this.Batturer, settings);
     
                return batturer;
            }
        }

        public IList<Samarbeidspartner> Samarbeidspartnere { get; set; }
        //serialisering for bruk i knockout
        public string SamarbeidspartnereJson
        {
            get
            {
                var settings = new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                var samarbeidspartnere = JsonConvert.SerializeObject(this.Samarbeidspartnere, settings);

                return samarbeidspartnere;
            }
        }

        public List<Kategori> Kategorier { get; set; }

        public string ImageUrlPrefix
        {
            get { return Config.BatturerImagesUrlPrefix; }

        }

        public bool IsAuthenticated { get; set; }

       

    }
}
