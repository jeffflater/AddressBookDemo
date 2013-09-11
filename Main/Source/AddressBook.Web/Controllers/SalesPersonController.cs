using System.Web.Http;
using AddressBook.Data.Repositories;
using AddressBook.Model.DTO;
using AddressBook.Model.Entitites;
using AutoMapper;

namespace AddressBook.Web.Controllers
{
    public class SalesPersonController : ApiController
    {
        private static readonly SalesPersonRepository Repository = new SalesPersonRepository();

        public SalesPersonDto Get(long id)
        {
            var salesPerson = Mapper.DynamicMap<SalesPerson, SalesPersonDto>(Repository.GetById(id));

            return salesPerson;
        }

        public void Post(SalesPerson salesPerson)
        {
            Repository.Save(salesPerson);
        }

        public void Delete(long id)
        {
            Repository.Delete(id);
        }
    }
}