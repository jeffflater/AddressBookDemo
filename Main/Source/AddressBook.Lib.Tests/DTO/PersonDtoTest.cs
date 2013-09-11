using System;
using AddressBook.Model.DTO;
using AddressBook.Model.Entitites;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressBook.Lib.Tests.DTO
{
    [TestClass]
    public class PersonDtoTest
    {
        [TestMethod]
        public void PersonDtoMappingTest()
        {
            //TODO: update proper mappings for this test to pass

            Mapper.CreateMap<Customer, PersonDto>();
            Mapper.AssertConfigurationIsValid();

            Mapper.CreateMap<Employee, PersonDto>();
            Mapper.AssertConfigurationIsValid();

            Mapper.CreateMap<Manager, PersonDto>();
            Mapper.AssertConfigurationIsValid();

            Mapper.CreateMap<SalesPerson, PersonDto>();
            Mapper.AssertConfigurationIsValid();
        }
    }
}
