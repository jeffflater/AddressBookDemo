using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AddressBook.Web.Controllers
{
    public class PeopleController : ApiController
    {
        private static Data.Repositories.PeopleRepository repository = new Data.Repositories.PeopleRepository();

        public IEnumerable<Model.Entitites.People> Get()
        {
            return repository.GetAll();
        }
    }
}
