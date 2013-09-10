using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AddressBook.Web.Controllers
{
    public class CustomerController : ApiController
    {
        private static Data.Repositories.CustomerRepository repository = new Data.Repositories.CustomerRepository();

        public Model.DTO.CustomerDto Get(long Id)
        {
            var customer = AutoMapper.Mapper.DynamicMap<Model.Entitites.Customer, Model.DTO.CustomerDto>(repository.GetById(Id));

            return customer;
        }

        public void Post(Model.Entitites.Customer customer)
        {
            repository.Save(customer);
        }

        public void Delete(long Id)
        {
            repository.Delete(Id);
        }
    }
}
