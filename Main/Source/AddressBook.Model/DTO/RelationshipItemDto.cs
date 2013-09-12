using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Model.Enum;

namespace AddressBook.Model.DTO
{
    public class RelationshipItemDto
    {
        public long ParentId { get; set; }
        public PersonType ParentPersonType { get; set; }
        public long ChildId  { get; set; }
        public PersonType ChildPersonType { get; set; }
    }
}
