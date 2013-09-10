using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model.Entitites.Relationship
{
    /// <summary>
    /// ParentChildRelationship class
    /// </summary>
    public class ParentChildRelationship
    {
        public long ParentId { get; set; }
        public Model.Enum.PersonType ParentPersonType { get; set; }
        public long ChildId { get; set; }
        public Model.Enum.PersonType ChildPersonType { get; set; }
    }
}
