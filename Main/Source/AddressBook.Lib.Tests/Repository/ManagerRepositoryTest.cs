using System;
using AddressBook.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressBook.Lib.Tests.Repository
{
    [TestClass]
    public class ManagerRepositoryTest
    {
        private static readonly ManagerRepository ManagerRepository = new ManagerRepository();

        [TestMethod]
        public void ManagerRetrieveByIdTest()
        {
            const long managerId = 1;
            var manager = ManagerRepository.GetById(managerId);
            Assert.AreEqual(managerId, manager.Id);
        }

        [TestMethod]
        public void ManagerRetrieveAllTest()
        {
            var managers = ManagerRepository.GetAll();
            Assert.IsNotNull(managers);
        }
    }
}
