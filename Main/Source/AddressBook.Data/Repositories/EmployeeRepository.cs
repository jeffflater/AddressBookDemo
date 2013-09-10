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
        /// <summary>
        /// Get Employee entity by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Model.Entitites.Employee GetById(long Id)
        {
            return base.GetById(Id, Model.Enum.PersonType.Employee);
        }

        /// <summary>
        /// Get All Employee entities
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Model.Entitites.Employee> GetAll()
        {
            return base.GetAll(Model.Enum.PersonType.Employee);
        }

        /// <summary>
        /// Save Employee entity :
        ///     If Employee.Id is zero a new Employee record will be created
        ///     If Employee.Id is not zero an existing Employee record will be updated
        /// </summary>
        /// <param name="entity"></param>
        public override void Save(Model.Entitites.Employee entity)
        {
            var sql = new StringBuilder();

            if (entity.Id == 0)
            {
                //Generate SQL to create new record
                sql.Append("INSERT INTO dbo.Employees (FirstName, LastName, DateOfBirth, Region, Department, Branch, HireDate, ApprovedOvertime, CreatedOn, LastModifiedOn, IsDeleted) ");
                sql.Append(string.Format("VALUES ('{0}', '{1}', '{2}', '{3}', , '{4}', '{5}', '{6}', {7}, GETDATE(), GETDATE(), 0)", entity.FirstName,
                                                                                                                                entity.LastName,
                                                                                                                                entity.DateOfBirth.ToShortDateString(),
                                                                                                                                entity.Region,
                                                                                                                                entity.Department,
                                                                                                                                entity.Branch,
                                                                                                                                entity.HireDate.ToShortDateString(),
                                                                                                                                entity.ApprovedOvertime ? '1' : '0'));

            }
            else
            {
                //Generate SQL to update existing record
                sql.Append("UPDATE dbo.Employees ");
                sql.Append(string.Format("SET FirstName = '{0}', ", entity.FirstName));
                sql.Append(string.Format("LastName = '{0}', ", entity.LastName));
                sql.Append(string.Format("DateOfBirth = '{0}', ", entity.DateOfBirth.ToShortDateString()));
                sql.Append(string.Format("Region = '{0}', ", entity.Region));
                sql.Append(string.Format("Department = {0}, ", entity.Department));
                sql.Append(string.Format("Branch = '{0}', ", entity.Branch));
                sql.Append(string.Format("HireDate = '{0}', ", entity.HireDate.ToShortDateString()));
                sql.Append(string.Format("ApprovedOvertime = {0}, ", entity.ApprovedOvertime ? '1' : '0'));
                sql.Append("LastModifiedOn = GETDATE() ");
                sql.Append(string.Format("WHERE Id = ", entity.Id.ToString()));
            }

            Lib.Extenstions.SqlExtensions.CommitTransaction(sql.ToString());
        }

        /// <summary>
        /// Delete Employee entity by Id :
        ///     The IsDeleted record is set to 1; records are not actually deleted from the database
        /// </summary>
        /// <param name="Id"></param>
        public override void Delete(long Id)
        {
            var sql = string.Format("UPDATE dbo.Employees SET IsDeleted = 1, LastModifiedOn = GETDATE() WHERE Id = {0}", Id.ToString());

            Lib.Extenstions.SqlExtensions.CommitTransaction(sql);
        }
    }
}
