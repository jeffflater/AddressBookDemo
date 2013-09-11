using AddressBook.Model.Enum;

namespace AddressBook.Model.DTO
{
    /// <summary>
    ///     Concrete RelationshipDto Class : Inherits from abstract PersonDto class
    /// </summary>
    public class RelationshipDto
    {
        public long ParentId { get; set; }
        public PersonType ParentPersonType { get; set; }

        public long ChildId { get; set; }
        public PersonType ChildPersonType { get; set; }

        public string ChildFirstName { get; set; }
        public string ChildLastName { get; set; }

        public string ChildFullName
        {
            get { return string.Format("{0}, {1}", ChildLastName, ChildFirstName); }
        }

        public int Distance { get; set; }
    }
}