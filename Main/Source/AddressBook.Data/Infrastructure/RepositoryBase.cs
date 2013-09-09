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
        public virtual T GetById(long Id)
        {
            return null;
        }

        /// <summary>
        /// Get multiple models by Id
        /// </summary>
        /// <param name="personType"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll(Model.Enum.PersonType personType)
        {
            return null;
        }

    }
}
