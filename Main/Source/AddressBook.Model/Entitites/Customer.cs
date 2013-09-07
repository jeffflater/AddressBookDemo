using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model.Entitites
{
    public class Customer : Abstract.Person
    {
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Race { get; set; }
        public string Education { get; set; }
    }
}
