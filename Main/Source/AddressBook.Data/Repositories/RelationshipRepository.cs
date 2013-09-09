using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace AddressBook.Data.Repositories
{
    public class RelationshipRepository : Contracts.IRelationshipRepository
    {
        private static List<Model.Entitites.RelationshipHierarchy>  relationshipHierarchy = new List<Model.Entitites.RelationshipHierarchy>();
        private static int treeDistance = 0;

        public IEnumerable<Model.Entitites.RelationshipHierarchy> GetAll(long parentId, Model.Enum.PersonType parentPersonType)
        {
            var sql = new StringBuilder();

            var parentPersonTypeId = (int)parentPersonType;

            sql.Append(string.Format("SELECT * FROM dbo.Relationships WHERE ParentId = {0} AND ParentPersonTypeId = {1}", parentId.ToString(), parentPersonTypeId.ToString()));

            var parentRelationships = Lib.Extenstions.SqlExtensions.QueryTransaction<Model.Entitites.ParentRelationship>(sql.ToString());

            WalkRelationshipJSONTree(parentRelationships);
            
            return relationshipHierarchy;
        }

        private void WalkRelationshipJSONTree(List<Model.Entitites.ParentRelationship> parentRelationships)
        {
            treeDistance += 1;

            var sql = new StringBuilder();
            
            var relationshipsTree = new List<Model.Entitites.ParentRelationship>();

            foreach (var parentRelationship in parentRelationships)
            {
                var childRelationships = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Model.Entitites.ChildRelationship>>(parentRelationship.ChildRelationships);

                sql.Append("SELECT * FROM dbo.Relationships ");

                var childrenCount = 0;
                foreach (var childRelationship in childRelationships)
                {

                    relationshipHierarchy.Add(ConstructHierarchyRelationshipData(parentRelationship, childRelationship));

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

                var subTreeRelationships = Lib.Extenstions.SqlExtensions.QueryTransaction<Model.Entitites.ParentRelationship>(sql.ToString());

                if (subTreeRelationships.Count() > 0)
                {
                    relationshipsTree.AddRange(subTreeRelationships);
                }
            }

            if (relationshipsTree.Count() > 0)
            {
                WalkRelationshipJSONTree(relationshipsTree);
            }
        }

        private Model.Entitites.RelationshipHierarchy ConstructHierarchyRelationshipData(Model.Entitites.ParentRelationship parentRelationship, Model.Entitites.ChildRelationship childRelationship)
        {
            var relationshipHierarchy = new Model.Entitites.RelationshipHierarchy();

            relationshipHierarchy.ParentId = parentRelationship.ParentId;
            relationshipHierarchy.ParentPersonType = (Model.Enum.PersonType)parentRelationship.ParentPersonTypeId;
            relationshipHierarchy.ChildId = childRelationship.Id;
            relationshipHierarchy.ChildPersonType = childRelationship.PersonType;

            switch (childRelationship.PersonType) 
            { 
                case Model.Enum.PersonType.Customer:
                    var customerRepository = new CustomerRepository();
                    var customer = customerRepository.GetById(childRelationship.Id);
                    relationshipHierarchy.ChildFirstName = customer.FirstName;
                    relationshipHierarchy.ChildLastName = customer.LastName;
                    break;
                case Model.Enum.PersonType.Employee:
                    var employeeRepository = new EmployeeRepository();
                    var employee = employeeRepository.GetById(childRelationship.Id);
                    relationshipHierarchy.ChildFirstName = employee.FirstName;
                    relationshipHierarchy.ChildLastName = employee.LastName;
                    break;
                case Model.Enum.PersonType.Manager:
                    var managerRepository = new ManagerRepository();
                    var manager = managerRepository.GetById(childRelationship.Id);
                    relationshipHierarchy.ChildFirstName = manager.FirstName;
                    relationshipHierarchy.ChildLastName = manager.LastName;
                    break;
                case Model.Enum.PersonType.SalesPerson:
                    var salesPersonRepository = new SalesPersonRepository();
                    var salesPerson = salesPersonRepository.GetById(childRelationship.Id);
                    relationshipHierarchy.ChildFirstName = salesPerson.FirstName;
                    relationshipHierarchy.ChildLastName = salesPerson.LastName;
                    break;
            }

            relationshipHierarchy.TreeDistance = treeDistance;

            return relationshipHierarchy;
        }

        public void Save(long parentId, long childId, Model.Enum.PersonType parentPersonType, Model.Enum.PersonType childPersonType)
        {
            var sql = new StringBuilder();

            var parentPersonTypeId = (int)parentPersonType;

            sql.Append(string.Format("SELECT * FROM dbo.Relationships WHERE ParentId = {0} AND ParentPersonTypeId = {1}", parentId.ToString(), parentPersonTypeId.ToString()));

            var relationship = Lib.Extenstions.SqlExtensions.QueryTransaction<Model.Entitites.ParentRelationship>(sql.ToString()).FirstOrDefault();

            //create new parent / child relationship
            if (relationship == null )
            {
                sql = new StringBuilder();

                var childRelationships = new List<Model.Entitites.ChildRelationship>();
                childRelationships.Add(new Model.Entitites.ChildRelationship(childId, childPersonType));

                sql.Append("INSERT INTO dbo.Relationships (ParentId, ParentPersonTypeId, ChildRelationships, CreatedOn, LastModifiedOn, IsDeleted) ");
                sql.Append(string.Format("VALUES({0}, {1}, '{2}', GETDATE(), GETDATE(), 0)", parentId.ToString(),
                                                                                        parentPersonTypeId.ToString(),
                                                                                        Newtonsoft.Json.JsonConvert.SerializeObject(childRelationships)));

                Lib.Extenstions.SqlExtensions.CommitTransaction(sql.ToString());
            }

            //create a new child relationship for an empty parent record
            if (relationship != null && string.IsNullOrEmpty(relationship.ChildRelationships)) 
            {
                sql = new StringBuilder();

                var childRelationships = new List<Model.Entitites.ChildRelationship>();
                childRelationships.Add(new Model.Entitites.ChildRelationship(childId, childPersonType));

                sql.Append("UPDATE dbo.Relationships ");
                sql.Append(string.Format("SET ChildRelationships = '{0}', ", Newtonsoft.Json.JsonConvert.SerializeObject(childRelationships)));
                sql.Append("LastModifiedOn = GETDATE() ");
                sql.Append(string.Format("WHERE ParentId = {0}", parentId.ToString()));

                Lib.Extenstions.SqlExtensions.CommitTransaction(sql.ToString());
            }

            //append child relation to existing child relationships
            if (relationship != null && !string.IsNullOrEmpty(relationship.ChildRelationships))
            {
                sql = new StringBuilder();

                var childRelationships = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Model.Entitites.ChildRelationship>>(relationship.ChildRelationships);
                childRelationships.Add(new Model.Entitites.ChildRelationship(childId, childPersonType));

                sql.Append("UPDATE dbo.Relationships ");
                sql.Append(string.Format("SET ChildRelationships = '{0}', ", Newtonsoft.Json.JsonConvert.SerializeObject(childRelationships)));
                sql.Append("LastModifiedOn = GETDATE() ");
                sql.Append(string.Format("WHERE ParentId = {0}", parentId.ToString()));

                Lib.Extenstions.SqlExtensions.CommitTransaction(sql.ToString());
            }
        
        }
    }
}
