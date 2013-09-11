using System.Collections.Generic;

namespace AddressBook.Data.Infrastructure
{
    /// <summary>
    ///     Base Repository Operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        void Save(T entity);
        void Delete(long id);
        T GetById(long id);
        IEnumerable<T> GetAll();
    }
}