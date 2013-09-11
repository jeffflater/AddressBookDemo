using System;
using System.Linq;
using AddressBook.Model.Entitites;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBook.Data.Repositories;

namespace AddressBook.Lib.Tests.Repository
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        private static readonly CustomerRepository CustomerRepository = new CustomerRepository();

        [TestMethod]
        public void CustomerRetrieveByIdTest()
        {
            const long customerId = 6;
            var customer = CustomerRepository.GetById(customerId);
            Assert.AreEqual(customerId, customer.Id);
        }

        [TestMethod]
        public void CustomerRetrieveAllTest()
        {
            var customers = CustomerRepository.GetAll();
            Assert.IsNotNull(customers);
        }
        
        [TestMethod]
        public void CustomerCreateTest()
        {
            var customersPreCommit = CustomerRepository.GetAll();
            var totalCustomersPreCommit = customersPreCommit.Count();

            var customer = new Customer
            {
                FirstName = "fname",
                LastName = "lname",
                DateOfBirth = DateTime.Now,
                Age = 21,
                Education = "education",
                Gender = "gender"
            };

            //TODO: return created record id in order to perform a more accurate test
            CustomerRepository.Save(customer);

            var customersPostCommit = CustomerRepository.GetAll();
            var totalCustomersPostCommit = customersPostCommit.Count();

            Assert.AreNotEqual(totalCustomersPreCommit, totalCustomersPostCommit);
        }

        [TestMethod]
        public void CustomerUpdateTest()
        {
            const long customerId = 6;
            const string firstName = "fname";
            const string lastName = "lname";
            var dateOfBirth = DateTime.Now;
            const int age = 21;
            const string education = "education";
            const string gender = "gender";

            var customer = new Customer
            {
                Id = customerId,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Age = age,
                Education = education,
                Gender = gender
            };

            CustomerRepository.Save(customer);

            var customerPostCommit = CustomerRepository.GetById(customerId);

            Assert.IsTrue(customerPostCommit.FirstName == firstName);
            Assert.IsTrue(customerPostCommit.LastName == lastName);
            Assert.IsTrue(customerPostCommit.DateOfBirth.ToShortDateString() == dateOfBirth.ToShortDateString());
            Assert.IsTrue(customerPostCommit.Age == age);
            Assert.IsTrue(customerPostCommit.Education == education);
            Assert.IsTrue(customerPostCommit.Gender == gender);

        }

        [TestMethod]
        public void CustomerDeleteTest()
        {
            const long customerId = 1041;
            CustomerRepository.Delete(customerId);

            var customer = CustomerRepository.GetById(customerId);

            Assert.IsNull(customer);
        }
    }
}
