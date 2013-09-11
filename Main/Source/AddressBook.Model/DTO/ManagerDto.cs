namespace AddressBook.Model.DTO
{
    /// <summary>
    ///     Concrete ManagerDto Class : Inherits from abstract PersonDto class
    /// </summary>
    public class ManagerDto : Abstract.PersonDto
    {
        public int SpendingLimit { get; set; }
    }
}