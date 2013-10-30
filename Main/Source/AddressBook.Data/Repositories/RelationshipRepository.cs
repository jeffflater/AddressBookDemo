using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using AddressBook.Data.Repositories.Contracts;
using AddressBook.Lib.BLL;
using AddressBook.Lib.Extensions;
using AddressBook.Model.Entitites.Relationship;
using AddressBook.Model.Enum;
using Newtonsoft.Json;

namespace AddressBook.Data.Repositories
{
    /// <summary>
    ///     Relationship Repository
    /// </summary>
    public class RelationshipRepository : IRelationshipRepository
    {
        //TODO: Extract SQL Code to Data Access Layer; Should not be in the repoistory

        private static  readonly RelationshipBll RelationshipBll = new RelationshipBll();

        /// <summary>
        ///     Get entire relationship tree based on Employee, Customer, Manager or SalesPeron Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="personType"></param>
        /// <returns></returns>
        public IEnumerable<Leaf> GetAll(long id, PersonType personType)
        {
            var sql = new StringBuilder();

            string parentId = id.ToString(CultureInfo.InvariantCulture);
            string personTypeId = ((int)personType).ToString(CultureInfo.InvariantCulture);

            sql.Append(
                string.Format("SELECT * FROM dbo.RelationshipTree WHERE ParentId = {0} AND ParentPersonType = {1}",
                    parentId, personTypeId));

            List<Tree> trees = AdoProvider.QueryTransaction<Tree>(sql.ToString());

            RelationshipBll.TraverseTree(trees);

            return RelationshipBll.RelatedLeafs;
        }

        /// <summary>
        /// Save parent/child relationship
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="parentPersonType"></param>
        /// <param name="childId"></param>
        /// <param name="childPersonType"></param>
        public void Save(long parentId, PersonType parentPersonType, long childId, PersonType childPersonType)
        {
            var sql = new StringBuilder();

            sql.Append(
                string.Format("SELECT * FROM dbo.RelationshipTree WHERE ParentId = {0} AND ParentPersonType = {1}",
                    parentId, (int)parentPersonType));

            var treeSearcher = AdoProvider.QueryTransaction<Tree>(sql.ToString()).FirstOrDefault();

            var leafs = new List<Leaf>();

            //create new parent / child relationship
            if (treeSearcher == null)
            {
                var leaf = new Leaf { Id = childId, PersonType = childPersonType };
                leafs.Add(leaf);

                sql.Clear();
                sql.Append(
                    "INSERT INTO dbo.RelationshipTree (ParentId, ParentPersonType, ChildBranch, CreatedOn, LastModifiedOn, IsDeleted) ");
                sql.Append(string.Format("VALUES({0}, {1}, '{2}', GETDATE(), GETDATE(), 0)", parentId,
                    (int)parentPersonType,
                    JsonConvert.SerializeObject(leafs)));

                AdoProvider.CommitTransaction(sql.ToString());
            }

            //append child relation to existing child relationships
            if (treeSearcher != null)
            {
                sql.Clear();
                sql.Append(
                    string.Format(
                        "SELECT * FROM dbo.RelationshipTree WHERE ParentId = {0} AND ParentPersonType = {1}",
                        parentId, (int)parentPersonType));

                var childTreeSearcher = AdoProvider.QueryTransaction<Tree>(sql.ToString()).FirstOrDefault();
                
                if (childTreeSearcher != null)
                {
                    leafs.AddRange(JsonConvert.DeserializeObject<List<Leaf>>(childTreeSearcher.ChildBranch.ToString()));
                }

                var leaf = new Leaf { Id = childId, PersonType = childPersonType };
                leafs.Add(leaf);

                sql.Clear();
                sql.Append("UPDATE dbo.RelationshipTree ");
                sql.Append(string.Format("SET ChildBranch = '{0}', ", JsonConvert.SerializeObject(leafs)));
                sql.Append("LastModifiedOn = GETDATE() ");
                sql.Append(string.Format("WHERE ParentId = {0} AND ParentPersonType = {1}", parentId, (int)parentPersonType));

                AdoProvider.CommitTransaction(sql.ToString());
            }

        }

        public void Delete(long id, PersonType personType)
        {
            var sql = new StringBuilder();

            var parentId = id.ToString(CultureInfo.InvariantCulture);
            var parentPersonTypeId = ((int)personType).ToString(CultureInfo.InvariantCulture);

            sql.Append(string.Format("DELETE FROM RelationshipTree WHERE ParentId = {0} AND ParentPersonType = {1}",
                parentId, parentPersonTypeId));

            AdoProvider.CommitTransaction(sql.ToString());
        }
    }
}