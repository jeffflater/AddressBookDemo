using System;

namespace AddressBook.Model.Entitites.Abstract
{
    /// <summary>
    ///     Abstract Personnel class : Inherits from abstract Person class
    /// </summary>
    public abstract class Personnel : Person
    {
        public string Region { get; set; }
        public string Department { get; set; }
        public string Branch { get; set; }
        public DateTime HireDate { get; set; }
    }
}