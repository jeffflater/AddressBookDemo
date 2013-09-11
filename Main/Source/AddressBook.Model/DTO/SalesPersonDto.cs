namespace AddressBook.Model.DTO
{
    /// <summary>
    ///     Concrete SalesPersonDto Class : Inherits from abstract PersonDto class
    /// </summary>
    public class SalesPersonDto : Abstract.PersonDto
    {
        public int WeeklySalesGoal { get; set; }
    }
}