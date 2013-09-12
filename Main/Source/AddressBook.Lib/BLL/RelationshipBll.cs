using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using AddressBook.Lib.BLL.Contracts;
using AddressBook.Lib.Extensions;
using AddressBook.Model.Entitites.Relationship;
using AddressBook.Model.Enum;
using Newtonsoft.Json;

namespace AddressBook.Lib.BLL
{
    public class RelationshipBll : IRelationshipBll
    {
        private static readonly List<Leaf> RelatedLeafs = new List<Leaf>();

        private static int _leafDistanceCounter;

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
            string personTypeId = ((int) personType).ToString(CultureInfo.InvariantCulture);

            sql.Append(
                string.Format("SELECT * FROM dbo.RelationshipTree WHERE ParentId = {0} AND ParentPersonType = {1}",
                    parentId, personTypeId));

            List<Tree> trees = AdoProvider.QueryTransaction<Tree>(sql.ToString());

            TraverseTree(trees);

            return RelatedLeafs;
        }

        /// <summary>
        ///     Traverse entire tree starting with the Parent and calculte the distance of each child away from the parent entity
        ///     Customer, Employee, Manager and SalesPerson can all be related to eachother
        /// </summary>
        /// <param name="trees"></param>
        private static void TraverseTree(IEnumerable<Tree> trees)
        {
            while (true)
            {
                _leafDistanceCounter += 1;

                var sql = new StringBuilder();

                var relatedTrees = new List<Tree>();

                foreach (Tree tree in trees)
                {
                    sql.Append("SELECT * FROM dbo.RelationshipTree ");

                    int leafCounter = 0;
                    var childBranch = JsonConvert.DeserializeObject<List<Leaf>>(tree.ChildBranch.ToString());

                    foreach (Leaf leaf in childBranch)
                    {
                        string leafId = leaf.Id.ToString(CultureInfo.InvariantCulture);
                        string personTypeId = ((int) leaf.PersonType).ToString(CultureInfo.InvariantCulture);

                        RelatedLeafs.Add(new Leaf(leaf.Id, leaf.PersonType, _leafDistanceCounter));

                        sql.Append(leafCounter == 0 ? "WHERE " : "OR ");
                        sql.Append(string.Format("(ParentId = {0} AND ParentPersonType = {1}) ", leafId, personTypeId));

                        leafCounter += 1;
                    }

                    List<Tree> treeSearcher = AdoProvider.QueryTransaction<Tree>(sql.ToString());

                    if (treeSearcher.Any())
                    {
                        relatedTrees.AddRange(treeSearcher);
                    }
                }

                if (relatedTrees.Any())
                {
                    trees = relatedTrees;
                    continue;
                }
                break;
            }
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
                sql = new StringBuilder();

                var leaf = new Leaf { Id = childId, PersonType = childPersonType };
                leafs.Add(leaf);

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
                sql = new StringBuilder();

                sql.Append(
                    string.Format(
                        "SELECT ChildBranch FROM dbo.RelationshipTree WHERE ParentId = {0} AND ParentPersonType = {1}",
                        parentId, (int)parentPersonType));

                var branchSearcher = AdoProvider.QueryTransaction<string>(sql.ToString()).FirstOrDefault();

                if (branchSearcher != null)
                {
                    leafs =
                    JsonConvert.DeserializeObject<List<Leaf>>(branchSearcher.First().ToString(CultureInfo.InvariantCulture));
                }

                var leaf = new Leaf { Id = childId, PersonType = childPersonType };
                leafs.Add(leaf);
                
                sql.Append("UPDATE dbo.RelationshipTree ");
                sql.Append(string.Format("SET ChildBranch = '{0}', ", JsonConvert.SerializeObject(leafs)));
                sql.Append("LastModifiedOn = GETDATE() ");
                sql.Append(string.Format("WHERE ParentId = {0}", (int)parentPersonType));

                AdoProvider.CommitTransaction(sql.ToString());
            }

        }

        public void Delete(long id, PersonType personType)
        {
            var sql = new StringBuilder();

            var parentId = id.ToString(CultureInfo.InvariantCulture);
            var parentPersonTypeId = ((int) personType).ToString(CultureInfo.InvariantCulture);

            sql.Append(string.Format("DELETE FROM RelationshipTree WHERE ParentId = {0} AND ParentPersonType = {1}",
                parentId, parentPersonTypeId));

            AdoProvider.CommitTransaction(sql.ToString());
        }
    }
}