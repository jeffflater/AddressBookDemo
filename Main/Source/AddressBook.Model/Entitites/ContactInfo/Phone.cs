﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model.Entitites.ContactInfo
{
    public class Phone : ContactMethod
    {
        public int Number { get; set; }
        public Enum.Phone.PhoneType PhoneType { get; set; }
    }
}
