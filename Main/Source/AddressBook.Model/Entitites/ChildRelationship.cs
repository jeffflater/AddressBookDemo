using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model.Entitites
{
    public class ChildRelationship
    {
        public long Id { get; set; }
        public Model.Enum.PersonType PersonType { get; set; }

        public ChildRelationship()
        {
        }

        public ChildRelationship(long id, Model.Enum.PersonType personType)
        {
            Id = id;
            PersonType = personType;
        }
    }
}
