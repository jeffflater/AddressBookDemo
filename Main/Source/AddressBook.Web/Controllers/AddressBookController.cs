using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AddressBook.Web.Controllers
{
    public class AddressBookController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult PeoplePartialView()
        {
            return PartialView("PeopleView");
        }

        public ActionResult RelationshipPartialView()
        {
            return PartialView("RelationshipView");
        }

        public ActionResult PersonPartialView()
        {
            return PartialView("PersonView");
        }

    }

}
