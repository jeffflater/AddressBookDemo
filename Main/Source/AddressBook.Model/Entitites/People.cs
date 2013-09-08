using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model.Entitites
{
    public class People : Abstract.Person
    {
        public Enum.PersonType PersonType { get; set; }
    }
}