using AddressBook.Model.Entitites.Abstract;
using AddressBook.Model.Enum;

namespace AddressBook.Model.Entitites.Relationship
{
    /// <summary>
    ///     Concrete Leaf Class : Inherits from abstract Entity class
    /// </summary>
    public class Leaf : Entity
    {
        public Leaf()
        {
            
        }

        /// <summary>
        ///     Constructor used to create a new instance of Leaf with distance
        /// </summary>
        /// <param name="id"></param>
        /// <param name="personType"></param>
        /// <param name="distance"></param>
        public Leaf(long id, PersonType personType, int distance)
        {
            Id = id;
            PersonType = personType;
            Distance = distance;
        }

        /// <summary>
        ///     Constructor used to create a new instance of Leaf without distance
        /// </summary>
        /// <param name="id"></param>
        /// <param name="personType"></param>
        public Leaf(long id, PersonType personType)
        {
            Id = id;
            PersonType = personType;
        }

        public PersonType PersonType { get; set; }
        public int Distance { get; set; }
    }
}