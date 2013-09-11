using System.Web.Http;
using AddressBook.Data.Repositories;
using AddressBook.Model.DTO;
using AddressBook.Model.Entitites;
using AutoMapper;

namespace AddressBook.Web.Controllers
{
    public class EmployeeController : ApiController
    {
        private static readonly EmployeeRepository EmployeeRepository = new EmployeeRepository();

        /// <summary>
        ///     Get Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EmployeeDto Get(long id)
        {
            var employee = Mapper.DynamicMap<Employee, EmployeeDto>(EmployeeRepository.GetById(id));

            return employee;
        }

        /// <summary>
        ///     Save Employee
        /// </summary>
        /// <param name="employee"></param>
        public void Post(Employee employee)
        {
            EmployeeRepository.Save(employee);
        }

        /// <summary>
        ///     Delete Employee
        /// </summary>
        /// <param name="id"></param>
        public void Delete(long id)
        {
            EmployeeRepository.Delete(id);
        }
    }
}