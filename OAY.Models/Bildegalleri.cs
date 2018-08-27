using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OAY.Models
{
    public class Bildegalleri
    {
        [Key]
        public int BildegalleriId { get; set; }
    
        public string Tittel { get; set; }
        public string Ingress { get; set; }
        public string Tekst1 { get; set; }
        public string Tekst2  { get; set; }
        public string Tekst3 { get; set; }
        public string Tekst4 { get; set; }
        public string Tekst5 { get; set; }
        public string Beskrivelse { get; set; }

        public string TittelEngelsk { get; set; }
        public string IngressEngelsk { get; set; }
        public string Tekst1Engelsk { get; set; }
        public string Tekst2Engelsk { get; set; }
        public string Tekst3Engelsk { get; set; }
        public string Tekst4Engelsk { get; set; }
        public string Tekst5Engelsk { get; set; }
        public string BeskrivelseEngelsk { get; set; }

        public string Type { get; set; }
        public string Model { get; set; }

       


        //public ICollection<Bildegalleri> BildegalleriListe{ get; set; }
    }
}
