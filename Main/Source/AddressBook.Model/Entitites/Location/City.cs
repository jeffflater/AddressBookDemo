﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model.Entitites.Location
{
    public class City : Entity
    {
        public string Name { get; set; }
        public string Abbrevation { get; set; }
        public string PostalCode { get; set; }
    }
}
