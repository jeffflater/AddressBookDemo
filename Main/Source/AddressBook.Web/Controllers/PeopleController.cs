using System.Collections.Generic;
using System.Web.Http;
using AddressBook.Data.Repositories;
using AddressBook.Model.DTO;
using AddressBook.Model.Entitites;
using AddressBook.Model.Enum;
using AutoMapper;

namespace AddressBook.Web.Controllers
{
    public class PeopleController : ApiController
    {
        private static readonly CustomerRepository CustomerRepository = new CustomerRepository();
        private static readonly EmployeeRepository EmployeeRepository = new EmployeeRepository();
        private static readonly ManagerRepository ManagerRepository = new ManagerRepository();
        private static readonly SalesPersonRepository SalesPersonRepository = new SalesPersonRepository();

        /// <summary>
        ///     Get People
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PersonDto> Get()
        {
            var people = new List<PersonDto>();

            //Customers
            Mapper.CreateMap<Customer, PersonDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.PersonType, opt => opt.UseValue(PersonType.Customer));

            var customers = Mapper.Map<IEnumerable<Customer>, List<PersonDto>>(CustomerRepository.GetAll());

            people.AddRange(customers);

            //Employees
            Mapper.CreateMap<Employee, PersonDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.PersonType, opt => opt.UseValue(PersonType.Employee));

            var employees = Mapper.Map<IEnumerable<Employee>, List<PersonDto>>(EmployeeRepository.GetAll());

            people.AddRange(employees);

            //Managers
            Mapper.CreateMap<Manager, PersonDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.PersonType, opt => opt.UseValue(PersonType.Manager));

            var managers = Mapper.Map<IEnumerable<Manager>, List<PersonDto>>(ManagerRepository.GetAll());

            people.AddRange(managers);

            //Sales People
            Mapper.CreateMap<SalesPerson, PersonDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.PersonType, opt => opt.UseValue(PersonType.SalesPerson));

            var salesPeople = Mapper.Map<IEnumerable<SalesPerson>, List<PersonDto>>(SalesPersonRepository.GetAll());
            
            people.AddRange(salesPeople);

            return people;
        }
    }
}