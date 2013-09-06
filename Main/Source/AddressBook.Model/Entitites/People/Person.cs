using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model.Entitites.People
{
    public abstract class Person : Entity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName {
            get {
                return !string.IsNullOrEmpty(MiddleName) ?
                            string.Format("{1}, {0} {2}", FirstName, LastName, MiddleName) :
                            string.Format("{0}, {1}", FirstName, LastName);
            }
        }
        public Enum.Person.Sex Sex { get; set; }
        public Enum.Person.HairColor HairColor { get; set; }
        public Enum.Person.EyeColor EyeColor { get; set; }
        public string Photo { get; set; }
    }
}
