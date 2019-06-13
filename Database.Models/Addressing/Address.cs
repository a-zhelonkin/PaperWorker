using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Base;

namespace Database.Models.Addressing
{
    /// <summary>
    /// Адрес
    /// </summary>
    [Table("Addresses")]
    public class Address : Entity
    {
        [Required]
        public Guid StructureId { get; set; }

        [Required]
        public int Number { get; set; }

        [ForeignKey(nameof(StructureId))]
        public virtual Structure Structure { get; set; }

        public virtual ICollection<Consumer> Consumers { get; set; }
    }
}