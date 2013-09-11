using AddressBook.Model.Entitites.Abstract;
using AddressBook.Model.Entitites.Relationship;

namespace AddressBook.Model.Entitites
{
    /// <summary>
    ///     Concrete SalesPerson class : Inherits from abstract Personnel class
    /// </summary>
    public class SalesPerson : Personnel
    {
        public int WeeklySalesGoal { get; set; }
        public Tree Tree { get; set; }
    }
}