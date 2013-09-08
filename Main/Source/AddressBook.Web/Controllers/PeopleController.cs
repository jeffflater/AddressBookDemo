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
        public IEnumerable<Model.Entitites.People> Get()
        {
            var repository = new Data.Repositories.PeopleRepository();
            var people = repository.GetAll();
            return people;
        }
    }
}
