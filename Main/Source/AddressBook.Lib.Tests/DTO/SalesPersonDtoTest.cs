using System;
using AddressBook.Model.DTO;
using AddressBook.Model.Entitites;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressBook.Lib.Tests.DTO
{
    [TestClass]
    public class SalesPersonDtoTest
    {
        [TestMethod]
        public void SalesPersonDtoMappingTest()
        {
            Mapper.CreateMap<SalesPerson, SalesPersonDto>();
            Mapper.AssertConfigurationIsValid();
        }
    }
}
