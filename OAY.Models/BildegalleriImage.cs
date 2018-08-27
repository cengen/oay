using System;
using System.ComponentModel.DataAnnotations;

namespace OAY.Models
{
    public class BildegalleriImage
    {
        [Key]
        public int BildeId { get; set; }
        public string ImageFile { get; set; }
        public string Beskrivelse { get; set; }
        public bool ErHovedbilde { get; set; }


    }
}
