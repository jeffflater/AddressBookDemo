using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AddressBook.Web.Controllers
{
    public class ManagerController : ApiController
    {
        Data.Repositories.ManagerRepository repository = new Data.Repositories.ManagerRepository();

        public Model.DTO.ManagerDto Get(long Id)
        {
            var manager = AutoMapper.Mapper.DynamicMap<Model.Entitites.Manager, Model.DTO.ManagerDto>(repository.GetById(Id));
            
            return manager;
        }

        public void Post(Model.Entitites.Manager manager)
        {
            repository.Save(manager);
        }

        public void Delete(long Id)
        {
            repository.Delete(Id);
        }
    }
}
