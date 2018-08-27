using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OA.Web.Models;
using OAY.Data;

namespace OAY.Web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index(string returnUrl)
        {
            if (Session["IsAuthenticated"] != null)
            {
                return View("AdminMenu");
            }
            else
            {
                return View("Login");
            }

                
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
               
                if ( (model.UserName == "Admin")  && (model.Password == "Admin123" ))
                {
                    Session["IsAuthenticated"] = "true";
                   
                }
            }
            return RedirectToAction("Index");
        }

    }
}