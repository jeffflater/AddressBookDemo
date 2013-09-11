using System;

namespace AddressBook.Model.DTO
{
    /// <summary>
    ///     Concrete EmployeeDto Class : Inherits from abstract PersonDto class
    /// </summary>
    public class EmployeeDto : Abstract.PersonDto
    {
        public string Region { get; set; }
        public string Department { get; set; }
        public string Branch { get; set; }
        public DateTime HireDate { get; set; }
        public bool ApprovedOvertime { get; set; }
    }
}