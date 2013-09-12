using System.Collections.Generic;
using System.Linq;
using System.Text;
using AddressBook.Lib.DAL;
using AddressBook.Model.Enum;

namespace AddressBook.Lib.Infrastructure
{
    /// <summary>
    ///     Abstract base BLL
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BllBase<T> where T : class
    {
        /// <summary>
        ///     Save method
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Save(T entity)
        {
        }

        /// <summary>
        ///     Delete method
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(long id)
        {
        }

        /// <summary>
        ///     Get multiple models by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="personType"></param>
        /// <returns></returns>
        public virtual T GetById(long id, PersonType personType)
        {
            var sql = new StringBuilder();

            //NOTE: Views only return records that have not been flagged as deleted.
            switch (personType)
            {
                case PersonType.Customer:
                    sql.Append(string.Format("SELECT * FROM dbo.vwCustomers WHERE id = {0}", id));
                    break;
                case PersonType.Employee:
                    sql.Append(string.Format("SELECT * FROM dbo.vwEmployees WHERE id = {0}", id));
                    break;
                case PersonType.Manager:
                    sql.Append(string.Format("SELECT * FROM dbo.vwManagers WHERE id = {0}", id));
                    break;
                case PersonType.SalesPerson:
                    sql.Append(string.Format("SELECT * FROM dbo.vwSalesPeople WHERE id = {0}", id));
                    break;
            }

            return AdoProvider.QueryTransaction<T>(sql.ToString()).FirstOrDefault();
        }

        /// <summary>
        ///     Get multiple models by id
        /// </summary>
        /// <param name="personType"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll(PersonType personType)
        {
            var sql = new StringBuilder();

            //NOTE: Views only return records that have not been flagged as deleted.
            switch (personType)
            {
                case PersonType.Customer:
                    sql.Append("SELECT * FROM dbo.vwCustomers");
                    break;
                case PersonType.Employee:
                    sql.Append("SELECT * FROM dbo.vwEmployees");
                    break;
                case PersonType.Manager:
                    sql.Append("SELECT * FROM dbo.vwManagers");
                    break;
                case PersonType.SalesPerson:
                    sql.Append("SELECT * FROM dbo.vwSalesPeople");
                    break;
            }

            return AdoProvider.QueryTransaction<T>(sql.ToString());
        }
    }
}