using System;
using System.IO;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using OAY.Data;
using OAY.Models;
using OAY.Web.ViewModels;
using System.Collections.Generic;

namespace OAY.Web.Controllers
{

    public class BatturerController : Controller
    {
        private ApplicationUnit _unit = new ApplicationUnit();


        public ActionResult Batturer(int? kategoriId, string seoName = "")
        {
            //Lager seo-vennlige linker
            var seo = "båttur-i-oslofjorden-sommerfest-båttransport";
            if (seoName != Config.SeoName(seo))
                return RedirectToActionPermanent("Batturer", new { seoName = Config.SeoName(seo) });

            var vm = new BatturerListViewModel();
  
            var query = this._unit.Batturer.GetAll();

            if (query != null)
            {
                foreach (var battur in query)
                {
                    var harBilder = this._unit.BatturImages.GetByBatturId(battur.BatturId);
                    if (harBilder.Any())
                    {
                        var hovedbilde = this._unit.BatturImages.GetHovedbilde(battur.BatturId);
                        if (hovedbilde != null)
                        {
                            battur.Hovedbilde = Config.BatturerImagesUrlPrefix + hovedbilde.ImageFile;
                        }
                        else
                        {
                            battur.Hovedbilde = harBilder.First().ImageFile;
                        }
                    }
                    else
                    {
                        battur.Hovedbilde = Config.BatturerImagesUrlPrefix + "no-image-large.png";
                    }


                    battur.BatturKategorier = this._unit.BatturKategorier.GetByBatturId(battur.BatturId);
                };

                vm.Batturer = query.ToList();
            }
            return View(vm);
        }


        public ActionResult Battur(int id, string seoName)
        {
            var vm = new BatturViewModel();
            vm.ErNy = false;
            var batturer = this._unit.Batturer.GetAll().ToList();
            vm.Batturer = batturer;
            vm.Kategorier = this._unit.Kategorier.GetAll().ToList();

            vm.Battur = this._unit.Batturer.GetById(id);

            if (vm.Battur != null)
            {
                int batturid = vm.Battur.BatturId;

                var batturKategorier = this._unit.BatturKategorier.GetByBatturId(batturid);

                foreach (var batKat in batturKategorier)
                {
                    var kategori = this._unit.Kategorier.GetById(batKat.KategoriId);
                    vm.Kategorier.Add(kategori);
                }

                vm.Bilder = new List<BatturImage>();

                var tempImages = this._unit.BatturImages.GetByBatturId(batturid);

                foreach (var temp in tempImages)
                {
                    var image = new BatturImage
                    {
                        ImageFile = Config.BatturerImagesUrlPrefix + temp.ImageFile,
                        ImageId = temp.ImageId,
                        BatturId = temp.BatturId,
                        ErHovedbilde = temp.ErHovedbilde
                    };
                    vm.Bilder.Add(image);

                    if (temp.ErHovedbilde)
                    {
                        vm.Hovedbilde = Config.BatturerImagesFolderPath + temp.ImageFile;
                    }
                };

                var neste = 0;
                var forrige = 0;

                if (batturer.Count > 1)
                {
                    var index = batturer.IndexOf(vm.Battur);

                    if (index == (batturer.Count - 1))
                    {
                        neste = 0;
                    }
                    else
                    {
                        neste = index + 1;
                    }

                    if (index == 0)
                    {
                        forrige = batturer.Count - 1;
                    }
                    else
                    {
                        forrige = index - 1;
                    }
                }
                else
                {
                    neste = batturid;
                    forrige = batturid;
                }

                vm.NesteBattur = batturer.ElementAt(neste).BatturId;
                vm.ForrigeBattur = batturer.ElementAt(forrige).BatturId;


                //Lager seo-vennlige linker
                //var seo = vm.Kategorier[0].KategoriNavn + "-båttur-i-oslofjorden-" + vm.Battur.TilSted;
                var seo = "båttur-oslo-" + vm.Battur.TilSted;
                if (seoName != Config.SeoName(seo))
                    return RedirectToActionPermanent("Battur", new { id = id, seoName = Config.SeoName(seo) });


                return View("Battur", vm);
            }

            return View("Error");


            //foreach (var m in valgtBattur.BatturKategorier)
            //{
            //    var q = this._unit.Kategorier.GetById(m.KategoriID);
            //    kat.Add(q);
            //};

        }


          //[Authorize]
        public ActionResult BatturerSomKanEndres()
        {
            if (Session["IsAuthenticated"] == null) return Redirect("/Admin/Index");
            var vm = new BatturerListViewModel();

            vm.Batturer = this._unit.Batturer.GetAll().ToList();

            return View(vm);
        }


        //[Authorize]
        public ActionResult NyBattur()
        {
            if (Session["IsAuthenticated"] == null) return Redirect("/Admin/Index");
            var vm = new BatturViewModel();
            vm.ErNy = true;
            vm.Battur = new Battur();
            vm.Batturer = new List<Battur>();
            vm.Battur.Kategorier = new List<Kategori>();
            vm.Hovedbilde = "";

            return View("EndreBattur", vm);
        }


        //[Authorize]
        [ActionName("EndreBattur")]
        public ActionResult Get(int id = -1)
        {
            if (Session["IsAuthenticated"] == null) return Redirect("/Admin/Index");
            var vm = new BatturViewModel();

            if (id > -1)
            {
                vm.ErNy = false;
                vm.Battur = this._unit.Batturer.GetById(id);
                vm.Kategorier = new List<Kategori>();


                if (vm.Battur != null)
                {

                    int batturid = vm.Battur.BatturId;

                    if (vm.Battur.Kategorier != null)
                    {
                        foreach (var bk in vm.Battur.Kategorier)
                        {
                            var kategori = this._unit.Kategorier.GetById(bk.KategoriId);
                            if (kategori != null)
                            {
                                vm.Kategorier.Add((Kategori)kategori);
                            }
                        }
                    }

                    vm.Bilder = new List<BatturImage>();
                    var tempImages = this._unit.BatturImages.GetByBatturId(batturid);

                    foreach (var temp in tempImages)
                    {
                        var image = new BatturImage
                        {
                            ImageFile = Config.BatturerImagesUrlPrefix + temp.ImageFile,
                            ImageId = temp.ImageId,
                            BatturId = temp.BatturId,
                            ErHovedbilde = temp.ErHovedbilde
                        };
                        vm.Bilder.Add(image);

                        if (temp.ErHovedbilde)
                        {
                            vm.Hovedbilde = image.ImageId.ToString();
                        }
                    };
                    vm.Battur.Beskrivelse = vm.Battur.Beskrivelse.Replace("\n", "");
                }
                return View("EndreBattur", vm);
            }
            return View("Error");
        }


        //[Authorize]
        public ActionResult SlettBilde(BatturImage image)
        {
            if (Session["IsAuthenticated"] == null) return Redirect("/Admin/Index");
            JsonResult result;

            var path = Path.Combine(Server.MapPath(image.ImageFile));
            var file = new FileInfo(path);

            if (file.Exists)//check file exsit or not
            {
                try
                {
                    using (StreamWriter sw = file.CreateText()) { }
                    file.Delete();
                    result = this.Json(new
                    {
                        status = "success"
                    });
                    // Console.WriteLine("fant fil: {0} .", file);
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


        //Kunne også vært lagt inn i apiController - men mer komplisert
        //[Authorize]
        [HttpPost()]
        public ActionResult LastOppBilde(HttpPostedFileBase image, int id, bool erhovedbilde)
        {
            if (Session["IsAuthenticated"] == null) return Redirect("/Admin/Index");
            JsonResult result;
            Battur battur;
            Random rand = new Random();
            string unique;
            string ext;
            string fileName;
            string path;

            unique = rand.Next(1000000).ToString();

            ext = Path.GetExtension(image.FileName).ToLower();

            fileName = string.Format("{0}-{1}{2}", id, unique, ext);

            path = Path.Combine(
                HttpContext.Server.MapPath(Config.BatturerImagesFolderPath), fileName);

            if (ext == ".png" || ext == ".jpg")
            {
                battur = _unit.Batturer.GetById(id);

                //if (battur != null)
                //{
                //    battur.ImageName = fileName;
                //    _unit.Batturer.Update(battur);
                //    _unit.SaveChanges();
                try
                {

                    image.SaveAs(path);
                    //  lagreThumbnail(image, path);
                    result = this.Json(new
                    {
                        imageUrl = string.Format("{0}{1}",
                        Config.ImagesUrlPrefix, fileName),
                        erHovedbilde = erhovedbilde


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
                //}
                //else
                //{
                //    result = this.Json(new
                //    {
                //        status = "error",
                //        statusText =
                //        string.Format("Det fins ingen båttur med id '{0}' i systemet ", id)
                //    });
                //}
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








