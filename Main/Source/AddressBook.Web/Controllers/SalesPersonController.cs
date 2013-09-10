using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AddressBook.Web.Controllers
{
    public class SalesPersonController : ApiController
    {
        Data.Repositories.SalesPersonRepository repository = new Data.Repositories.SalesPersonRepository();

        public Model.Entitites.SalesPerson Get(long Id)
        {
            return repository.GetById(Id);
        }

        public void Post(Model.Entitites.SalesPerson salesPerson)
        {
            repository.Save(salesPerson);
        }

        public void Delete(long Id)
        {
            repository.Delete(Id);
        }
    }
}
