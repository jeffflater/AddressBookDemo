using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AddressBook.Web.Controllers
{
    public class ManagerController : ApiController
    {
        public Model.Entitites.Manager Get(long Id)
        {
            var repository = new Data.Repositories.ManagerRepository();
            var manager = repository.GetById(Id);
            return manager;
        }
    }
}
