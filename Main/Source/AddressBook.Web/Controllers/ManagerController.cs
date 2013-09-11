using System.Web.Http;
using AddressBook.Data.Repositories;
using AddressBook.Model.DTO;
using AddressBook.Model.Entitites;
using AutoMapper;

namespace AddressBook.Web.Controllers
{
    public class ManagerController : ApiController
    {
        private static readonly ManagerRepository Repository = new ManagerRepository();

        public ManagerDto Get(long id)
        {
            var manager = Mapper.DynamicMap<Manager, ManagerDto>(Repository.GetById(id));
            
            return manager;
        }

        public void Post(Manager manager)
        {
            Repository.Save(manager);
        }

        public void Delete(long id)
        {
            Repository.Delete(id);
        }
    }
}
