using System;
using System.Web.Mvc;

namespace AddressBook.Web.Controllers
{
    public class JasmineController : Controller
    {
        public ViewResult Run()
        {
            return View("SpecRunner");
        }
    }
}
