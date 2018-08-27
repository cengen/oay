using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OAY.Models
{
    public class Bloggpost : IAuditInfo
    {
        public int BloggpostId { get; set; }
        public string BloggpostOverskrift { get; set; }
        public string BloggpostInnhold { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")] 
        public DateTime? Opprettet { get; set; }
        public DateTime? Endret { get; set; }

        public ICollection<Bloggsvar> BloggsvarListe { get; set; }
        public ICollection<BloggImage> BloggimageListe { get; set; }
    }
}
