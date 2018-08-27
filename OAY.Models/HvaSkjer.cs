using System;

namespace OAY.Models
{
    public class HvaSkjer
    {
        public int HvaSkjerId { get; set; }
        public string Overskrift { get; set; }
        public string Innhold { get; set; }
        public int Dag { get; set; }
        public string Mnd { get; set; }
        public string Link { get; set; }

        public DateTime? Opprettet { get; set; }
        public DateTime? Endret { get; set; }
    }
}
