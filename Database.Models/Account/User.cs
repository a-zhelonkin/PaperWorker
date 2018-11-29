using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Base;

namespace Database.Models.Account
{
    /// <summary>
    /// Пользователь
    /// </summary>
    [Table("Users")]
    public class User : Entity
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<UserRole> Roles { get; set; }
    }
}