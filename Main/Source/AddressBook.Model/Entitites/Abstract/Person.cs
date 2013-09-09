using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model.Entitites.Abstract
{
    /// <summary>
    /// Abstract Person class : Inherits from abstract Entity class
    /// </summary>
    public abstract class Person : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName {
            get {
                return string.Format("{0}, {1}", LastName, FirstName);
            }
        }
        public DateTime DateOfBirth { get; set; }
    }
}
