using System.Collections.Generic;
using System.Text;
using AddressBook.Data.Infrastructure;
using AddressBook.Data.Repositories.Contracts;
using AddressBook.Lib.Extensions;
using AddressBook.Model.Entitites;
using AddressBook.Model.Enum;

namespace AddressBook.Data.Repositories
{
    /// <summary>
    ///     Customer Repository
    /// </summary>
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        //TODO: Extract SQL Code to Data Access Layer; Should not be in the repoistory
        
        /// <summary>
        ///     Get Customer entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer GetById(long id)
        {
            return base.GetById(id, PersonType.Customer);
        }

        /// <summary>
        ///     Get All Customer entities
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> GetAll()
        {
            return base.GetAll(PersonType.Customer);
        }

        /// <summary>
        ///     Save Customer entity :
        ///     If Customer.Id is zero a new Customer record will be created
        ///     If Customer.Id is not zero an existing Customer record will be updated
        /// </summary>
        /// <param name="entity"></param>
        public override void Save(Customer entity)
        {
            var sql = new StringBuilder();

            if (entity.Id == 0)
            {
                //Generate SQL to create new record
                sql.Append(
                    "INSERT INTO dbo.Customers (FirstName, LastName, DateOfBirth, Gender, Age, Race, Education, CreatedOn, LastModifiedOn, IsDeleted) ");
                sql.Append(
                    string.Format("VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', GETDATE(), GETDATE(), 0)",
                        entity.FirstName,
                        entity.LastName,
                        entity.DateOfBirth.ToShortDateString(),
                        entity.Gender,
                        entity.Age,
                        entity.Race,
                        entity.Education));
            }
            else
            {
                //Generate SQL to update existing record
                sql.Append("UPDATE dbo.Customers ");
                sql.Append(string.Format("SET FirstName = '{0}', ", entity.FirstName));
                sql.Append(string.Format("LastName = '{0}', ", entity.LastName));
                sql.Append(string.Format("DateOfBirth = '{0}', ", entity.DateOfBirth.ToShortDateString()));
                sql.Append(string.Format("Gender = '{0}', ", entity.Gender));
                sql.Append(string.Format("Age = {0}, ", entity.Age));
                sql.Append(string.Format("Race = '{0}', ", entity.Race));
                sql.Append(string.Format("Education = '{0}', ", entity.Education));
                sql.Append("LastModifiedOn = GETDATE() ");
                sql.Append(string.Format("WHERE Id = {0}", entity.Id));
            }

            AdoProvider.CommitTransaction(sql.ToString());
        }

        /// <summary>
        ///     Delete Customer entity by Id :
        ///     The IsDeleted record is set to 1; records are not actually deleted from the database
        /// </summary>
        /// <param name="id"></param>
        public override void Delete(long id)
        {
            var sql = string.Format("UPDATE dbo.Customers SET IsDeleted = 1, LastModifiedOn = GETDATE() WHERE Id = {0}", id);

            AdoProvider.CommitTransaction(sql);
        }
    }
}