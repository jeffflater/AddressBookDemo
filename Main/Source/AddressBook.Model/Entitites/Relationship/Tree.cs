using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model.Entitites.Relationship
{
    /// <summary>
    /// 
    /// </summary>
    public class Tree : Abstract.Entity
    {
        public long ParentId { get; set; }
        public Enum.PersonType ParentPersonType { get; set; }
        public IEnumerable<Leaf> ChildBranch { get; set; }
    }
}
