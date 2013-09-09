using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AddressBook.Data.Infrastructure
{
    /// <summary>
    /// Abstract base repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RepositoryBase<T> where T : class
    {
        /// <summary>
        /// Save method
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Save(T entity) 
        { 
        }

        /// <summary>
        /// Delete method
        /// </summary>
        /// <param name="Id"></param>
        public virtual void Delete(long Id) 
        { 
        }

        /// <summary>
        /// Get multiple models by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="personType"></param>
        /// <returns></returns>
        public virtual T GetById(long Id, Model.Enum.PersonType personType)
        {
            var sql = new StringBuilder();

            switch (personType)
            {
                case Model.Enum.PersonType.Customer:
                    sql.Append(string.Format("SELECT * FROM dbo.vwCustomers WHERE Id = {0}", Id.ToString()));
                    break;
                case Model.Enum.PersonType.Employee:
                    sql.Append(string.Format("SELECT * FROM dbo.vwEmployees WHERE Id = {0}", Id.ToString()));
                    break;
                case Model.Enum.PersonType.Manager:
                    sql.Append(string.Format("SELECT * FROM dbo.vwManagers WHERE Id = {0}", Id.ToString()));
                    break;
                case Model.Enum.PersonType.SalesPerson:
                    sql.Append(string.Format("SELECT * FROM dbo.vwSalesPeople WHERE Id = {0}", Id.ToString()));
                    break;
            }

            return Lib.Extenstions.SqlExtensions.QueryTransaction<T>(sql.ToString()).FirstOrDefault();
        }

        /// <summary>
        /// Get multiple models by Id
        /// </summary>
        /// <param name="personType"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll(Model.Enum.PersonType personType)
        {
            var sql = new StringBuilder();

            switch (personType)
            {
                case Model.Enum.PersonType.Customer:
                    sql.Append("SELECT * FROM dbo.vwCustomers");
                    break;
                case Model.Enum.PersonType.Employee:
                    sql.Append("SELECT * FROM dbo.vwEmployees");
                    break;
                case Model.Enum.PersonType.Manager:
                    sql.Append("SELECT * FROM dbo.vwManagers");
                    break;
                case Model.Enum.PersonType.SalesPerson:
                    sql.Append("SELECT * FROM dbo.vwSalesPeople");
                    break;
            }

            return Lib.Extenstions.SqlExtensions.QueryTransaction<T>(sql.ToString());
        }

    }
}
