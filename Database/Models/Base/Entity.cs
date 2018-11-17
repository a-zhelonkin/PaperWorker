using System;
using System.ComponentModel.DataAnnotations;

namespace Database.Models.Base
{
    /// <summary>
    /// Сущность
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Штамп удаления сущности
        /// </summary>
        public DateTime? Deleted { get; set; }
    }
}