using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Data.Repositories
{
    /// <summary>
    /// SalesPerson Repository
    /// </summary>
    public class SalesPersonRepository : Infrastructure.RepositoryBase<Model.Entitites.SalesPerson>, Contracts.ISalesPersonRepository
    {
        private static DTO.SalesPersonDTO salesPersonDTO = new DTO.SalesPersonDTO();

        /// <summary>
        /// Get SalesPerson entity by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Model.Entitites.SalesPerson GetById(long Id)
        {
            return salesPersonDTO.GetById(Id);
        }

        /// <summary>
        /// Get All SalesPerson entities
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Model.Entitites.SalesPerson> GetAll()
        {
            return salesPersonDTO.GetAll();
        }

        /// <summary>
        /// Save SalesPerson entity :
        ///     If SalesPerson.Id is zero a new SalesPerson record will be created
        ///     If SalesPerson.Id is not zero an existing SalesPerson record will be updated
        /// </summary>
        /// <param name="entity"></param>
        public override void Save(Model.Entitites.SalesPerson entity)
        {
            salesPersonDTO.Save(entity);
        }

        /// <summary>
        /// Delete SalesPerson entity by Id :
        ///     The IsDeleted record is set to 1; records are not actually deleted from the database
        /// </summary>
        /// <param name="Id"></param>
        public override void Delete(long Id)
        {
            salesPersonDTO.Delete(Id);
        }
    }
}
