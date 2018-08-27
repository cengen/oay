using System.Collections.Generic;
using OAY.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace OAY.Web.ViewModels
{
    public class MenyViewModel
    {
        public Meny Meny { get; set; }

        public List<string> MenyTyper {get; set; }
        
        public List<Meny> MenyListe { get; set; }
        //serialisering for bruk i knockout
        public string MenyListeJSON
        {
            get
            {
                JsonSerializerSettings settings = new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
                settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                var menyliste = JsonConvert.SerializeObject(this.MenyListe, settings);
                return menyliste;
            }
        }



        //public bool ErNy { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
