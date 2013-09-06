using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model.Entitites.Location
{
    public class Address : Entity
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public City City { get; set; }
        public State State { get; set; }
        public Country Country { get; set; }
        public bool IsPrimary { get; set; }
    }
}
