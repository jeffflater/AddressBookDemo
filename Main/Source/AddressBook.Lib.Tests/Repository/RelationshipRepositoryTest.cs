using System;
using AddressBook.Data.Repositories;
using AddressBook.Model.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressBook.Lib.Tests.Repository
{
    [TestClass]
    public class RelationshipRepositoryTest
    {
        private static readonly RelationshipRepository RelationshipRepository = new RelationshipRepository();

        [TestMethod]
        public void RelationshipRetrieveTest()
        {
            const long parentId = 6;
            const PersonType perentPersonType = PersonType.Customer;
            var relationships = RelationshipRepository.GetAll(parentId, perentPersonType);
            Assert.IsNotNull(relationships);
        }
    }
}
