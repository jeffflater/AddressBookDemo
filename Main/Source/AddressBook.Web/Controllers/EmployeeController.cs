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
        public Model.Entitites.Employee Get(long Id)
        {
            var repository = new Data.Repositories.EmployeeRepository();
            var employee = repository.GetById(Id);
            return employee;
        }
    }
}
