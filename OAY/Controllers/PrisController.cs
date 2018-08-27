using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OAY.Data;
using OAY.Models;
using OAY.Web.ViewModels;

namespace OAY.Web.Controllers
{
    public class PrisController : Controller
    {
        private readonly ApplicationUnit _unit = new ApplicationUnit();

        public ActionResult PrisInfo(string seoName)
        {
            //Lager seo-vennlige linker
            var seo = "oslofjorden-battur";
            if (seoName != Config.SeoName(seo))
                return RedirectToActionPermanent("PrisInfo", new { seoName = Config.SeoName(seo) });

            var vm = new PrisInfoViewModel();

            var query = _unit.PrisInfo.GetAll();
            var pris = query.FirstOrDefault();
            if (pris != null)
            {
                vm.PrisInfo = new PrisInfo
                {
                    Timepris = pris.Timepris,
                    ImageFile = pris.ImageFile,
                    MinimumsTid = pris.MinimumsTid
                };
            }

            return View(vm);
        }

        public ActionResult EndrePrisInfo()
        {
            if (Session["IsAuthenticated"] == null) return Redirect("/Admin/Index");
            var query = _unit.PrisInfo.GetById(1);

            var vm = new PrisInfoViewModel
            {
                PrisInfo = new PrisInfo
                {
                    ImageFile = query.ImageFile,
                    Timepris = query.Timepris,
                    MinimumsTid = query.MinimumsTid
                }
            };

            return View(vm);
        }



        //[Authorize]
        public ActionResult SlettBilde(PrisInfo prisinfo)
        {
            if (Session["IsAuthenticated"] == null) return Redirect("/Admin/Index");
            JsonResult result;
          //  var path = Path.Combine(Server.MapPath(image.ImageFile));
            var path = Path.Combine(
                HttpContext.Server.MapPath(Config.PrisImagesFolderPath), prisinfo.ImageFile);
            var file = new FileInfo(path);

            if (file.Exists)
            {
                try
                {
                    using (StreamWriter sw = file.CreateText()) { }
                    file.Delete();
                    result = this.Json(new
                    {
                        status = "success"
                    });
                }
                catch (Exception e)
                {
                    result = this.Json(new
                    {
                        status = "error",
                        statusText = "Klarer ikke å slette fil fra folder " + e.Message
                    });
                }
            }
            else
            {
                result = this.Json(new
                {
                    status = "error",
                    statusText = "Finner ikke fil"
                });
            }
            return result;
        }



        //[Authorize]
        [HttpPost()]
        public ActionResult LastOppBilde(HttpPostedFileBase image, int id)
        {
            if (Session["IsAuthenticated"] == null) return Redirect("/Admin/Index");
            JsonResult result;
           // Bloggpost bloggpost;
            Random rand = new Random();

            string unique = rand.Next(1000000).ToString();
            string ext = Path.GetExtension(image.FileName).ToLower();
            string fileName = string.Format("{0}-{1}{2}", id, unique, ext);
            string path = Path.Combine(
                HttpContext.Server.MapPath(Config.BloggerImagesFolderPath), fileName);

            if (ext == ".png" || ext == ".jpg")
            {
       
                try
                {
                    image.SaveAs(path);
                    result = this.Json(new
                    {
                        imageUrl = string.Format("{0}{1}",
                        Config.PrisImagesFolderPath, fileName),
              
                    });
                }
                catch (Exception e)
                {
                    result = this.Json(new
                    {
                        status = "error",
                        statusText = "Klarer ikke å laste opp fil til folder " + e.Message
                    });
                }
            }
            else
            {
                result = this.Json(new
                {
                    status = "error",
                    statusText = "Godtar kun bilder av type: .jpg eller .png"
                });
            }

            return result;
        }

 


        protected override void Dispose(bool disposing)
        {
            this._unit.Dispose();
            base.Dispose(disposing);
        }
    }
}
