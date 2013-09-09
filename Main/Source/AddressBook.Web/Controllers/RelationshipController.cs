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

        public IEnumerable<Model.Entitites.Relationship.ParentRelationship> Get(long Id)
        {
            return null; //repository.GetAll(Id);
        }

        public void Post(Model.Entitites.Relationship.ParentRelationship relationship)
        {
            //repository.Save(relationship);
        }
    }
}
