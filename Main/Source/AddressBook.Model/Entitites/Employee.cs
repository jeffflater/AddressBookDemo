﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model.Entitites
{
    public class Employee : Abstract.Personnel
    {
        public bool ApprovedOvertime { get; set; }
    }
}