using System;

namespace OAY.Models
{
    public class BatturKategori : IAuditInfo
    {
        public int BatturKategoriId { get; set; }            
        public int BatturId { get; set; }
        public int KategoriId { get; set; }

        public DateTime? Opprettet { get; set; }
        public DateTime? Endret { get; set; }
    }
}
