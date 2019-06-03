using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Core;
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
        public Guid ProfileId { get; set; }

        /// <summary>
        /// Почтовый адрес
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Хэш пароля
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Статус пользователя
        /// </summary>
        public UserStatus Status { get; set; }

        /// <summary>
        /// Набор ролей
        /// </summary>
        public virtual ICollection<UserRole> Roles { get; set; }

        /// <summary>
        /// Профиль
        /// </summary>
        [ForeignKey(nameof(ProfileId))]
        public virtual Profile Profile { get; set; }

        /// <summary>
        /// Получение непосредственно ролей пользователя
        /// </summary>
        /// <returns>Роли пользователя</returns>
        public RoleName[] GetRoleNames() => Roles.Select(x => x.Role.Name).ToArray();
    }
}