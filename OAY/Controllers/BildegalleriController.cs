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
    public class BildegalleriController : Controller
    {
        readonly ApplicationUnit _unit = new ApplicationUnit();

        public ActionResult Bildegalleri(string seoName)
        {
            //Lager seo-vennlige linker
            var seo = "nyheter-fra-oslofjorden-og-Ocean-Adventure";
            if (seoName != Config.SeoName(seo))
                return RedirectToActionPermanent("Bildegalleri", new { seoName = Config.SeoName(seo) });

            var query = _unit.Bildegallerier.GetById(1);

            var vm = new BildegalleriViewModel();
            vm.Bilder = new List<BildegalleriImage>();

            var tempImages = _unit.BildegalleriImages.GetAll().ToList();
           
            foreach (var temp in tempImages)
            {
                var image = new BildegalleriImage
                {
                    ImageFile = Config.BildegalleriImagesFolderPath + temp.ImageFile + ".jpg",
                    ErHovedbilde = temp.ErHovedbilde
                };
                vm.Bilder.Add(image);

                if (temp.ErHovedbilde)
                {
                    vm.Hovedbilde = Config.BildegalleriImagesFolderPath + temp.ImageFile + ".jpg";
                }
            };


            if (query != null)
            {
                vm.Bildegalleri = new Bildegalleri
                {
                    Type = query.Type,
                    Model = query.Model,
                    Ingress = query.Ingress,
                    Tekst1 = query.Tekst1,
                    Tekst2 = query.Tekst2,
                    Tekst3 = query.Tekst3,
                    Tekst4 = query.Tekst4,
                    Tekst5 = query.Tekst5,
                    Beskrivelse = query.Beskrivelse,
                    Tittel = query.Tittel
                };
            }




            //foreach (var bilde in query)
            //{
            //    var svar = this._unit.Bloggsvar.GetByBloggpostId(blogg.BloggpostId);
            //    blogg.BloggsvarListe = svar.ToList();


            //{ "1.JPG" },{"ImageFile : 2.JPG" }]
            //this._unit.BloggImages.GetByBloggpostId(blogg.BloggpostId).ToList();}

            ////};

            //vm.Bloggposter = query.ToList();
            //vm.Bloggsvar = new Bloggsvar();

            //vm.HvaSkjerListe = this._unit.HvaSkjer.GetAll().ToList(); 

            // vm.IsAuthenticated = true;




            return View(vm);
        }

        public ActionResult EndreBildegalleri()
        {
            
            var vm = new BildegalleriViewModel();
            //vm.Bloggposter = new List<Bloggpost>();

           // var query = this._unit.Bildegallerier.GetAll();

            //foreach (var bilde in query)
            //{
            //    var svar = this._unit.Bloggsvar.GetByBloggpostId(blogg.BloggpostId);
            //    blogg.BloggsvarListe = svar.ToList();

            //    blogg.BloggimageListe = this._unit.BloggImages.GetByBloggpostId(blogg.BloggpostId).ToList();

            //};

            //vm.Bloggposter = query.ToList();
            //vm.Bloggsvar = new Bloggsvar();

            //vm.HvaSkjerListe = this._unit.HvaSkjer.GetAll().ToList(); 

            // vm.IsAuthenticated = true;



            return View(vm);
        }

   //[Authorize]
        public ActionResult SlettBilde(BloggImage image)
        {
            JsonResult result;
          //  var path = Path.Combine(Server.MapPath(image.ImageFile));
            var path = Path.Combine(
                HttpContext.Server.MapPath(Config.BloggerImagesFolderPath), image.ImageFile);
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
                //bloggpost = _unit.Bloggposter.GetById(id);
                try
                {
                    image.SaveAs(path);
                    result = this.Json(new
                    {
                        imageUrl = string.Format("{0}{1}",
                        Config.BloggpostImagesUrlPrefix, fileName),
              
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
