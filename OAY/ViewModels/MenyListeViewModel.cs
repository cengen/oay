using System.Collections.Generic;
using OAY.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace OAY.Web.ViewModels
{
    public class MenyListeViewModel
    {
       

        public List<Meny> ForrettListe { get; set; }
        //serialisering for bruk i knockout
        public string ForrettListeJson
        {
            get
            {
                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                var forrett = JsonConvert.SerializeObject(this.ForrettListe, settings);
                return forrett;
            }
        }
        public List<Meny> HovedrettListe { get; set; }
        //serialisering for bruk i knockout
        public string HovedrettListeJson
        {
            get
            {
                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                var hovedrett = JsonConvert.SerializeObject(this.HovedrettListe, settings);
                return hovedrett;
            }
        }
        public List<Meny> DessertListe { get; set; }
        //serialisering for bruk i knockout
        public string DessertListeJson
        {
            get
            {
                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                var dessert = JsonConvert.SerializeObject(this.DessertListe, settings);
                return dessert;
            }
        }
        public IList<Meny> RodvinListe { get; set; }
        //serialisering for bruk i knockout
        public string RodvinListeJson
        {
            get
            {
                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                var rodvin = JsonConvert.SerializeObject(this.RodvinListe, settings);
                return rodvin;
            }
        }
        public List<Meny> HvitvinListe { get; set; }
        //serialisering for bruk i knockout
        public string HvitvinListeJson
        {
            get
            {
                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                var hvitvin = JsonConvert.SerializeObject(this.HvitvinListe, settings);
                return hvitvin;
            }
        }
        public List<Meny> LikorListe { get; set; }
        //serialisering for bruk i knockout
        public string LikorListeJson
        {
            get
            {
                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                var likor = JsonConvert.SerializeObject(this.LikorListe, settings);
                return likor;
            }
        }
        public List<Meny> AperitiffListe { get; set; }
        //serialisering for bruk i knockout
        public string AperitiffListeJson
        {
            get
            {
                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                var aperitiff = JsonConvert.SerializeObject(this.AperitiffListe, settings);
                return aperitiff;
            }
        }
        public List<Meny> DiverseListe { get; set; }
        //serialisering for bruk i knockout
        public string DiverseListeJson
        {
            get
            {
                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                var diverse = JsonConvert.SerializeObject(this.DiverseListe, settings);
                return diverse;
            }
        }

        public bool IsAuthenticated { get; set; }
    }
}
