using System.Collections.Generic;
using AddressBook.Data.Infrastructure;
using AddressBook.Data.Repositories.Contracts;
using AddressBook.Lib.BLL;
using AddressBook.Model.Entitites;
using AddressBook.Model.Enum;

namespace AddressBook.Data.Repositories
{
    /// <summary>
    ///     Employee Repository
    /// </summary>
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        private static readonly EmployeeBll EmployeeBll = new EmployeeBll();

        /// <summary>
        ///     Get Employee entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Employee GetById(long id)
        {
            return EmployeeBll.GetById(id);
        }

        /// <summary>
        ///     Get All Employee entities
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Employee> GetAll()
        {
            return EmployeeBll.GetAll();
        }

        /// <summary>
        ///     Save Employee entity :
        ///     If Employee.id is zero a new Employee record will be created
        ///     If Employee.id is not zero an existing Employee record will be updated
        /// </summary>
        /// <param name="entity"></param>
        public override void Save(Employee entity)
        {
            EmployeeBll.Save(entity);
        }

        /// <summary>
        ///     Delete Employee entity by id :
        ///     The IsDeleted record is set to 1; records are not actually deleted from the database
        /// </summary>
        /// <param name="id"></param>
        public override void Delete(long id)
        {
            EmployeeBll.Delete(id);
        }
    }
}