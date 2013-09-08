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
        Data.Repositories.ManagerRepository repository = new Data.Repositories.ManagerRepository();

        public Model.Entitites.Manager Get(long Id)
        {
            var manager = repository.GetById(Id);
            return manager;
        }

        public void Post(Model.Entitites.Manager manager)
        {
            repository.Save(manager);
        }
    }
}
