namespace AddressBook.Model.DTO
{
    /// <summary>
    ///     Concrete CustomerDto Class : Inherits from abstract PersonDto class
    /// </summary>
    public class CustomerDto : Abstract.PersonDto
    {
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Race { get; set; }
        public string Education { get; set; }
    }
}