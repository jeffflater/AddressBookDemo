using System;
using AddressBook.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressBook.Lib.Tests.Repository
{
    [TestClass]
    public class SalesPersonRepositoryTest
    {
        private static readonly SalesPersonRepository SalesPersonRepository = new SalesPersonRepository();

        [TestMethod]
        public void SalesPersonRetrieveByIdTest()
        {
            const long salesPersonId = 1;
            var salesPerson = SalesPersonRepository.GetById(salesPersonId);
            Assert.AreEqual(salesPersonId, salesPerson.Id);
        }

        [TestMethod]
        public void SalesPersonRetrieveAllTest()
        {
            var salesPeople = SalesPersonRepository.GetAll();
            Assert.IsNotNull(salesPeople);
        }
    }
}
