using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model.Entitites.People
{
    public class ContactRelationship : Person
    {
        public Enum.Contact.Relationship RelationshipType { get; set; }
    }
}
