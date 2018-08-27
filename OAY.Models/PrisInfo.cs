using System;

namespace OAY.Models
{
    public class PrisInfo : IAuditInfo
    {
        public int PrisInfoId { get; set; }
      
        public int Timepris { get; set; }
        public string ImageFile { get; set; }
        public int MinimumsTid { get; set; }

        public DateTime? Opprettet { get; set; }
        public DateTime? Endret { get; set; }
    }
}
