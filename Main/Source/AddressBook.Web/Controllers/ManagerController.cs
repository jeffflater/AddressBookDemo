using System.Web.Http;
using AddressBook.Data.Repositories;
using AddressBook.Model.DTO;
using AddressBook.Model.Entitites;
using AutoMapper;

namespace AddressBook.Web.Controllers
{
    public class ManagerController : ApiController
    {
        private static readonly ManagerRepository ManagerRepository = new ManagerRepository();

        /// <summary>
        ///     Get Manager
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ManagerDto Get(long id)
        {
            var manager = Mapper.DynamicMap<Manager, ManagerDto>(ManagerRepository.GetById(id));

            return manager;
        }

        /// <summary>
        ///     Save Manager
        /// </summary>
        /// <param name="manager"></param>
        public void Post(Manager manager)
        {
            ManagerRepository.Save(manager);
        }

        /// <summary>
        ///     Delete Manager
        /// </summary>
        /// <param name="id"></param>
        public void Delete(long id)
        {
            ManagerRepository.Delete(id);
        }
    }
}