using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model.Entitites
{
    /// <summary>
    /// Manager class : Inherits from abstract Personnel class
    /// </summary>
    public class Manager : Abstract.Personnel
    {
        public int SpendingLimit { get; set; }
    }
}
