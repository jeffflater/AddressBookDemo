using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace AddressBook.Data.Repositories
{
    /// <summary>
    /// Customer Repository
    /// </summary>
    public class CustomerRepository : Infrastructure.RepositoryBase<Model.Entitites.Customer>, Contracts.ICustomerRepository
    {
        private static DTO.CustomerDTO customerDTO = new DTO.CustomerDTO();

        /// <summary>
        /// Get Customer entity by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Model.Entitites.Customer GetById(long Id)
        {
            return customerDTO.GetById(Id);
        }

        /// <summary>
        /// Get All Customer entities
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Model.Entitites.Customer> GetAll()
        {
            return customerDTO.GetAll();
        }

        /// <summary>
        /// Save Customer entity :
        ///     If Customer.Id is zero a new Customer record will be created
        ///     If Customer.Id is not zero an existing Customer record will be updated
        /// </summary>
        /// <param name="entity"></param>
        public override void Save(Model.Entitites.Customer entity)
        {
            customerDTO.Save(entity);
        }

        /// <summary>
        /// Delete Customer entity by Id :
        ///     The IsDeleted record is set to 1; records are not actually deleted from the database
        /// </summary>
        /// <param name="Id"></param>
        public override void Delete(long Id)
        {
            customerDTO.Delete(Id);
        }
    }
}
