using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Account;

namespace Database.Models
{
    /// <summary>
    /// Данные профиля пользователя
    /// </summary>
    [Table("Profiles")]
    public class Profile
    {
        /// <summary>
        /// Идентификатор пользователя, владеющим профилем
        /// </summary>
        [Key]
        public Guid UserId { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Дата трудоустройства
        /// </summary>
        public DateTime BirthDateTime { get; set; }

        /// <summary>
        /// Дата трудоустройства
        /// </summary>
        public DateTime EmploymentDateTime { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public User User { get; set; }
    }
}