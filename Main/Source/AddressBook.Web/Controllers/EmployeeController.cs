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

        public Model.DTO.EmployeeDto Get(long Id)
        {
            var employee = AutoMapper.Mapper.DynamicMap<Model.Entitites.Employee, Model.DTO.EmployeeDto>(repository.GetById(Id));

            return employee;
        }

        public void Post(Model.Entitites.Employee employee)
        {
            repository.Save(employee);
        }

        public void Delete(long Id)
        {
            repository.Delete(Id);
        }

    }
}
