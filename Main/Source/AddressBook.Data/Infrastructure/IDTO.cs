using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Data.Infrastructure
{
    /// <summary>
    /// Base DTO Operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDTO<T> where T : class
    {
        void Save(T entity);
        void Delete(long Id);
        T GetById(long Id);
        IEnumerable<T> GetAll();
    }
}
