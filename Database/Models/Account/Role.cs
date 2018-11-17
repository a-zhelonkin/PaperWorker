using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Base;

namespace Database.Models.Account
{
    [Table("Roles")]
    public class Role : Entity
    {
        public static string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}