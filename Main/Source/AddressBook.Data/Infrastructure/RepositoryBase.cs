using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Data.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        public virtual void Save(T entity) 
        { 
        }

        public virtual void Delete(long Id) 
        { 
        }

        public virtual T GetById(long Id)
        {
            return null;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return null;
        }
    }
}
