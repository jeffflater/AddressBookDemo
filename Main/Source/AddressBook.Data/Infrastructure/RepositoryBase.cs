using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Data.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        public virtual void Add(T entity) 
        { 
        }

        public virtual void Update(T entity) 
        { 
        }

        public virtual void Delete(T entity) 
        { 
        }

        public virtual T GetById(string id)
        {
            return null;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return null;
        }
    }
}
