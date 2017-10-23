using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOOKRESERVATION.Models;
using BOOKRESERVATION.Utils;

namespace BOOKRESERVATION.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index(string search = "")
        {
            if (search != "")
            {
                return View(AccountsUtils.GetAccounts().Where(x => x.Name == search || x.Username == search || x.Address == search));
            }
            return View(AccountsUtils.GetAccounts());
        }

        public ActionResult Add(Account acc)
        {
            if (acc.Name != null)
            {
                AccountsUtils.Save(acc);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(Account acc)
        {
            return View(AccountsUtils.GetAccounts(acc.Id).FirstOrDefault());
        }
        public ActionResult Delete(int id)
        {
            AccountsUtils.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ViewAccounts()
        {
            return View(AccountsUtils.GetAccounts());
        }
        public ActionResult UserHome()
        {
            return View("UserHome");
        }
 

        public ActionResult ReserveBooks(string search = "")
        {
            if (search != "")
            {
                return View(BooksUtils.GetBooks().Where(x => x.BookTitle == search || x.Author == search));
            }

            return View(BooksUtils.GetBooks());
        }
       
    }

}
