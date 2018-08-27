using System;
using System.ComponentModel.DataAnnotations;

namespace OAY.Models
{
    public class SamarbeidspartnerImage : IAuditInfo
    {
        [Key]
        public int SamarbeidspartnerImageId { get; set; }
        public string ImageFile { get; set; }
        public int SamarbeidspartnerId { get; set; }
        public bool ErHovedbilde { get; set; }

        public DateTime? Opprettet { get; set; }
        public DateTime? Endret { get; set; }
    }
}

