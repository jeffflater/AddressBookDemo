using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AddressBook.Web.Controllers
{
    public class RelationshipController : ApiController
    {
        Data.Repositories.RelationshipRepository repository = new Data.Repositories.RelationshipRepository();

        public IEnumerable<Model.Entitites.Relationship.Leaf> Get(long Id, int TypeId)
        {
            var tree = new Model.Entitites.Relationship.Tree();
            tree.ParentId = Id;
            tree.ParentPersonType = (Model.Enum.PersonType)TypeId;

            return repository.GetAll(tree);
        }

        public void Post(Model.Entitites.Relationship.Tree tree)
        {
            repository.Save(tree);
        }
    }
}
