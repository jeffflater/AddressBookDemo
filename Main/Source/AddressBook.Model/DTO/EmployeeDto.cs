namespace AddressBook.Model.DTO
{
    /// <summary>
    ///     Concrete EmployeeDto Class : Inherits from abstract PersonDto class
    /// </summary>
    public class EmployeeDto : Abstract.PersonDto
    {
        public bool ApprovedOvertime { get; set; }
    }
}