using AddressBook.Model.Entitites.Abstract;
using AddressBook.Model.Entitites.Relationship;

namespace AddressBook.Model.Entitites
{
    /// <summary>
    ///     Concrete Customer class : Inherits from abstract Person class
    /// </summary>
    public class Customer : Person
    {
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Race { get; set; }
        public string Education { get; set; }
        public Tree Tree { get; set; }
    }
}