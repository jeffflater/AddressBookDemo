using System;
using AddressBook.Model.DTO;
using AddressBook.Model.Entitites;
using AddressBook.Model.Entitites.Relationship;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressBook.Lib.Tests.DTO
{
    [TestClass]
    public class CustomerDtoTest
    {
        [TestMethod]
        public void CustomerDtoMappingTest()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.AssertConfigurationIsValid();
        }
    }
}
