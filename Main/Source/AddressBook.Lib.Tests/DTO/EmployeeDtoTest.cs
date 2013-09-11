using System;
using AddressBook.Model.DTO;
using AddressBook.Model.Entitites;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressBook.Lib.Tests.DTO
{
    [TestClass]
    public class EmployeeDtoTest
    {
        [TestMethod]
        public void EmployeeDtoMappingTest()
        {
            Mapper.CreateMap<Employee, EmployeeDto>();
            Mapper.AssertConfigurationIsValid();
        }
    }
}
