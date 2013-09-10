using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Data.DTO
{
    public class RelationshipDTO : Contracts.IRelationshipDTO
    {
        private static List<Model.Entitites.Relationship.Leaf> relatedLeafs = new List<Model.Entitites.Relationship.Leaf>();
        private static int leafDistanceCounter = 0;

        /// <summary>
        /// Get entire relationship tree based on Employee, Customer, Manager or SalesPeron Id
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        public IEnumerable<Model.Entitites.Relationship.Leaf> GetAll(Model.Entitites.Relationship.Tree tree)
        {
            var trees = new List<Model.Entitites.Relationship.Tree>();
            trees.Add(tree);

            TranverseTree(trees);

            return relatedLeafs;
        }

        /// <summary>
        /// Tranverse entire tree starting with the Parent and calculte the distance of each child away from the parent entity
        /// Customer, Employee, Manager and SalesPerson can all be related to eachother
        /// </summary>
        /// <param name="trees"></param>
        private void TranverseTree(List<Model.Entitites.Relationship.Tree> trees)
        {
            leafDistanceCounter += 1;

            var sql = new StringBuilder();

            var relatedTrees = new List<Model.Entitites.Relationship.Tree>();

            foreach (var tree in trees)
            {
                sql.Append("SELECT * FROM dbo.RelationshipTree ");

                var leafCounter = 0;
                foreach (var leaf in tree.ChildBranch)
                {
                    var leafId = leaf.Id.ToString();
                    var personTypeId = ((int)leaf.PersonType).ToString();

                    relatedLeafs.Add(new Model.Entitites.Relationship.Leaf(leaf.Id, leaf.PersonType));

                    sql.Append(leafCounter == 0 ? "WHERE " : "OR ");
                    sql.Append(string.Format("(ParentId = {0} AND ParentPersonTypeId = {1}) ", leafId, personTypeId));

                    leafCounter += 1;
                }

                var treeSearcher = Lib.Extenstions.SqlExtensions.QueryTransaction<Model.Entitites.Relationship.Tree>(sql.ToString());

                if (treeSearcher.Count() > 0)
                {
                    relatedTrees.AddRange(treeSearcher);
                }
            }

            if (relatedTrees.Count() > 0)
            {
                TranverseTree(relatedTrees);
            }
        }

        /// <summary>
        /// Save parent/child relationship
        /// </summary>
        /// <param name="tree"></param>
        public void Save(Model.Entitites.Relationship.Tree tree)
        {
            var sql = new StringBuilder();

            var parentId = tree.ParentId.ToString();
            var parentPersonTypeId = ((int)tree.ParentPersonType).ToString();

            sql.Append(string.Format("SELECT * FROM dbo.RelationshipTree WHERE ParentId = {0} AND ParentPersonTypeId = {1}", parentId, parentPersonTypeId));

            var treeSearcher = Lib.Extenstions.SqlExtensions.QueryTransaction<Model.Entitites.Relationship.Tree>(sql.ToString()).FirstOrDefault();

            //create new parent / child relationship
            if (treeSearcher == null)
            {
                sql = new StringBuilder();

                var leafs = new List<Model.Entitites.Relationship.Leaf>();
                var branch = tree.ChildBranch.First();

                leafs.Add(new Model.Entitites.Relationship.Leaf(branch.Id, branch.PersonType));

                sql.Append("INSERT INTO dbo.Relationships (ParentId, ParentPersonTypeId, ChildRelationships, CreatedOn, LastModifiedOn, IsDeleted) ");
                sql.Append(string.Format("VALUES({0}, {1}, '{2}', GETDATE(), GETDATE(), 0)", tree.ParentId.ToString(),
                                                                                                parentPersonTypeId.ToString(),
                                                                                                Newtonsoft.Json.JsonConvert.SerializeObject(leafs)));

                Lib.Extenstions.SqlExtensions.CommitTransaction(sql.ToString());
            }

            //append child relation to existing child relationships
            if (treeSearcher != null)
            {
                sql = new StringBuilder();

                sql.Append(string.Format("SELECT ChildBranch FROM dbo.RelationshipTree WHERE ParentId = {0} AND ParentPersonTypeId = {1}", parentId, parentPersonTypeId));

                var branchSearcher = Lib.Extenstions.SqlExtensions.QueryTransaction<string>(sql.ToString()).FirstOrDefault();

                if (branchSearcher != null)
                {
                    var leafs = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Model.Entitites.Relationship.Leaf>>(branchSearcher.First().ToString());

                    sql.Append("UPDATE dbo.RelationshipTree ");
                    sql.Append(string.Format("SET ChildRelationships = '{0}', ", Newtonsoft.Json.JsonConvert.SerializeObject(leafs)));
                    sql.Append("LastModifiedOn = GETDATE() ");
                    sql.Append(string.Format("WHERE ParentId = {0}", parentPersonTypeId));

                    Lib.Extenstions.SqlExtensions.CommitTransaction(sql.ToString());
                }

                
            }
        
        }
    }
}
