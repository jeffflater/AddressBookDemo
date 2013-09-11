using System;
using AddressBook.Model.DTO;
using AddressBook.Model.Entitites;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressBook.Lib.Tests.DTO
{
    [TestClass]
    public class ManagerDtoTest
    {
        [TestMethod]
        public void ManagerDtoMappingTest()
        {
            Mapper.CreateMap<Manager, ManagerDto>();
            Mapper.AssertConfigurationIsValid();
        }
    }
}
