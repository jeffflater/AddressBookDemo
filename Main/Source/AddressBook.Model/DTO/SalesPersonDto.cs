using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model.DTO
{
    public class SalesPersonDto : Abstract.PersonDto
    {
        public int WeeklySalesGoal { get; set; }
    }
}
