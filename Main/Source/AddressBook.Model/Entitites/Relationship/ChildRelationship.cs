using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model.Entitites.Relationship
{
    /// <summary>
    /// ChildRelationship class : Inherits from abstract Entity class
    /// </summary>
    public class ChildRelationship : Abstract.Entity
    {
        public Model.Enum.PersonType PersonType { get; set; }

        /// <summary>
        /// Constructor used to create a new instance of ChildRelationship
        /// </summary>
        /// <param name="id"></param>
        /// <param name="personType"></param>
        public ChildRelationship(long id, Model.Enum.PersonType personType)
        {
            Id = id;
            PersonType = personType;
        }
    }
}
