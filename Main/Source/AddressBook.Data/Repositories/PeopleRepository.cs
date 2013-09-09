using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace AddressBook.Data.Repositories
{
    /// <summary>
    /// People Repository
    /// </summary>
    public class PeopleRepository : Infrastructure.RepositoryBase<Model.Entitites.People>, Contracts.IPeopleRepository
    {
        private static DTO.PeopleDTO peopleDTO = new DTO.PeopleDTO();

        /// <summary>
        /// Get Customer, Employee, Manager, or SalesPerson entity by Id and PersonType
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="personType"></param>
        /// <returns></returns>
        public Model.Entitites.People GetById(long Id, Model.Enum.PersonType personType)
        {
            return peopleDTO.GetById(Id, personType);
        }

        /// <summary>
        /// Get all entities : Customer, Employee, Manager, and SalesPerson
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Model.Entitites.People> GetAll()
        {
            return peopleDTO.GetAll();
        }
    }
}
