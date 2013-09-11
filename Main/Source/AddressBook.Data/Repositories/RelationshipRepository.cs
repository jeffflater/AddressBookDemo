using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using AddressBook.Data.Repositories.Contracts;
using AddressBook.Lib.Extenstions;
using AddressBook.Model.Entitites.Relationship;
using Newtonsoft.Json;

namespace AddressBook.Data.Repositories
{
    /// <summary>
    ///     Relationship Repository
    /// </summary>
    public class RelationshipRepository : IRelationshipRepository
    {
        private static readonly List<Leaf> RelatedLeafs = new List<Leaf>();
        private static int _leafDistanceCounter;

        /// <summary>
        ///     Get entire relationship tree based on Employee, Customer, Manager or SalesPeron Id
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        public IEnumerable<Leaf> GetAll(Tree tree)
        {
            var trees = new List<Tree> {tree};

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

                foreach (var tree in trees)
                {
                    sql.Append("SELECT * FROM dbo.RelationshipTree ");

                    var leafCounter = 0;
                    foreach (var leaf in tree.ChildBranch)
                    {
                        string leafId = leaf.Id.ToString(CultureInfo.InvariantCulture);
                        string personTypeId = ((int) leaf.PersonType).ToString(CultureInfo.InvariantCulture);

                        RelatedLeafs.Add(new Leaf(leaf.Id, leaf.PersonType, _leafDistanceCounter));

                        sql.Append(leafCounter == 0 ? "WHERE " : "OR ");
                        sql.Append(string.Format("(ParentId = {0} AND ParentPersonTypeId = {1}) ", leafId, personTypeId));

                        leafCounter += 1;
                    }

                    var treeSearcher = SqlExtensions.QueryTransaction<Tree>(sql.ToString());

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
        ///     Save parent/child relationship
        /// </summary>
        /// <param name="tree"></param>
        public void Save(Tree tree)
        {
            var sql = new StringBuilder();

            var parentId = tree.ParentId.ToString(CultureInfo.InvariantCulture);
            var parentPersonTypeId = ((int) tree.ParentPersonType).ToString(CultureInfo.InvariantCulture);

            sql.Append(
                string.Format("SELECT * FROM dbo.RelationshipTree WHERE ParentId = {0} AND ParentPersonTypeId = {1}",
                    parentId, parentPersonTypeId));

            Tree treeSearcher = SqlExtensions.QueryTransaction<Tree>(sql.ToString()).FirstOrDefault();

            //create new parent / child relationship
            List<Leaf> leafs;
            if (treeSearcher == null)
            {
                sql = new StringBuilder();

                leafs = new List<Leaf>();
                var branch = tree.ChildBranch.First();

                leafs.Add(new Leaf(branch.Id, branch.PersonType));

                sql.Append(
                    "INSERT INTO dbo.Relationships (ParentId, ParentPersonTypeId, ChildRelationships, CreatedOn, LastModifiedOn, IsDeleted) ");
                sql.Append(string.Format("VALUES({0}, {1}, '{2}', GETDATE(), GETDATE(), 0)", tree.ParentId,
                    parentPersonTypeId,
                    JsonConvert.SerializeObject(leafs)));

                SqlExtensions.CommitTransaction(sql.ToString());
            }

            //append child relation to existing child relationships
            if (treeSearcher == null) return;

            sql = new StringBuilder();

            sql.Append(
                string.Format(
                    "SELECT ChildBranch FROM dbo.RelationshipTree WHERE ParentId = {0} AND ParentPersonTypeId = {1}",
                    parentId, parentPersonTypeId));

            var branchSearcher = SqlExtensions.QueryTransaction<string>(sql.ToString()).FirstOrDefault();

            if (branchSearcher == null) return;

            leafs =
                JsonConvert.DeserializeObject<List<Leaf>>(branchSearcher.First().ToString(CultureInfo.InvariantCulture));

            sql.Append("UPDATE dbo.RelationshipTree ");
            sql.Append(string.Format("SET ChildRelationships = '{0}', ", JsonConvert.SerializeObject(leafs)));
            sql.Append("LastModifiedOn = GETDATE() ");
            sql.Append(string.Format("WHERE ParentId = {0}", parentPersonTypeId));

            SqlExtensions.CommitTransaction(sql.ToString());
        }
    }
}