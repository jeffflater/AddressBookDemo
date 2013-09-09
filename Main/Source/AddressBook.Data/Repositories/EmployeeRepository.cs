using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Data.Repositories
{
    /// <summary>
    /// Employee Repository
    /// </summary>
    public class EmployeeRepository : Infrastructure.RepositoryBase<Model.Entitites.Employee>, Contracts.IEmployeeRepository
    {
        private static DTO.EmployeeDTO employeeDTO = new DTO.EmployeeDTO();

        /// <summary>
        /// Get Employee entity by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Model.Entitites.Employee GetById(long Id)
        {
            return employeeDTO.GetById(Id);
        }

        /// <summary>
        /// Get All Employee entities
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Model.Entitites.Employee> GetAll()
        {
            return employeeDTO.GetAll();
        }

        /// <summary>
        /// Save Employee entity :
        ///     If Employee.Id is zero a new Employee record will be created
        ///     If Employee.Id is not zero an existing Employee record will be updated
        /// </summary>
        /// <param name="entity"></param>
        public override void Save(Model.Entitites.Employee entity)
        {
            employeeDTO.Save(entity);
        }

        /// <summary>
        /// Delete Employee entity by Id :
        ///     The IsDeleted record is set to 1; records are not actually deleted from the database
        /// </summary>
        /// <param name="Id"></param>
        public override void Delete(long Id)
        {
            employeeDTO.Delete(Id);
        }
    }
}
