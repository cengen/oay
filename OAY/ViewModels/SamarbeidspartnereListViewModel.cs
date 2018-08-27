using System.Collections.Generic;
using OAY.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace OAY.Web.ViewModels
{
    //public class SamarbeidspartnereListViewModel : ViewModelBase
    public class SamarbeidspartnereListViewModel
    {
        public IList<Samarbeidspartner> Samarbeidspartnere { get; set; }

        public bool ErNy { get; set; }

        //serialisering for bruk i knockout
        public string SamarbeidspartnereJson
        {
            get
            {
                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                var samarbeidspartnere = JsonConvert.SerializeObject(this.Samarbeidspartnere, settings);

                return samarbeidspartnere;
            }
        }
        public string ImageUrlPrefix => Config.SamarbeidspartnerImagesUrlPrefix;
    }
}
