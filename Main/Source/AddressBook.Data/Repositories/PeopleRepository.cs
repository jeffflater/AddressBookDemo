using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace AddressBook.Data.Repositories
{
    public class PeopleRepository : Infrastructure.RepositoryBase<Model.Entitites.People>, Contracts.IPeopleRepository
    {
        public override Model.Entitites.People GetById(long Id, Model.Enum.PersonType personType)
        {
            var sql = new StringBuilder();

            switch (personType)
            {
                case Model.Enum.PersonType.Customer:
                    sql.Append(string.Format("SELECT FirstName, LastName, DateOfBirth, 1 AS PersonType FROM dbo.vwCustomers WHERE Id = ", Id.ToString()));
                    break;
                case Model.Enum.PersonType.Employee:
                    sql.Append(string.Format("SELECT FirstName, LastName, DateOfBirth, 2 AS PersonType FROM dbo.vwEmployees WHERE Id = ", Id.ToString()));
                    break;
                case Model.Enum.PersonType.Manager:
                    sql.Append(string.Format("SELECT FirstName, LastName, DateOfBirth, 3 AS PersonType FROM dbo.vwManagers WHERE Id = ", Id.ToString()));
                    break;
                case Model.Enum.PersonType.SalesPerson:
                    sql.Append(string.Format("SELECT FirstName, LastName, DateOfBirth, 4 AS PersonType FROM dbo.vwSalesPeople WHERE Id = ", Id.ToString()));
                    break;
            }

            var query = Lib.Extenstions.SqlExtensions.QueryTransaction<Model.Entitites.People>(sql.ToString());
            return query.FirstOrDefault();
        }

        public IEnumerable<Model.Entitites.People> GetAll()
        {
            var sql = "SELECT * FROM dbo.vwPeople";

            var query = Lib.Extenstions.SqlExtensions.QueryTransaction<Model.Entitites.People>(sql.ToString());

            return query;
        }
    }
}
