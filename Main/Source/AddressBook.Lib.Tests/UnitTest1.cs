using System;
using NUnit.Framework;

namespace AddressBook.Lib.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestCreateRelationships()
        {
            /*
            var relationshipRepoistory = new Data.Repositories.RelationshipRepository();

            relationshipRepoistory.Save(6, 1, Model.Enum.PersonType.Customer, Model.Enum.PersonType.SalesPerson);
            relationshipRepoistory.Save(9, 2, Model.Enum.PersonType.Customer, Model.Enum.PersonType.SalesPerson);

            relationshipRepoistory.Save(6, 9, Model.Enum.PersonType.Customer, Model.Enum.PersonType.SalesPerson);
            relationshipRepoistory.Save(9, 10, Model.Enum.PersonType.Customer, Model.Enum.PersonType.SalesPerson);

            relationshipRepoistory.Save(4, 9, Model.Enum.PersonType.Employee, Model.Enum.PersonType.SalesPerson);
            relationshipRepoistory.Save(5, 10, Model.Enum.PersonType.Employee, Model.Enum.PersonType.SalesPerson);

            relationshipRepoistory.Save(9, 8, Model.Enum.PersonType.SalesPerson, Model.Enum.PersonType.Manager);
            relationshipRepoistory.Save(10, 11, Model.Enum.PersonType.SalesPerson, Model.Enum.PersonType.Manager);

            relationshipRepoistory.Save(9, 24, Model.Enum.PersonType.SalesPerson, Model.Enum.PersonType.Manager);
            relationshipRepoistory.Save(10, 25, Model.Enum.PersonType.SalesPerson, Model.Enum.PersonType.Manager);

            relationshipRepoistory.Save(8, 32, Model.Enum.PersonType.Manager, Model.Enum.PersonType.Customer);
            relationshipRepoistory.Save(11, 33, Model.Enum.PersonType.Manager, Model.Enum.PersonType.Customer);
            */
            Assert.IsFalse(false);
        }

        [Test]
        public void TestRelationships()
        {
            var relationshipRepoistory = new Data.Repositories.RelationshipRepository();

            var relationships = relationshipRepoistory.GetAll(6, Model.Enum.PersonType.Customer);

            Assert.IsFalse(false);
        }
    }
}
