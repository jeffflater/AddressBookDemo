using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model.Entitites.People
{
    public class Contact : Person
    {
        public List<Location.Address> Addresses { get; set; }
        public List<ContactInfo.Phone> Phones { get; set; }
        public List<ContactInfo.Email> Emails { get; set; }
        public List<ContactRelationship> Relationships { get; set; }
    }
}
