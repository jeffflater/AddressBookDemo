using System.Collections.Generic;
using System.Web.Http;
using AddressBook.Data.Repositories;
using AddressBook.Model.DTO;
using AddressBook.Model.Entitites;
using AutoMapper;

namespace AddressBook.Web.Controllers
{
    public class PeopleController : ApiController
    {
        private static readonly CustomerRepository CustomerRepository = new CustomerRepository();
        private static readonly EmployeeRepository EmployeeRepository = new EmployeeRepository();
        private static readonly ManagerRepository ManagerRepository = new ManagerRepository();
        private static readonly SalesPersonRepository SalesPersonRepository = new SalesPersonRepository();

        public IEnumerable<PersonDto> Get()
        {
            var people = new List<PersonDto>();

            var customers = Mapper.DynamicMap<IEnumerable<Customer>, List<PersonDto>>(CustomerRepository.GetAll());
            people.AddRange(customers);

            var employees = Mapper.DynamicMap<IEnumerable<Employee>, List<PersonDto>>(EmployeeRepository.GetAll());
            people.AddRange(employees);

            var managers = Mapper.DynamicMap<IEnumerable<Manager>, List<PersonDto>>(ManagerRepository.GetAll());
            people.AddRange(managers);

            var salesPeople = Mapper.DynamicMap<IEnumerable<SalesPerson>, List<PersonDto>>(SalesPersonRepository.GetAll());
            people.AddRange(salesPeople);

            return people;
        }
    }
}