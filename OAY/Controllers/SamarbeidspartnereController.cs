using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OAY.Data;
using OAY.Models;
using OAY.Web.ViewModels;

namespace OAY.Web.Controllers
{
    public class SamarbeidspartnereController : Controller
    {
//        private ApplicationUnit _unit = new ApplicationUnit();

//        //[ChildActionOnly]
//        [ActionName("_MenyPartnerePartial")]
//        public ActionResult MenyPartnere()
//        {
//            var partnere = this._unit.Samarbeidspartnere.GetAll().ToList();
//            return PartialView("_MenyPartnerePartial", partnere);
//        }




//        public ActionResult Samarbeidspartnere(string seoName = "")
//        {
//         //Lager seo-vennlige linker
//            var seo = "Båtturer-i-Oslofjorden-samarbeidspartner-";
//            if (seoName != Config.SeoName(seo))
//                return RedirectToActionPermanent("Samarbeidspartnere", new { seoName = Config.SeoName(seo) });

//            var vm = new SamarbeidspartnereListViewModel();

//            var query = this._unit.Samarbeidspartnere.GetAll();

//            if (query != null)
//            {
//                foreach (var samarbeidspartner in query)
//                {
//                    var bilder = this._unit.SamarbeidspartnerImages.GetBySamarbeidspartnerId(samarbeidspartner.SamarbeidspartnerId);
//                    if (bilder.Any())
//                    {
//                        var hovedbilde = this._unit.SamarbeidspartnerImages.GetHovedbilde(samarbeidspartner.SamarbeidspartnerId);
//                        if (hovedbilde != null)
//                        {
//                            samarbeidspartner.Logo = Config.SamarbeidspartnerImagesUrlPrefix + hovedbilde.ImageFile;
//                        }
//                        else
//                        {
//                            samarbeidspartner.Logo = bilder.First().ImageFile;
//                        }
//                    }
//                    else
//                    {
//                        samarbeidspartner.Logo = Config.ImagesUrlPrefix + "no-image-large.png";
//                    }
//                };

//                vm.Samarbeidspartnere = query.ToList();
//            }
//            return View(vm);
//        }

////        foreach (var partner in query)
////        {               
////            partner.SamarbeidspartnerImages
////                = this._unit.SamarbeidspartnerImages.GetBySamarbeidspartnerId(partner.SamarbeidspartnerId).ToList();
////    };

////    vm.Samarbeidspartnere = query.ToList();

////            return View(vm);
////}


//public ActionResult Samarbeidspartner(int id, string seoName = "")
//        {
//            var vm = new SamarbeidspartnerViewModel();
//            vm.Bilder = new List<SamarbeidspartnerImage>();
//            vm.ErNy = false;

//            vm.Samarbeidspartner = this._unit.Samarbeidspartnere.GetById(id);

//    if (vm.Samarbeidspartner != null)
//    {
//        int partnerid = vm.Samarbeidspartner.SamarbeidspartnerId;
//                var seo = "båttur-i-oslofjorden";
//                if (seoName != Config.SeoName(seo))
//            return RedirectToActionPermanent("Samarbeidspartner", new { id = id, seoName = Config.SeoName(seo) });



//        return View("Samarbeidspartner", vm);
//    }

//    return View("Error");
//}


//        //[Authorize]
//        public ActionResult NySamarbeidspartner()
//        {
//            var vm = new SamarbeidspartnerViewModel();
//            vm.ErNy = true;
//            vm.Samarbeidspartner = new Samarbeidspartner();
//          //  vm.Samarbeidspartnere = new List<Samarbeidspartner>();
//            vm.Samarbeidspartner.SamarbeidspartnerImages = new List<SamarbeidspartnerImage>();
//            vm.Samarbeidspartner.Logo = "";

//            return View("EndreSamarbeidspartner", vm);
//        }


//        [Authorize]
//        public ActionResult EndreSamarbeidspartner(int id = -1)
//        {
//            var vm = new SamarbeidspartnerViewModel();

//            if (id > -1)
//            {
//                vm.ErNy = false;
//                vm.Samarbeidspartner = this._unit.Samarbeidspartnere.GetById(id);

//                if (vm.Samarbeidspartner != null)
//                {
//                    int partnerid = vm.Samarbeidspartner.SamarbeidspartnerId;
//                    vm.Bilder = new List<SamarbeidspartnerImage>();
//                    var tempImages = this._unit.SamarbeidspartnerImages.GetBySamarbeidspartnerId(partnerid);

//                    foreach (var temp in tempImages)
//                    {
//                        var image = new SamarbeidspartnerImage
//                        {
//                            ImageFile = Config.SamarbeidspartnerImagesUrlPrefix + temp.ImageFile,
//                            SamarbeidspartnerImageId = temp.SamarbeidspartnerImageId,
//                            SamarbeidspartnerId = temp.SamarbeidspartnerId,
//                            ErHovedbilde = temp.ErHovedbilde
//                        };
//                        vm.Bilder.Add(image);

//                        if (temp.ErHovedbilde)
//                        {
//                            vm.Hovedbilde = image.SamarbeidspartnerImageId.ToString();
//                        }
//                    }


//                }
//                return View("EndreSamarbeidspartner", vm);
//            }
//            return View("Error");
//        }


//        [Authorize]
//        public ActionResult SlettBilde(SamarbeidspartnerImage image)
//        {
//            JsonResult result;

//            var path = Path.Combine(Server.MapPath(image.ImageFile));
//            var file = new FileInfo(path);

//            if (file.Exists)//check file exsit or not
//            {
//                try
//                {
//                    using (StreamWriter sw = file.CreateText()) { }
//                    file.Delete();
//                    result = this.Json(new
//                    {
//                        status = "success"
//                    });
//                    // Console.WriteLine("fant fil: {0} .", file);
//                }
//                catch (Exception e)
//                {
//                    result = this.Json(new
//                    {
//                        status = "error",
//                        statusText = "Klarer ikke å slette fil fra folder " + e.Message
//                    });
//                }
//            }
//            else
//            {
//                result = this.Json(new
//                {
//                    status = "error",
//                    statusText = "Finner ikke fil"
//                });
//            }
//            return result;
//        }


//        //Kunne også vært lagt inn i apiController - men mer komplisert
//        //[Authorize]
//        [HttpPost()]
//        public ActionResult LastOppBilde(HttpPostedFileBase image, int id, bool erhovedbilde)
//        {

//            JsonResult result;
//            Samarbeidspartner samarbeidspartner;
//            Random rand = new Random();
//            string unique;
//            string ext;
//            string fileName;
//            string path;

//            unique = rand.Next(1000000).ToString();

//            ext = Path.GetExtension(image.FileName).ToLower();

//            fileName = string.Format("{0}-{1}{2}", id, unique, ext);

//            path = Path.Combine(
//                HttpContext.Server.MapPath(Config.SamarbeidspartnerImagesFolderPath), fileName);

//            if (ext == ".png" || ext == ".jpg")
//            {
//                samarbeidspartner = _unit.Samarbeidspartnere.GetById(id);

//                try
//                {
//                    image.SaveAs(path);
//                    result = this.Json(new
//                    {
//                        imageUrl = string.Format("{0}{1}",
//                        Config.ImagesUrlPrefix, fileName),
//                        erHovedbilde = erhovedbilde
//                    });
//                }
//                catch (Exception e)
//                {
//                    result = this.Json(new
//                    {
//                        status = "error",
//                        statusText = "Klarer ikke å laste opp fil til folder " + e.Message
//                    });
//                }
//            }
//            else
//            {
//                result = this.Json(new
//                {
//                    status = "error",
//                    statusText = "Godtar kun bilder av type: .jpg eller .png"
//                });
//            }
//            return result;
//        }

//        protected override void Dispose(bool disposing)
//        {
//            this._unit.Dispose();
//            base.Dispose(disposing);
//        }
    }
}