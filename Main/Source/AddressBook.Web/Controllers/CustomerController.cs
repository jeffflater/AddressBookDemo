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
        private static Data.Repositories.CustomerRepository repository = new Data.Repositories.CustomerRepository();

        public Model.Entitites.Customer Get(long Id)
        {
            return repository.GetById(Id);
        }

        public void Post(Model.Entitites.Customer customer)
        {
            repository.Save(customer);
        }
    }
}
