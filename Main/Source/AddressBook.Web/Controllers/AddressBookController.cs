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

        public ActionResult PeopleList()
        {
            return PartialView("PeopleView");
        }

        public ActionResult RelationshipList()
        {
            var repository = new Data.Repositories.RelationshipRepository();
            var relationships = repository.GetAll(1);

            return PartialView("RelationshipView", relationships);
        }

        public ActionResult PersonDetail()
        {
            return PartialView("PersonView");
        }

    }

}
