
using OAY.Models;

namespace OAY.Web.ViewModels
{
    public class PrisInfoViewModel
    {
        public PrisInfo PrisInfo { get; set; }

        public string ImagePath
        {
            get { return Config.PrisInfoImagesUrlPrefix + PrisInfo.ImageFile; }
        }
    }
}
