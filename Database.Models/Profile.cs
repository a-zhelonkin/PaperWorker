using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Account;
using Database.Models.Base;

namespace Database.Models
{
    /// <summary>
    /// Данные профиля
    /// </summary>
    [Table("Profiles")]
    public class Profile : Entity
    {
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
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}