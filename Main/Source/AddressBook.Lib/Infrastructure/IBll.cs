using System.Collections.Generic;

namespace AddressBook.Lib.Infrastructure
{
    /// <summary>
    ///     Base BLL Operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBll<T> where T : class
    {
        void Save(T entity);
        void Delete(long id);
        T GetById(long id);
        IEnumerable<T> GetAll();
    }
}