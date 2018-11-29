using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core;
using Database.Models.Base;

namespace Database.Models.Account
{
    /// <summary>
    /// Роль
    /// </summary>
    [Table("Roles")]
    public class Role : Entity
    {
        [Required]
        public RoleName Name { get; set; }

        public virtual ICollection<UserRole> Users { get; set; }
    }
}