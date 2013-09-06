using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model.Entitites.ContactInfo
{
    public abstract class ContactMethod : Entity
    {
        public bool IsPrimary { get; set; }
    }
}
