using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace AddressBook.Data.Repositories
{
    /// <summary>
    /// Relationship Repository
    /// </summary>
    public class RelationshipRepository : Contracts.IRelationshipRepository
    {
        private static DTO.RelationshipDTO relationshipDTO = new DTO.RelationshipDTO();

        /// <summary>
        /// Get entire relationship tree based on Employee, Customer, Manager or SalesPeron Id
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="parentPersonType"></param>
        /// <returns></returns>
        public IEnumerable<Model.Entitites.Relationship.Leaf> GetAll(Model.Entitites.Relationship.Tree tree)
        {
            return relationshipDTO.GetAll(tree);
        }

        /// <summary>
        /// Save parent/child relationship
        /// </summary>
        /// <param name="parentChildRelationship"></param>
        public void Save(Model.Entitites.Relationship.Tree tree)
        {
            relationshipDTO.Save(tree);
        }
    }
}
