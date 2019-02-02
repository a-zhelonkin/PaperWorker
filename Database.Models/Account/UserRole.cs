using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models.Account
{
    [Table("UserRoles")]
    public class UserRole
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid RoleId { get; set; }

        public virtual User User { get; set; }

        public virtual Role Role { get; set; }
    }
}