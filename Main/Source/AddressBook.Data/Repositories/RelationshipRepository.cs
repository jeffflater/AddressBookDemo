using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace AddressBook.Data.Repositories
{
    public class RelationshipRepository : Infrastructure.RepositoryBase<Model.Entitites.Relationship>, Contracts.IRelationshipRepository
    {
        public IEnumerable<Model.Entitites.Relationship> GetAll(long Id)
        {
            return new List<Model.Entitites.Relationship>();
        }
    }
}
