using System.Collections.Generic;
using AddressBook.Data.Infrastructure;
using AddressBook.Data.Repositories.Contracts;
using AddressBook.Lib.BLL;
using AddressBook.Model.Entitites;
using AddressBook.Model.Enum;

namespace AddressBook.Data.Repositories
{
    /// <summary>
    ///     Customer Repository
    /// </summary>
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        private static readonly CustomerBll CustomerBll = new CustomerBll();

        /// <summary>
        ///     Get Customer entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Customer GetById(long id)
        {
            return CustomerBll.GetById(id);
        }

        /// <summary>
        ///     Get All Customer entities
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Customer> GetAll()
        {
            return CustomerBll.GetAll();
        }

        /// <summary>
        ///     Save Customer entity :
        ///     If Customer.Id is zero a new Customer record will be created
        ///     If Customer.Id is not zero an existing Customer record will be updated
        /// </summary>
        /// <param name="entity"></param>
        public override void Save(Customer entity)
        {
            CustomerBll.Save(entity);
        }

        /// <summary>
        ///     Delete Customer entity by Id :
        ///     The IsDeleted record is set to 1; records are not actually deleted from the database
        /// </summary>
        /// <param name="id"></param>
        public override void Delete(long id)
        {
            CustomerBll.Delete(id);
        }
    }
}