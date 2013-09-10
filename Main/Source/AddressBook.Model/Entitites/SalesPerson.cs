using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model.Entitites
{
    /// <summary>
    /// SalesPerson class : Inherits from abstract Personnel class
    /// </summary>
    public class SalesPerson : Abstract.Personnel
    {
        public int WeeklySalesGoal { get; set; }
        public Relationship.Tree Tree { get; set; }
    }
}
