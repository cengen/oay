using System;
using OAY.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;
using OAY.Data;
using OAY.Web.ViewModels;

namespace OAY.Web.Controllers
{
    public class EngelskController : Controller
    {
        private readonly ApplicationUnit _unit = new ApplicationUnit();

        [ChildActionOnly]
        [ActionName("_MenyPartialEngelsk")]
        public ActionResult Meny()
        {
            var batturer = this._unit.Batturer.GetAll().ToList();
            return PartialView("_MenyPartialEngelsk", batturer);
        }

        public ActionResult IndexEngelsk(string seoName = "")
        {
            //Lager seo-vennlige linker
            var seo = "sightseeing-oslofjorden-oslo";
            if (seoName != Config.SeoName(seo))
                return RedirectToActionPermanent("IndexEngelsk", new { seoName = Config.SeoName(seo) });

            var vm = new BatturerListViewModel();
            var query = this._unit.Batturer.GetAll();
            vm.Batturer = new List<Battur>();

            foreach (var battur in query)
            {
                var hovedbilde = this._unit.BatturImages.GetHovedbilde(battur.BatturId);
                if (hovedbilde != null)
                {
                    battur.Hovedbilde = hovedbilde.ImageFile;
                }
            };
            vm.Batturer = query.ToList();
            return View("IndexEngelsk", vm);
        }


        public ActionResult BatturEngelsk(int id, string seoName)
        {
            var vm = new BatturViewModel();
            vm.ErNy = false;
            var batturer = this._unit.Batturer.GetAll().ToList();
            vm.Batturer = batturer;

            vm.Battur = this._unit.Batturer.GetById(id);

            if (vm.Battur != null)
            {
                int batturid = vm.Battur.BatturId;

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

                vm.Pris = (Config.Timepris * vm.Battur.MinimumTid).ToString();


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
                var seo = "sightseeing-in-oslofjorden-Oslo-to-" + vm.Battur.TilSted;
                if (seoName != Config.SeoName(seo))
                    return RedirectToActionPermanent("BatturEngelsk", new { id = id, seoName = Config.SeoName(seo) });

                return View("BatturEngelsk", vm);
            }

            return View("Error");

        }


        public ActionResult MenyEngelsk(string seoName)
        {
            //Lager seo-vennlige linker
            var seo = "dinnercruise-in-oslofjord";
            if (seoName != Config.SeoName(seo))
                return RedirectToActionPermanent("MenyEngelsk", new { seoName = Config.SeoName(seo) });


            var vm = new MenyListeViewModel();
            vm.AperitiffListe = new List<Meny>();
            vm.DessertListe = new List<Meny>();
            vm.DiverseListe = new List<Meny>();
            vm.ForrettListe = new List<Meny>(); ;
            vm.HovedrettListe = new List<Meny>();
            vm.HvitvinListe = new List<Meny>();
            vm.LikorListe = new List<Meny>();
            vm.RodvinListe = new List<Meny>();

            var menyListe = this._unit.Menyer.GetAll();


            if (menyListe != null)
            {
                foreach (var meny in menyListe)
                {
                    if (meny.Type == "Forrett")
                    {
                        vm.ForrettListe.Add(meny);
                    }
                    else if (meny.Type == "Hovedrett")
                    {
                        vm.HovedrettListe.Add(meny);
                    }
                    else if (meny.Type == "Dessert")
                    {
                        vm.DessertListe.Add(meny);
                    }
                    else if (meny.Type == "Rodvin")
                    {
                        vm.RodvinListe.Add(meny);
                    }
                    else if (meny.Type == "Hvitvin")
                    {
                        vm.HvitvinListe.Add(meny);
                    }
                    else if (meny.Type == "Likor")
                    {
                        vm.LikorListe.Add(meny);
                    }
                    else if (meny.Type == "Aperitiff")
                    {
                        vm.AperitiffListe.Add(meny);
                    }
                    else
                    {
                        vm.DiverseListe.Add(meny);
                    }
                }
            }

            return View("MenyEngelsk", vm);
        }


        public ActionResult PrisInfoEngelsk(string seoName)
        {
            
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

            return View("PrisInfoEngelsk", vm);
        }

        public ActionResult BildegalleriEngelsk(string seoName)
        {
            //Lager seo-vennlige linker
            //var seo = "nyheter-fra-oslofjorden-og-Ocean-Adventure";
            //if (seoName != Config.SeoName(seo))
            //    return RedirectToActionPermanent("BildegalleriEngelsk", new { seoName = Config.SeoName(seo) });

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
                    Ingress = query.IngressEngelsk,
                    Tekst1 = query.Tekst1Engelsk,
                    Tekst2 = query.Tekst2Engelsk,
                    Tekst3 = query.Tekst3Engelsk,
                    Tekst4 = query.Tekst4Engelsk,
                    Tekst5 = query.Tekst5Engelsk,
                    Beskrivelse = query.BeskrivelseEngelsk,
                    Tittel = query.TittelEngelsk
                };
            }

            return View("BildegalleriEngelsk", vm);
        }


        public ActionResult ContactUs()
        {
            if (TempData["MailStatus"] != null)
            {
                ViewBag.Status = TempData["MailStatus"].ToString();
            }
            var mail = new Mail();
            return View("ContactUs", mail);
        }

        [HttpPost]
        public ActionResult ContactUs(Mail mail)
        {
            if (ModelState.IsValid)
            {
                var mailMessage = new MailMessage();
                var smtp = new SmtpClient();

                mailMessage.To.Add("firmapost@oceanadventureyachting.no");
                mailMessage.From = new MailAddress("firmapost@oceanadventureyachting.no", "Ocean Adventure nettsiden");
                mailMessage.Subject = mail.Emne;
                mailMessage.Body = "Mail fra: " + mail.Fra + "<br />" + mail.Melding;
                mailMessage.IsBodyHtml = true;
                mailMessage.ReplyTo = new MailAddress(mail.Fra);
                smtp.EnableSsl = true;
                smtp.Host = "mail.fastname.no";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("firmapost@oceanadventureyachting.no", "arild230269");


                ////Til testing: Bruke min egen epost konto. Mail videresendes fra oceanadventure-mailkonto til cengen@hotmail.no
                //mailMessage.To.Add("cathrin@oceanadventureyachting.no");
                //mailMessage.From = new MailAddress("cathrin@oceanadventureyachting.no", "Mail fra nettsiden");
                //mailMessage.Subject = mail.Emne;
                //mailMessage.Body = "Mail fra: " + mail.Fra + "<br />" + mail.Melding;
                //mailMessage.IsBodyHtml = true;
                //mailMessage.ReplyTo = new MailAddress(mail.Fra);
                //smtp.EnableSsl = true;
                //// Tidligere brukt:  smtp.Host = "smtp.live.com";
                //smtp.Host = "mail.fastname.no";
                //smtp.Port = 587;
                //smtp.UseDefaultCredentials = false;
                //smtp.Credentials = new System.Net.NetworkCredential("cathrin@oceanadventureyachting.no", "Bicpidit71");
                ////Til testing:  smtp.Credentials = new System.Net.NetworkCredential("cengen@hotmail.no", "Tor3dag27");


                try
                {
                    TempData["MailStatus"] = "Sent";
                    smtp.Send(mailMessage);
                    return RedirectToAction("ContactUs");
                }
                catch (Exception ex)
                {
                    //ViewBag.Feilmelding = ex.Message + ex.InnerException + ex.StackTrace + ex.HelpLink + ex.Source;
                    ViewBag.Feilmelding = "The mail was not sent. Please try again";
                    ViewBag.Status = "Feil";
                    return View();
                }
            }
            else
            {
                ViewBag.Status = "Feil";
                return View();
            }
        }

        public ActionResult Error()
        {
            return View();
        }



    }
}
