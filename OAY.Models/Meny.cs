using System;

namespace OAY.Models
{
    public class Meny : IAuditInfo
    {
        public int MenyId { get; set; }
        public string Type { get; set; }
        public string Beskrivelse { get; set; }
        public string EngelskBeskrivelse { get; set; }
        public int Pris { get; set; }

        public DateTime? Opprettet { get; set; }
        public DateTime? Endret { get; set; }
    }
}
