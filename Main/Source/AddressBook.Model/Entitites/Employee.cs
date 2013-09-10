using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model.Entitites
{
    /// <summary>
    /// Employee class : Inherits from abstract Personnel class
    /// </summary>
    public class Employee : Abstract.Personnel
    {
        public bool ApprovedOvertime { get; set; }
        public Relationship.Tree Tree { get; set; }
    }
}
