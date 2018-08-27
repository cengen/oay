using System;
namespace OAY.Models
{
    public class Bloggsvar : IAuditInfo
    {
        public int BloggsvarId { get; set; }
        public int BloggpostId { get; set; }
        public string BloggsvarNavn { get; set; }
        public string BloggsvarInnhold { get; set; }

        public DateTime? Opprettet { get; set; }
        public DateTime? Endret { get; set; }

        public Bloggpost Bloggpost { get; set; }
    }
}
