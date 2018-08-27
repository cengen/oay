using System.Collections.Generic;
using OAY.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace OAY.Web.ViewModels
{
    public class BatturViewModel : ViewModelBase
    {

        public int NesteBattur { get; set; }
        public int ForrigeBattur { get; set; }
        public IList<Battur> Batturer { get; set; }

        //serialisering for bruk i knockout
        public string BatturerJSON
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


       public List<Kategori> Kategorier { get; set; }
       //serialisering av Kategorier for bruk i knockout
       public string KategorierJSON
       {
           get
           {
               JsonSerializerSettings settings = new JsonSerializerSettings()
               {
                   ReferenceLoopHandling = ReferenceLoopHandling.Ignore
               };

               var kategorier = JsonConvert.SerializeObject(this.Kategorier, settings);

               return kategorier;
           }
       }


        public Battur Battur { get; set; }
        //serialisering av Kategorier for bruk i knockout
        public string BatturKategorierJSON
        {
            get
            {
                JsonSerializerSettings settings = new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                var batturKategorier = JsonConvert.SerializeObject(this.Battur.Kategorier, settings);

                return batturKategorier;
            }
        }

     
     

        public List<BatturImage> Bilder { get; set; }
        //serialisering for bruk i knockout
        public string BilderJSON
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

        public string Hovedbilde { get; set; }


        public bool ErNy { get; set; }
        public string Pris { get; set; }
       

        public string ImageUrlPrefix
        {
            get { return Config.BatturerImagesUrlPrefix; }
        }

        //public BatturViewModel()
        //{
        //    this.Battur = new Battur();
        //}

    
     
    }
}
