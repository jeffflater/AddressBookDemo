using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AddressBook.Web.Controllers
{
    public class EmployeeController : ApiController
    {
        private static Data.Repositories.EmployeeRepository repository = new Data.Repositories.EmployeeRepository();

        public Model.Entitites.Employee Get(long Id)
        {
            return repository.GetById(Id);
        }

        public void Post(Model.Entitites.Employee employee)
        {
            repository.Save(employee);
        }
    }
}
