using AddressBook.Model.Entitites.Abstract;
using AddressBook.Model.Entitites.Relationship;

namespace AddressBook.Model.Entitites
{
    /// <summary>
    ///     Concrete Manager class : Inherits from abstract Personnel class
    /// </summary>
    public class Manager : Personnel
    {
        public int SpendingLimit { get; set; }
        public Tree Tree { get; set; }
    }
}