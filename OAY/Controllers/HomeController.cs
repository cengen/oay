using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;
using OAY.Data;
using OAY.Models;
using OAY.Web.ViewModels;

namespace OAY.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationUnit _unit = new ApplicationUnit();

        [ChildActionOnly]
        [ActionName("_MenyPartial")]
        public ActionResult Meny()
        {
            var batturer = this._unit.Batturer.GetAll().ToList();
            return PartialView("_MenyPartial", batturer);
        }


        public ActionResult Index(string seoName = "")
        {
           
            //Lager seo-vennlige linker
            var seo = "båttur-oslofjorden-oslo";
            if (seoName != Config.SeoName(seo))
                return RedirectToActionPermanent("Index", new { seoName = Config.SeoName(seo) });

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
            return View("Index", vm);
        }



        public ActionResult KontaktOss()
        {
            if (TempData["MailStatus"] != null)
            {
                ViewBag.Status = TempData["MailStatus"].ToString();
            }
            var mail = new Mail();
            return View("KontaktOss", mail);
        }


        [HttpPost]
        public ActionResult KontaktOss(Mail mail)
        {

            if (ModelState.IsValid)
            {                

                var mailMessage = new MailMessage();
                var smtp = new SmtpClient();

                //mailMessage.To.Add("firmapost@oceanadventureyachting.no");
                //mailMessage.From = new MailAddress("firmapost@oceanadventureyachting.no", "Ocean Adventure nettsiden");
                //mailMessage.Subject = mail.Emne;
                //mailMessage.Body = "Mail fra: " + mail.Fra + "<br />" + mail.Melding;
                //mailMessage.IsBodyHtml = true;
                //mailMessage.ReplyTo = new MailAddress(mail.Fra);
                //smtp.EnableSsl = true;
                //smtp.Host = "mail.fastname.no";
                //smtp.Port = 587;
                //smtp.UseDefaultCredentials = false;
                //smtp.Credentials = new System.Net.NetworkCredential("firmapost@oceanadventureyachting.no", "arild230269");


                ////Til testing: Bruke min egen epost konto. Mail videresendes fra oceanadventure-mailkonto til cengen@hotmail.no
                mailMessage.To.Add("cathrin@oceanadventureyachting.no");
                mailMessage.From = new MailAddress("cathrin@oceanadventureyachting.no", "Mail fra nettsiden");
                mailMessage.Subject = mail.Emne;
                mailMessage.Body = "Mail fra: " + mail.Fra + "<br />" + mail.Melding;
                mailMessage.IsBodyHtml = true;
                mailMessage.ReplyTo = new MailAddress(mail.Fra);
                smtp.EnableSsl = true;
                // Tidligere brukt:  smtp.Host = "smtp.live.com";
                smtp.Host = "mail.fastname.no";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("cathrin@oceanadventureyachting.no", "Bicpidit71");
                ////Til testing:  smtp.Credentials = new System.Net.NetworkCredential("cengen@hotmail.no", "Tor3dag27");



                try
                {
                    TempData["MailStatus"] = "Sent";
                    smtp.Send(mailMessage);
                    return RedirectToAction("KontaktOss");
                }
                catch (Exception ex)
                {
                    //ViewBag.Feilmelding = ex.Message + ex.InnerException + ex.StackTrace + ex.HelpLink + ex.Source;
                    ViewBag.Feilmelding = "Mailen ble ikke sendt. Vennligst prøv igjen";
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




