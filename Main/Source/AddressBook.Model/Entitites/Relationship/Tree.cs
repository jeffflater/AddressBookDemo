using System.Collections.Generic;
using AddressBook.Model.Entitites.Abstract;
using AddressBook.Model.Enum;

namespace AddressBook.Model.Entitites.Relationship
{
    /// <summary>
    ///     Concrete Tree Class : Inherits from abstract Entity class
    /// </summary>
    public class Tree : Entity
    {
        public long ParentId { get; set; }
        public PersonType ParentPersonType { get; set; }
        public IEnumerable<Leaf> ChildBranch { get; set; }
    }
}