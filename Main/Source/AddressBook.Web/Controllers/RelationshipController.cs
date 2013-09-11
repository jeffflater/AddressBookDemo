using System.Collections.Generic;
using System.Web.Http;
using AddressBook.Data.Repositories;
using AddressBook.Model.DTO;
using AddressBook.Model.Entitites.Relationship;
using AddressBook.Model.Enum;
using AutoMapper;

namespace AddressBook.Web.Controllers
{
    public class RelationshipController : ApiController
    {
        private static readonly RelationshipRepository Repository = new RelationshipRepository();

        public IEnumerable<RelationshipDto> Get(long id, int typeId)
        {
            var tree = new Tree
            {
                ParentId = id,
                ParentPersonType = (PersonType) typeId
            };

            var relationships = Mapper.DynamicMap<IEnumerable<Leaf>, List<RelationshipDto>>(Repository.GetAll(tree));

            return relationships;
        }

        public void Post(Tree tree)
        {
            Repository.Save(tree);
        }
    }
}