using AddressBook.Model.Enum;

namespace AddressBook.Model.DTO
{
    /// <summary>
    ///     Concrete PersonDto Class : Inherits from abstract PersonDto class
    /// </summary>
    public class PersonDto : Abstract.PersonDto
    {
        public PersonType PersonType { get; set; }
    }
}