using System.Collections.Generic;
using System.Web.Http;
using AddressBook.Data.Repositories;
using AddressBook.Model.DTO;
using AddressBook.Model.Entitites;
using AddressBook.Model.Entitites.Relationship;
using AddressBook.Model.Enum;
using AutoMapper;

namespace AddressBook.Web.Controllers
{
    public class RelationshipController : ApiController
    {
        private static readonly CustomerRepository CustomerRepository = new CustomerRepository();
        private static readonly EmployeeRepository EmployeeRepository = new EmployeeRepository();
        private static readonly ManagerRepository ManagerRepository = new ManagerRepository();
        private static readonly SalesPersonRepository SalesPersonRepository = new SalesPersonRepository();
        private static readonly RelationshipRepository RelationshipRepository = new RelationshipRepository();

        /// <summary>
        ///     Get Relationships
        /// </summary>
        /// <param name="id"></param>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public IEnumerable<RelationshipDto> Get(long id, int typeId)
        {
            Mapper.CreateMap<Leaf, RelationshipDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PersonType, opt => opt.MapFrom(src => src.PersonType))
                .ForMember(dest => dest.FullName, opt => opt.Ignore())
                .ForMember(dest => dest.Distance, opt => opt.MapFrom(src => src.Distance));

            var relationships = Mapper.Map<IEnumerable<Leaf>, List<RelationshipDto>>(RelationshipRepository.GetAll(id, (PersonType) typeId));

            foreach (RelationshipDto relationshipDto in relationships)
            {
                relationshipDto.FullName = GetPersonName(relationshipDto.Id, relationshipDto.PersonType);
            }

            return relationships;
        }

        /// <summary>
        ///     Get Person Name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="personType"></param>
        /// <returns></returns>
        private static string GetPersonName(long id, PersonType personType)
        {
            string personName = string.Empty;

            switch (personType)
            {
                case PersonType.Customer:
                    var customer = CustomerRepository.GetById(id);
                    personName = customer.FullName;
                    break;
                case PersonType.Employee:
                    var employee = EmployeeRepository.GetById(id);
                    personName = employee.FullName;
                    break;
                case PersonType.Manager:
                    var manager = ManagerRepository.GetById(id);
                    personName = manager.FullName;
                    break;
                case PersonType.SalesPerson:
                    var salesPerson = SalesPersonRepository.GetById(id);
                    personName = salesPerson.FullName;
                    break;
            }

            return personName;
        }

        /// <summary>
        ///     Save Relationship
        /// </summary>
        /// <param name="relationshipItemDto"></param>
        public void Post(RelationshipItemDto relationshipItemDto)
        {
            RelationshipRepository.Save(relationshipItemDto.ParentId,
                                            relationshipItemDto.ParentPersonType,
                                            relationshipItemDto.ChildId,
                                            relationshipItemDto.ChildPersonType);
        }

        /// <summary>
        ///     Delete Relationship
        /// </summary>
        /// <param name="id"></param>
        /// <param name="typeId"></param>
        public void Delete(long id, int typeId)
        {
            RelationshipRepository.Delete(id, (PersonType) typeId);
        }
    }
}