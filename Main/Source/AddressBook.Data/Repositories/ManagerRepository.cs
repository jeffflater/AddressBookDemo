using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Data.Repositories
{
    /// <summary>
    /// Manager Repository
    /// </summary>
    public class ManagerRepository : Infrastructure.RepositoryBase<Model.Entitites.Manager>, Contracts.IManagerRepository
    {
        private static DTO.ManagerDTO managerDTO = new DTO.ManagerDTO();

        /// <summary>
        /// Get Manager entity by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Model.Entitites.Manager GetById(long Id)
        {
            return managerDTO.GetById(Id);
        }

        /// <summary>
        /// Get All Manager entities
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Model.Entitites.Manager> GetAll()
        {
            return managerDTO.GetAll();
        }

        /// <summary>
        /// Save Manager entity :
        ///     If Manager.Id is zero a new Manager record will be created
        ///     If Manager.Id is not zero an existing Manager record will be updated
        /// </summary>
        /// <param name="entity"></param>
        public override void Save(Model.Entitites.Manager entity)
        {
            managerDTO.Save(entity);
        }

        /// <summary>
        /// Delete Manager entity by Id :
        ///     The IsDeleted record is set to 1; records are not actually deleted from the database
        /// </summary>
        /// <param name="Id"></param>
        public override void Delete(long Id)
        {
            managerDTO.Delete(Id);
        }
    }
}
