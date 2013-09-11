using System;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Model.Entitites.Abstract
{
    /// <summary>
    ///     Abstract Entity class
    /// </summary>
    public abstract class Entity
    {
        [Key]
        public long Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}