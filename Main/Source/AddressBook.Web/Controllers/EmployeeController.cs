using System.Web.Http;
using AddressBook.Data.Repositories;
using AddressBook.Model.DTO;
using AddressBook.Model.Entitites;
using AutoMapper;

namespace AddressBook.Web.Controllers
{
    public class EmployeeController : ApiController
    {
        private static readonly EmployeeRepository Repository = new EmployeeRepository();

        public EmployeeDto Get(long id)
        {
            var employee = Mapper.DynamicMap<Employee, EmployeeDto>(Repository.GetById(id));

            return employee;
        }

        public void Post(Employee employee)
        {
            Repository.Save(employee);
        }

        public void Delete(long id)
        {
            Repository.Delete(id);
        }
    }
}