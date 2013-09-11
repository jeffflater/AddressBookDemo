using System;
using AddressBook.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressBook.Lib.Tests.Repository
{
    [TestClass]
    public class EmployeeRepositoryTest
    {
        private static readonly EmployeeRepository EmployeeRepository = new EmployeeRepository();

        [TestMethod]
        public void EmployeeRetrieveByIdTest()
        {
            const long employeeId = 6;
            var employee = EmployeeRepository.GetById(employeeId);
            Assert.AreEqual(employeeId, employee.Id);
        }

        [TestMethod]
        public void EmployeeRetrieveAllTest()
        {
            var employees = EmployeeRepository.GetAll();
            Assert.IsNotNull(employees);
        }
    }
}
