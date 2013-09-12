using System.Collections.Generic;

namespace AddressBook.Data.Infrastructure
{
    /// <summary>
    ///     Abstract base repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RepositoryBase<T> where T : class
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
        ///     Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetById(long id)
        {
            return null;
        }

        /// <summary>
        ///     Get all
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
        {
            return null;
        }
    }
}