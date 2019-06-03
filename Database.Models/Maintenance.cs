using System;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Base;

namespace Database.Models
{
    /// <summary>
    /// Техническое обслуживание
    /// </summary>
    [Table("Maintenances")]
    public class Maintenance : Entity
    {
        public Guid MaintenanceCardId { get; set; }

        /// <summary>
        /// Дата ТО
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Проверка плотности соединения
        /// </summary>
        public bool CheckedConnection { get; set; }

        /// <summary>
        /// Регулирование горения
        /// </summary>
        public bool CheckedBurning { get; set; }

        /// <summary>
        /// Наличие тяги
        /// </summary>
        public bool CheckedTraction { get; set; }

        /// <summary>
        /// Соответствие кладки печи
        /// </summary>
        public bool CheckedMasonryStove { get; set; }

        /// <summary>
        /// Отладка автоматики
        /// </summary>
        public bool CheckedAutomationDebugging { get; set; }

        /// <summary>
        /// Другие работы
        /// </summary>
        public bool OtherWorks { get; set; }

        /// <summary>
        /// Дан инструктаж абоненту
        /// </summary>
        public bool ConsumerInstructed { get; set; }

        [ForeignKey(nameof(MaintenanceCardId))]
        public virtual MaintenanceCard MaintenanceCard { get; set; }
    }
}