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
        public IEnumerable<Model.DTO.PersonDto> Get()
        {
            var people = new List<Model.DTO.PersonDto>();

            var customerRepository = new Data.Repositories.CustomerRepository();
            var customers = AutoMapper.Mapper.DynamicMap<IEnumerable<Model.Entitites.Customer>, List<Model.DTO.PersonDto>>(customerRepository.GetAll());
            people.AddRange(customers);

            var employeeRepository = new Data.Repositories.EmployeeRepository();
            var employees = AutoMapper.Mapper.DynamicMap<IEnumerable<Model.Entitites.Employee>, List<Model.DTO.PersonDto>>(employeeRepository.GetAll());
            people.AddRange(employees);

            var managerRepository = new Data.Repositories.ManagerRepository();
            var managers = AutoMapper.Mapper.DynamicMap<IEnumerable<Model.Entitites.Manager>, List<Model.DTO.PersonDto>>(managerRepository.GetAll());
            people.AddRange(managers);

            var salesPersonRepository = new Data.Repositories.SalesPersonRepository();
            var salesPeople = AutoMapper.Mapper.DynamicMap<IEnumerable<Model.Entitites.SalesPerson>, List<Model.DTO.PersonDto>>(salesPersonRepository.GetAll());
            people.AddRange(salesPeople);

            return people;
        }
    }
}
