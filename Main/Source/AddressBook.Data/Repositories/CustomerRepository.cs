using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace AddressBook.Data.Repositories
{
    public class CustomerRepository : Infrastructure.RepositoryBase<Model.Entitites.Customer>, Contracts.ICustomerRepository
    {
        public Model.Entitites.Customer GetById(long Id)
        {
            return base.GetById(Id, Model.Enum.PersonType.Customer);
        }

        public IEnumerable<Model.Entitites.Customer> GetAll()
        {
            return base.GetAll(Model.Enum.PersonType.Customer);
        }

        public override void Save(Model.Entitites.Customer entity)
        {
            var sql = new StringBuilder();

            if (entity.Id == 0)
            {
                //Generate SQL to create new record
                sql.Append("INSERT INTO dbo.Customers (FirstName, LastName, DateOfBirth, Gender, Age, Race, Education, CreatedOn, LastModifiedOn, IsDeleted) ");
                sql.Append(string.Format("VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', GETDATE(), GETDATE(), 0)", entity.FirstName,
                                                                                                                                entity.LastName,
                                                                                                                                entity.DateOfBirth.ToShortDateString(),
                                                                                                                                entity.Gender,
                                                                                                                                entity.Age,
                                                                                                                                entity.Race,
                                                                                                                                entity.Education));
         
            }
            else
            {
                //Generate SQL to update existing record
                sql.Append("UPDATE dbo.Customers ");
                            sql.Append(string.Format("SET FirstName = '{0}', ", entity.FirstName));
                            sql.Append(string.Format("LastName = '{0}', ", entity.LastName));
                            sql.Append(string.Format("DateOfBirth = '{0}', ", entity.DateOfBirth.ToShortDateString()));
                            sql.Append(string.Format("Gender = '{0}', ", entity.Gender));
                            sql.Append(string.Format("Age = {0}, ", entity.Age));
                            sql.Append(string.Format("Race = '{0}', ", entity.Race));
                            sql.Append(string.Format("Education = '{0}', ", entity.Education));
                            sql.Append("LastModifiedOn = GETDATE() ");
                            sql.Append(string.Format("WHERE Id = ", entity.Id.ToString()));
            }

            Lib.Extenstions.SqlExtensions.CommitTransaction(sql.ToString());
        }

        public override void Delete(long Id)
        {
            var sql = string.Format("UPDATE dbo.Customers SET IsDeleted = 1, LastModifiedOn = GETDATE() WHERE Id = {0}", Id.ToString());

            Lib.Extenstions.SqlExtensions.CommitTransaction(sql);
        }
    }
}
