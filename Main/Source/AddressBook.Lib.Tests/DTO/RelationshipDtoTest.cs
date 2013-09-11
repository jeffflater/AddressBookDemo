using System;
using AddressBook.Model.DTO;
using AddressBook.Model.Entitites;
using AddressBook.Model.Entitites.Relationship;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressBook.Lib.Tests.DTO
{
    [TestClass]
    public class RelationshipDtoTest
    {
        [TestMethod]
        public void RelationshipDtoMappingTest()
        {
            //TODO: updated proper mappings for this test to pass
            Mapper.CreateMap<Leaf, RelationshipDto>();
            Mapper.AssertConfigurationIsValid();
        }
    }
}
