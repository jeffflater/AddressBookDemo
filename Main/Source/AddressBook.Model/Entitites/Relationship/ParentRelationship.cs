using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model.Entitites.Relationship
{
    public class ParentRelationship : Abstract.Entity
    {
        public long ParentId { get; set; }
        public int ParentPersonTypeId { get; set; }
        public string ChildRelationships { get; set; }
    }
}
