using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model.Entitites
{
    /// <summary>
    /// People class : Inherits from abstract Person class
    /// </summary>
    public class People : Abstract.Person
    {
        public Enum.PersonType PersonType { get; set; }
    }
}