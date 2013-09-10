﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model.Entitites
{
    /// <summary>
    /// Customer class : Inherits from abstract Person class
    /// </summary>
    public class Customer : Abstract.Person
    {
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Race { get; set; }
        public string Education { get; set; }
        public Relationship.Tree Tree { get; set; }
    }
}
