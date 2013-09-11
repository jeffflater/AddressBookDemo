using AddressBook.Model.Enum;

namespace AddressBook.Model.DTO
{
    /// <summary>
    ///     Concrete RelationshipDto Class : Inherits from abstract PersonDto class
    /// </summary>
    public class RelationshipDto
    {
        public long Id { get; set; }
        public PersonType PersonType { get; set; }
        public string FullName { get; set; }
        public int Distance { get; set; }
    }
}