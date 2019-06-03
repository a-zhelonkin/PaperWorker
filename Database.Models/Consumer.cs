using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Addressing;
using Database.Models.Base;

namespace Database.Models
{
    /// <summary>
    /// Потребитель
    /// </summary>
    [Table("Consumers")]
    public class Consumer : Entity
    {
        [Required]
        public Guid ProfileId { get; set; }

        [Required]
        public Guid AddressId { get; set; }

        /// <summary>
        /// Лицевой счет
        /// </summary>
        public string PersonalNumber { get; set; }

        /// <summary>
        /// Профиль
        /// </summary>
        [ForeignKey(nameof(ProfileId))]
        public virtual Profile Profile { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        [ForeignKey(nameof(AddressId))]
        public virtual Address Address { get; set; }

        /// <summary>
        /// Набор газового оборудования
        /// </summary>
        public virtual ICollection<ConsumerGasEquipment> GasEquipments { get; set; }

        /// <summary>
        /// Набор ТО
        /// </summary>
        public virtual ICollection<MaintenanceCard> MaintenanceCards { get; set; }
    }
}