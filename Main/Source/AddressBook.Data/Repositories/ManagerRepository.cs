using System.Collections.Generic;
using AddressBook.Data.Infrastructure;
using AddressBook.Data.Repositories.Contracts;
using AddressBook.Lib.BLL;
using AddressBook.Model.Entitites;
using AddressBook.Model.Enum;

namespace AddressBook.Data.Repositories
{
    /// <summary>
    ///     Manager Repository
    /// </summary>
    public class ManagerRepository : RepositoryBase<Manager>, IManagerRepository
    {
        private static readonly ManagerBll ManagerBll = new ManagerBll();

        /// <summary>
        ///     Get Manager entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Manager GetById(long id)
        {
            return ManagerBll.GetById(id);
        }

        /// <summary>
        ///     Get All Manager entities
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Manager> GetAll()
        {
            return ManagerBll.GetAll();
        }

        /// <summary>
        ///     Save Manager entity :
        ///     If Manager.id is zero a new Manager record will be created
        ///     If Manager.id is not zero an existing Manager record will be updated
        /// </summary>
        /// <param name="entity"></param>
        public override void Save(Manager entity)
        {
            ManagerBll.Save(entity);
        }

        /// <summary>
        ///     Delete Manager entity by id :
        ///     The IsDeleted record is set to 1; records are not actually deleted from the database
        /// </summary>
        /// <param name="id"></param>
        public override void Delete(long id)
        {
            ManagerBll.Delete(id);
        }
    }
}