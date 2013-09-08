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
        public Model.Entitites.SalesPerson Get(long Id)
        {
            var repository = new Data.Repositories.SalesPersonRepository();
            var salesPerson = repository.GetById(Id);
            return salesPerson;
        }
    }
}
