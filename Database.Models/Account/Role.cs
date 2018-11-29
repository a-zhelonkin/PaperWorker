using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

    public enum RoleName : byte
    {
        /// <summary>
        /// Потребитель
        /// </summary>
        Consumer,

        /// <summary>
        /// Слесарь
        /// </summary>
        Locksmith,

        /// <summary>
        /// Администратор
        /// </summary>
        Admin
    }
}