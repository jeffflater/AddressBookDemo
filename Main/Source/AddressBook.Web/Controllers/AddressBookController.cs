﻿using System.Web.Mvc;

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

        public ActionResult PersonPartialView()
        {
            return PartialView("PersonView");
        }
    }
}