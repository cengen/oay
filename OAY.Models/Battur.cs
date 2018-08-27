using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OAY.Models
{
    public class Battur : IAuditInfo
    {
        private int _minimumsTid = 2;

        public int BatturId { get; set; }
        public string FraSted { get; set; }
        public string TilSted { get; set; }
        [DefaultValue(2)]
        public int MinimumTid
        {
            get { return _minimumsTid; }
            set { _minimumsTid = value; }
        }
        public int Pris { get; set; }
        public string Overskrift { get; set; }
        public string Ingress { get; set; }
        public string Beskrivelse { get; set; }
        public string EngelskBeskrivelse{ get; set; }
        public string Hovedbilde { get; set; }
        
        public DateTime? Opprettet { get; set; }
        public DateTime? Endret { get; set; }

        public ICollection<Kategori> Kategorier { get; set; }
        public ICollection<BatturImage> BatturImages { get; set; }
        public ICollection<BatturKategori> BatturKategorier { get; set; }
    }
}
