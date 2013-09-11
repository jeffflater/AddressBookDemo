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

        /// <summary>
        ///     Get Sales Person
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SalesPersonDto Get(long id)
        {
            var salesPerson = Mapper.DynamicMap<SalesPerson, SalesPersonDto>(Repository.GetById(id));

            return salesPerson;
        }

        /// <summary>
        ///     Save Sales Person
        /// </summary>
        /// <param name="salesPerson"></param>
        public void Post(SalesPerson salesPerson)
        {
            Repository.Save(salesPerson);
        }

        /// <summary>
        ///     Delete Sales Person
        /// </summary>
        /// <param name="id"></param>
        public void Delete(long id)
        {
            Repository.Delete(id);
        }
    }
}