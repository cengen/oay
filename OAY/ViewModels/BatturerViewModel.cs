using OAY.Models;
using System.Collections.Generic;

namespace OAY.Web.ViewModels
{
    public class BatturerViewModel
    {
        public IList<Battur> Batturer { get; set; }
        public IList<Kategori> Kategorier { get; set; }
        public int? ValgtKategoriId { get; set; }

        //i config.cs og under appSettings i web.config
        //definerer statiske verdier - her relativ sti til bilder
        public string ImageUrlPrefix(int id)
        {
            var prefix = Config.BatturerImagesUrlPrefix;

            return prefix + id + ".jpg";
            //get { return Config.BatturerImagesUrlPrefix; }

        }
    }
}