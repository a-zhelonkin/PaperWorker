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
        /// <summary>
        /// Имя роли
        /// </summary>
        [Required]
        public RoleName Name { get; set; }

        /// <summary>
        /// Список владельцев данной роли
        /// </summary>
        public virtual ICollection<UserRole> Users { get; set; }
    }
}