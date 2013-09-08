using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AddressBook.Web.Controllers
{
    public class CustomerController : ApiController
    {
        public Model.Entitites.Customer Get(long Id)
        {
            var repository = new Data.Repositories.CustomerRepository();
            var customer = repository.GetById(Id);
            return customer;
        }
    }
}
