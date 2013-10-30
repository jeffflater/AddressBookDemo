using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Lib.Extensions;
using AddressBook.Model.Entitites.Relationship;
using Newtonsoft.Json;

namespace AddressBook.Lib.BLL
{
    public class RelationshipBll
    {
        public static List<Leaf> RelatedLeafs = new List<Leaf>();
        private static int _leafDistanceCounter;

        /// <summary>
        ///     Traverse entire tree starting with the Parent and calculte the distance of each child away from the parent entity
        ///     Customer, Employee, Manager and SalesPerson can all be related to eachother
        /// </summary>
        /// <param name="trees"></param>
        public void TraverseTree(IEnumerable<Tree> trees)
        {
            RelatedLeafs = new List<Leaf>();
            _leafDistanceCounter = 0;

            while (true)
            {
                _leafDistanceCounter += 1;

                var sql = new StringBuilder();

                var relatedTrees = new List<Tree>();

                foreach (var tree in trees)
                {
                    sql.Append("SELECT * FROM dbo.RelationshipTree ");

                    int leafCounter = 0;
                    var childBranch = JsonConvert.DeserializeObject<List<Leaf>>(tree.ChildBranch.ToString());

                    foreach (Leaf leaf in childBranch)
                    {
                        string leafId = leaf.Id.ToString(CultureInfo.InvariantCulture);
                        string personTypeId = ((int)leaf.PersonType).ToString(CultureInfo.InvariantCulture);

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
    }
}
