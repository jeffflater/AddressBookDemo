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
            return repository.GetById(Id);
        }

        public void Post(Model.Entitites.Manager manager)
        {
            repository.Save(manager);
        }

        public void Delete(long Id)
        {
            repository.Delete(Id);
        }
    }
}
