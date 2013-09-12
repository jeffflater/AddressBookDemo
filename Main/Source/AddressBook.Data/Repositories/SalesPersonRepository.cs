using System.Collections.Generic;
using AddressBook.Data.Infrastructure;
using AddressBook.Data.Repositories.Contracts;
using AddressBook.Lib.BLL;
using AddressBook.Model.Entitites;
using AddressBook.Model.Enum;

namespace AddressBook.Data.Repositories
{
    /// <summary>
    ///     SalesPerson Repository
    /// </summary>
    public class SalesPersonRepository : RepositoryBase<SalesPerson>, ISalesPersonRepository
    {
        private static readonly SalesPersonBll SalesPersonBll = new SalesPersonBll();

        /// <summary>
        ///     Get SalesPerson entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override SalesPerson GetById(long id)
        {
            return SalesPersonBll.GetById(id);
        }

        /// <summary>
        ///     Get All SalesPerson entities
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<SalesPerson> GetAll()
        {
            return SalesPersonBll.GetAll();
        }

        /// <summary>
        ///     Save SalesPerson entity :
        ///     If SalesPerson.id is zero a new SalesPerson record will be created
        ///     If SalesPerson.id is not zero an existing SalesPerson record will be updated
        /// </summary>
        /// <param name="entity"></param>
        public override void Save(SalesPerson entity)
        {
            SalesPersonBll.Save(entity);
        }

        /// <summary>
        ///     Delete SalesPerson entity by id :
        ///     The IsDeleted record is set to 1; records are not actually deleted from the database
        /// </summary>
        /// <param name="id"></param>
        public override void Delete(long id)
        {
            SalesPersonBll.Delete(id);
        }
    }
}