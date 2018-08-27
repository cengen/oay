using System;
using System.ComponentModel.DataAnnotations;

namespace OAY.Models
{
    public class BloggImage : IAuditInfo
    {
        [Key]
        public int ImageId { get; set; }
        public string ImageFile { get; set; }
        public int BloggpostId { get; set; }

        public DateTime? Opprettet { get; set; }
        public DateTime? Endret { get; set; }

    }
}
