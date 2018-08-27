using System.Collections.Generic;

namespace OAY.Models
{
    public class Kategori 
    {
        public int KategoriId { get; set; }
        public string KategoriNavn { get; set; }

        public ICollection<BatturKategori> BatturKategorier { get; set; }

    }
}
