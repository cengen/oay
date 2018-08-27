using System;
using System.ComponentModel.DataAnnotations;


namespace OAY.Models
{
    public class BatturImage : IAuditInfo
    {
        [Key]
        public int ImageId { get; set; }
        public string ImageFile { get; set; }
        public int BatturId { get; set; }
        public bool ErHovedbilde { get; set; }

        public DateTime? Opprettet { get; set; }
        public DateTime? Endret { get; set; }
    }
}
