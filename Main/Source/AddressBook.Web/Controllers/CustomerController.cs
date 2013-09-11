using System.Web.Http;
using AddressBook.Data.Repositories;
using AddressBook.Model.DTO;
using AddressBook.Model.Entitites;
using AutoMapper;

namespace AddressBook.Web.Controllers
{
    public class CustomerController : ApiController
    {
        private static readonly CustomerRepository Repository = new CustomerRepository();

        /// <summary>
        ///     Get Customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CustomerDto Get(long id)
        {
            var customer = Mapper.DynamicMap<Customer, CustomerDto>(Repository.GetById(id));

            return customer;
        }

        /// <summary>
        ///     Save Customer
        /// </summary>
        /// <param name="customer"></param>
        public void Post(Customer customer)
        {
            Repository.Save(customer);
        }

        /// <summary>
        ///     Delete Customer
        /// </summary>
        /// <param name="id"></param>
        public void Delete(long id)
        {
            Repository.Delete(id);
        }
    }
}