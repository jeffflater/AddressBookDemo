using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model.Entitites.ContactInfo
{
    public class Email : Entity
    {
        public string EmailAddress { get; set; }
        public bool IsPrimary { get; set; }
    }
}
