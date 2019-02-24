using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core;
using Database.Models.Account;
using Database.Models.Base;

namespace Database.Models
{
    [Table("EmailMessages")]
    public class EmailMessage : Entity
    {
        /// <summary>
        /// Идентификатор пользователя, владеющим профилем
        /// </summary>
        [Required]
        public Guid UserId { get; set; }

        /// <summary>
        /// Тип сообщения
        /// </summary>
        [Required]
        public MessageType Type { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public virtual User User { get; set; }
    }
}