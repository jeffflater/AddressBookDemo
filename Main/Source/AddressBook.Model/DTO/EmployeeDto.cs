using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model.DTO
{
    public class EmployeeDto : Abstract.PersonDto
    {
        public bool ApprovedOvertime { get; set; }
    }
}
