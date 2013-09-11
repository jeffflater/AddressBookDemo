using AddressBook.Model.Entitites.Abstract;
using AddressBook.Model.Entitites.Relationship;

namespace AddressBook.Model.Entitites
{
    /// <summary>
    ///     Concrete Employee class : Inherits from abstract Personnel class
    /// </summary>
    public class Employee : Personnel
    {
        public bool ApprovedOvertime { get; set; }
        public Tree Tree { get; set; }
    }
}