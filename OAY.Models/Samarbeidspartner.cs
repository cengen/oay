using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAY.Models
{
    public class Samarbeidspartner : IAuditInfo
    {
        public int SamarbeidspartnerId { get; set; }
        public string Logo { get; set; }
        public string Link { get; set; } 
   
        public string Overskrift { get; set; }
        public string Ingress { get; set; }    
        public string Beskrivelse { get; set; }
        public int AntallPersoner { get; set; }
        public string Merke { get; set; }

        public DateTime? Opprettet { get; set; }
        public DateTime? Endret { get; set; }

        public ICollection<SamarbeidspartnerImage> SamarbeidspartnerImages { get; set; }
    }
}
