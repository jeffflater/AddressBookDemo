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
    ///     Manager Repository
    /// </summary>
    public class ManagerRepository : RepositoryBase<Manager>, IManagerRepository
    {
        //TODO: Extract SQL Code to Data Access Layer; Should not be in the repoistory

        /// <summary>
        ///     Get Manager entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Manager GetById(long id)
        {
            return base.GetById(id, PersonType.Manager);
        }

        /// <summary>
        ///     Get All Manager entities
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Manager> GetAll()
        {
            return base.GetAll(PersonType.Manager);
        }

        /// <summary>
        ///     Save Manager entity :
        ///     If Manager.id is zero a new Manager record will be created
        ///     If Manager.id is not zero an existing Manager record will be updated
        /// </summary>
        /// <param name="entity"></param>
        public override void Save(Manager entity)
        {
            var sql = new StringBuilder();

            if (entity.Id == 0)
            {
                //Generate SQL to create new record
                sql.Append(
                    "INSERT INTO dbo.Managers (FirstName, LastName, DateOfBirth, Region, Department, Branch, HireDate, SpendingLimit, CreatedOn, LastModifiedOn, IsDeleted) ");
                sql.Append(
                    string.Format(
                        "VALUES ('{0}', '{1}', '{2}', '{3}', , '{4}', '{5}', '{6}', {7}, GETDATE(), GETDATE(), 0)",
                        entity.FirstName,
                        entity.LastName,
                        entity.DateOfBirth.ToShortDateString(),
                        entity.Region,
                        entity.Department,
                        entity.Branch,
                        entity.HireDate.ToShortDateString(),
                        entity.SpendingLimit));
            }
            else
            {
                //Generate SQL to update existing record
                sql.Append("UPDATE dbo.Managers ");
                sql.Append(string.Format("SET FirstName = '{0}', ", entity.FirstName));
                sql.Append(string.Format("LastName = '{0}', ", entity.LastName));
                sql.Append(string.Format("DateOfBirth = '{0}', ", entity.DateOfBirth.ToShortDateString()));
                sql.Append(string.Format("Region = '{0}', ", entity.Region));
                sql.Append(string.Format("Department = {0}, ", entity.Department));
                sql.Append(string.Format("Branch = '{0}', ", entity.Branch));
                sql.Append(string.Format("HireDate = '{0}', ", entity.HireDate.ToShortDateString()));
                sql.Append(string.Format("SpendingLimit = {0}, ", entity.SpendingLimit));
                sql.Append("LastModifiedOn = GETDATE() ");
                sql.Append(string.Format("WHERE id = {0}", entity.Id));
            }

            AdoProvider.CommitTransaction(sql.ToString());
        }

        /// <summary>
        ///     Delete Manager entity by id :
        ///     The IsDeleted record is set to 1; records are not actually deleted from the database
        /// </summary>
        /// <param name="id"></param>
        public override void Delete(long id)
        {
            var sql = string.Format("UPDATE dbo.Managers SET IsDeleted = 1, LastModifiedOn = GETDATE() WHERE id = {0}", id);

            AdoProvider.CommitTransaction(sql);
        }
    }
}