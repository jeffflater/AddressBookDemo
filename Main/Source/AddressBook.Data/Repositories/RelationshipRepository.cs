using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace AddressBook.Data.Repositories
{
    /// <summary>
    /// Relationship Repository
    /// </summary>
    public class RelationshipRepository : Contracts.IRelationshipRepository
    {
        private static List<Model.Entitites.Relationship.RelationshipTree> relationshipTree = new List<Model.Entitites.Relationship.RelationshipTree>();
        private static int treeDistance = 0;

        /// <summary>
        /// Get entire relationship tree based on Employee, Customer, Manager or SalesPeron Id
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="parentPersonType"></param>
        /// <returns></returns>
        public IEnumerable<Model.Entitites.Relationship.RelationshipTree> GetAll(long parentId, Model.Enum.PersonType parentPersonType)
        {
            var sql = new StringBuilder();

            var parentPersonTypeId = (int)parentPersonType;

            sql.Append(string.Format("SELECT * FROM dbo.Relationships WHERE ParentId = {0} AND ParentPersonTypeId = {1}", parentId.ToString(), parentPersonTypeId.ToString()));

            var parentRelationships = Lib.Extenstions.SqlExtensions.QueryTransaction<Model.Entitites.Relationship.ParentRelationship>(sql.ToString());

            TranverseRelationshipJSONTree(parentRelationships);
            
            return relationshipTree;
        }

        /// <summary>
        /// Tranverse entire tree starting with the Parent and calculte the distance of each child away from the parent entity
        /// Customer, Employee, Manager and SalesPerson can all be related to eachother
        /// </summary>
        /// <param name="parentRelationships"></param>
        private void TranverseRelationshipJSONTree(List<Model.Entitites.Relationship.ParentRelationship> parentRelationships)
        {
            treeDistance += 1;

            var sql = new StringBuilder();

            var relationshipsTree = new List<Model.Entitites.Relationship.ParentRelationship>();

            foreach (var parentRelationship in parentRelationships)
            {
                var childRelationships = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Model.Entitites.Relationship.ChildRelationship>>(parentRelationship.ChildRelationships);

                sql.Append("SELECT * FROM dbo.Relationships ");

                var childrenCount = 0;
                foreach (var childRelationship in childRelationships)
                {

                    relationshipTree.Add(ConstructRelationshipLeafData(parentRelationship, childRelationship));

                    if (childrenCount == 0)
                    {
                        sql.Append(string.Format("WHERE (ParentId = {0} AND ParentPersonTypeId = {1}) ", childRelationship.Id.ToString(), ((int)childRelationship.PersonType).ToString()));
                    }
                    else
                    {
                        sql.Append(string.Format("OR (ParentId = {0} AND ParentPersonTypeId = {1}) ", childRelationship.Id.ToString(), ((int)childRelationship.PersonType).ToString()));
                    }
                    childrenCount += 1;
                }

                var subTreeRelationships = Lib.Extenstions.SqlExtensions.QueryTransaction<Model.Entitites.Relationship.ParentRelationship>(sql.ToString());

                if (subTreeRelationships.Count() > 0)
                {
                    relationshipsTree.AddRange(subTreeRelationships);
                }
            }

            if (relationshipsTree.Count() > 0)
            {
                TranverseRelationshipJSONTree(relationshipsTree);
            }
        }

        /// <summary>
        /// Construct relationship leaf data
        /// </summary>
        /// <param name="parentRelationship"></param>
        /// <param name="childRelationship"></param>
        /// <returns></returns>
        private Model.Entitites.Relationship.RelationshipTree ConstructRelationshipLeafData(Model.Entitites.Relationship.ParentRelationship parentRelationship, Model.Entitites.Relationship.ChildRelationship childRelationship)
        {
            var relationshipTree = new Model.Entitites.Relationship.RelationshipTree();

            relationshipTree.ParentId = parentRelationship.ParentId;
            relationshipTree.ParentPersonType = (Model.Enum.PersonType)parentRelationship.ParentPersonTypeId;
            relationshipTree.ChildId = childRelationship.Id;
            relationshipTree.ChildPersonType = childRelationship.PersonType;

            switch (childRelationship.PersonType) 
            { 
                case Model.Enum.PersonType.Customer:
                    var customerRepository = new CustomerRepository();
                    var customer = customerRepository.GetById(childRelationship.Id);
                    relationshipTree.ChildFirstName = customer.FirstName;
                    relationshipTree.ChildLastName = customer.LastName;
                    break;
                case Model.Enum.PersonType.Employee:
                    var employeeRepository = new EmployeeRepository();
                    var employee = employeeRepository.GetById(childRelationship.Id);
                    relationshipTree.ChildFirstName = employee.FirstName;
                    relationshipTree.ChildLastName = employee.LastName;
                    break;
                case Model.Enum.PersonType.Manager:
                    var managerRepository = new ManagerRepository();
                    var manager = managerRepository.GetById(childRelationship.Id);
                    relationshipTree.ChildFirstName = manager.FirstName;
                    relationshipTree.ChildLastName = manager.LastName;
                    break;
                case Model.Enum.PersonType.SalesPerson:
                    var salesPersonRepository = new SalesPersonRepository();
                    var salesPerson = salesPersonRepository.GetById(childRelationship.Id);
                    relationshipTree.ChildFirstName = salesPerson.FirstName;
                    relationshipTree.ChildLastName = salesPerson.LastName;
                    break;
            }

            relationshipTree.TreeDistance = treeDistance;

            return relationshipTree;
        }

        /// <summary>
        /// Save parent/child relationship
        /// </summary>
        /// <param name="parentChildRelationship"></param>
        public void Save(Model.Entitites.Relationship.ParentChildRelationship parentChildRelationship)
        {
            var sql = new StringBuilder();

            var parentPersonTypeId = (int)parentChildRelationship.ParentPersonType;

            sql.Append(string.Format("SELECT * FROM dbo.Relationships WHERE ParentId = {0} AND ParentPersonTypeId = {1}", parentChildRelationship.ParentId.ToString(), parentPersonTypeId.ToString()));

            var relationship = Lib.Extenstions.SqlExtensions.QueryTransaction<Model.Entitites.Relationship.ParentRelationship>(sql.ToString()).FirstOrDefault();

            //create new parent / child relationship
            if (relationship == null )
            {
                sql = new StringBuilder();

                var childRelationships = new List<Model.Entitites.Relationship.ChildRelationship>();
                childRelationships.Add(new Model.Entitites.Relationship.ChildRelationship(parentChildRelationship.ChildId, parentChildRelationship.ChildPersonType));

                sql.Append("INSERT INTO dbo.Relationships (ParentId, ParentPersonTypeId, ChildRelationships, CreatedOn, LastModifiedOn, IsDeleted) ");
                sql.Append(string.Format("VALUES({0}, {1}, '{2}', GETDATE(), GETDATE(), 0)", parentChildRelationship.ParentId.ToString(),
                                                                                        parentPersonTypeId.ToString(),
                                                                                        Newtonsoft.Json.JsonConvert.SerializeObject(childRelationships)));

                Lib.Extenstions.SqlExtensions.CommitTransaction(sql.ToString());
            }

            //create a new child relationship for an empty parent record
            if (relationship != null && string.IsNullOrEmpty(relationship.ChildRelationships)) 
            {
                sql = new StringBuilder();

                var childRelationships = new List<Model.Entitites.Relationship.ChildRelationship>();
                childRelationships.Add(new Model.Entitites.Relationship.ChildRelationship(parentChildRelationship.ChildId, parentChildRelationship.ChildPersonType));

                sql.Append("UPDATE dbo.Relationships ");
                sql.Append(string.Format("SET ChildRelationships = '{0}', ", Newtonsoft.Json.JsonConvert.SerializeObject(childRelationships)));
                sql.Append("LastModifiedOn = GETDATE() ");
                sql.Append(string.Format("WHERE ParentId = {0}", parentChildRelationship.ParentId.ToString()));

                Lib.Extenstions.SqlExtensions.CommitTransaction(sql.ToString());
            }

            //append child relation to existing child relationships
            if (relationship != null && !string.IsNullOrEmpty(relationship.ChildRelationships))
            {
                sql = new StringBuilder();

                var childRelationships = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Model.Entitites.Relationship.ChildRelationship>>(relationship.ChildRelationships);
                childRelationships.Add(new Model.Entitites.Relationship.ChildRelationship(parentChildRelationship.ChildId, parentChildRelationship.ChildPersonType));

                sql.Append("UPDATE dbo.Relationships ");
                sql.Append(string.Format("SET ChildRelationships = '{0}', ", Newtonsoft.Json.JsonConvert.SerializeObject(childRelationships)));
                sql.Append("LastModifiedOn = GETDATE() ");
                sql.Append(string.Format("WHERE ParentId = {0}", parentChildRelationship.ParentId.ToString()));

                Lib.Extenstions.SqlExtensions.CommitTransaction(sql.ToString());
            }
        
        }
    }
}
