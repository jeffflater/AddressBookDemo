using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AddressBook.Model.Entitites
{
    public abstract class Entity
    {
        [Key]
        public long Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public bool Deleted { get; set; }
    }
}
