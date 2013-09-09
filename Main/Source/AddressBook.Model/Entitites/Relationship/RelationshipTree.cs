using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model.Entitites.Relationship
{
    public class RelationshipTree
    {
        public long ParentId { get; set; }
        public Model.Enum.PersonType ParentPersonType { get; set; }
        
        public long ChildId { get; set; }
        public Model.Enum.PersonType ChildPersonType { get; set; }
        public string ChildFirstName { get; set; }
        public string ChildLastName { get; set; }
        public string ChildFullName
        {
            get
            {
                return string.Format("{0}, {1}", ChildLastName, ChildFirstName);
            }
        }

        public int TreeDistance { get; set; }

        public RelationshipTree()
        {
        }

        public RelationshipTree(long parentId, Model.Enum.PersonType parentPersonType, long childId, Model.Enum.PersonType childPersonType, int treeDistance)
        {
            ParentId = parentId;
            ParentPersonType = parentPersonType;
            ChildId = childId;
            ChildPersonType = childPersonType;
            TreeDistance = treeDistance;
        }
    }
}
