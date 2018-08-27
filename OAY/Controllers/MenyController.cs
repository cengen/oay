using System.Linq;
using System.Web.Mvc;
using OAY.Data;
using OAY.Models;
using OAY.Web.ViewModels;
using System.Collections.Generic;


namespace OAY.Web.Controllers
{
    public class MenyController : Controller
    {
        private readonly ApplicationUnit _unit = new ApplicationUnit();

        public ActionResult Meny(string seoName)
        {
            //Lager seo-vennlige linker
            var seo = "båtcruise-i-oslofjorden-med-alle-rettigheter-ombord";
            if (seoName != Config.SeoName(seo))
                return RedirectToActionPermanent("Meny", new { seoName = Config.SeoName(seo) });


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


            if(menyListe != null){
                foreach (var meny in menyListe)
                {
                    if (meny.Type == "Forrett") {
                        vm.ForrettListe.Add(meny);
                    }
                    else if (meny.Type == "Hovedrett"){
                        vm.HovedrettListe.Add(meny);
                    }
                    else if (meny.Type == "Dessert"){
                        vm.DessertListe.Add(meny);
                    }
                    else if (meny.Type == "Rodvin"){
                        vm.RodvinListe.Add(meny);
                    }
                    else if (meny.Type == "Hvitvin"){
                        vm.HvitvinListe.Add(meny);
                    }
                    else if (meny.Type == "Likor"){
                        vm.LikorListe.Add(meny);
                    }
                    else if (meny.Type == "Aperitiff"){
                        vm.AperitiffListe.Add(meny);
                    }
                    else {
                        vm.DiverseListe.Add(meny);
                    }
                }
            }


           
            
            return View(vm);
        }


        //[Authorize]
        public ActionResult EndreMeny()
        {
            if (Session["IsAuthenticated"] == null) return Redirect("/Admin/Index");
            var vm = new MenyViewModel();
           vm.Meny = new Meny();
           vm.MenyListe = this._unit.Menyer.GetAll().ToList();
           

           return View("EndreMeny", vm);
         
        }




        protected override void Dispose(bool disposing)
        {
            this._unit.Dispose();
            base.Dispose(disposing);
        }
    }
}
