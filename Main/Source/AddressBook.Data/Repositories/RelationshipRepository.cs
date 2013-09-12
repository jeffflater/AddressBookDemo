using System.Collections.Generic;
using AddressBook.Data.Repositories.Contracts;
using AddressBook.Lib.BLL;
using AddressBook.Model.Entitites.Relationship;
using AddressBook.Model.Enum;

namespace AddressBook.Data.Repositories
{
    /// <summary>
    ///     Relationship Repository
    /// </summary>
    public class RelationshipRepository : IRelationshipRepository
    {
        private static readonly RelationshipBll RelationshipBll = new RelationshipBll();

        /// <summary>
        ///     Get entire relationship tree based on Employee, Customer, Manager or SalesPeron Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="personType"></param>
        /// <returns></returns>
        public IEnumerable<Leaf> GetAll(long id, PersonType personType)
        {
            return RelationshipBll.GetAll(id, personType);
        }

        /// <summary>
        ///     Save parent/child relationship
        /// </summary>
        /// <param name="tree"></param>
        public void Save(Tree tree)
        {
            RelationshipBll.Save(tree);
        }

        /// <summary>
        ///     Delete replationship
        /// </summary>
        /// <param name="id"></param>
        /// <param name="personType"></param>
        public void Delete(long id, PersonType personType)
        {
            RelationshipBll.Delete(id, personType);
        }
    }
}