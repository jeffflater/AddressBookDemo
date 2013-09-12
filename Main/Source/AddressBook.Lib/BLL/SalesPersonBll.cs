using System.Collections.Generic;
using System.Text;
using AddressBook.Lib.BLL.Contracts;
using AddressBook.Lib.Extensions;
using AddressBook.Lib.Infrastructure;
using AddressBook.Model.Entitites;
using AddressBook.Model.Enum;

namespace AddressBook.Lib.BLL
{
    public class SalesPersonBll : BllBase<SalesPerson>, ISalesPersonBll
    {
        /// <summary>
        ///     Get SalesPerson entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SalesPerson GetById(long id)
        {
            return base.GetById(id, PersonType.SalesPerson);
        }

        /// <summary>
        ///     Get All SalesPerson entities
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SalesPerson> GetAll()
        {
            return base.GetAll(PersonType.SalesPerson);
        }

        /// <summary>
        ///     Save SalesPerson entity :
        ///     If SalesPerson.id is zero a new SalesPerson record will be created
        ///     If SalesPerson.id is not zero an existing SalesPerson record will be updated
        /// </summary>
        /// <param name="entity"></param>
        public override void Save(SalesPerson entity)
        {
            var sql = new StringBuilder();

            if (entity.Id == 0)
            {
                //Generate SQL to create new record
                sql.Append(
                    "INSERT INTO dbo.SalesPeople (FirstName, LastName, DateOfBirth, Region, Department, Branch, HireDate, WeeklySalesGoal, CreatedOn, LastModifiedOn, IsDeleted) ");
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
                        entity.WeeklySalesGoal));
            }
            else
            {
                //Generate SQL to update existing record
                sql.Append("UPDATE dbo.SalesPeople ");
                sql.Append(string.Format("SET FirstName = '{0}', ", entity.FirstName));
                sql.Append(string.Format("LastName = '{0}', ", entity.LastName));
                sql.Append(string.Format("DateOfBirth = '{0}', ", entity.DateOfBirth.ToShortDateString()));
                sql.Append(string.Format("Region = '{0}', ", entity.Region));
                sql.Append(string.Format("Department = {0}, ", entity.Department));
                sql.Append(string.Format("Branch = '{0}', ", entity.Branch));
                sql.Append(string.Format("HireDate = '{0}', ", entity.HireDate.ToShortDateString()));
                sql.Append(string.Format("WeeklySalesGoal = {0}, ", entity.WeeklySalesGoal));
                sql.Append("LastModifiedOn = GETDATE() ");
                sql.Append(string.Format("WHERE id = {0}", entity.Id));
            }

            AdoProvider.CommitTransaction(sql.ToString());
        }

        /// <summary>
        ///     Delete SalesPerson entity by id :
        ///     The IsDeleted record is set to 1; records are not actually deleted from the database
        /// </summary>
        /// <param name="id"></param>
        public override void Delete(long id)
        {
            var sql =
                string.Format("UPDATE dbo.Managers SET IsDeleted = 1, LastModifiedOn = GETDATE() WHERE id = {0}", id);

            AdoProvider.CommitTransaction(sql);
        }
    }
}