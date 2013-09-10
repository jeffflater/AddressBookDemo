using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model.DTO
{
    public class PersonDto : Abstract.PersonDto
    {
        public Enum.PersonType PersonType { get; set; }
    }
}
