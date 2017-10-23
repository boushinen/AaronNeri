using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOOKRESERVATION.Models;
using BOOKRESERVATION.Utils;

namespace BOOKRESERVATION.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index(string username, string password)
        {
            if (AccountsUtils.ValidAccountNamePassword(username, password))
            {
                return RedirectToAction("UserHome","Admin");
            }
            if (username == "Admin" || username == "admin" && password == "Admin" ||  password == "admin")
            {
                return RedirectToAction("Homepage", "Home");
            }

            
            if (password != null && username != null)
            {
                ViewBag.Error = "Error message";
                return RedirectToAction("Index");

            }

            return View("Index");
        }

        public ActionResult Homepage()
        {
            return View();
        }

    }
}
