using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core;
using Database.Models.Base;

namespace Database.Models.Addressing
{
    /// <summary>
    /// Некоторая территория (страна, область, район)
    /// </summary>
    [Table("Territories")]
    public class Territory : NamedEntity
    {
        public Guid? ParentId { get; set; }

        [Required]
        public TerritoryType Type { get; set; }

        [ForeignKey(nameof(ParentId))]
        public virtual Territory Parent { get; set; }

        public virtual ICollection<Locality> Localities { get; set; }

        public virtual ICollection<Territory> Children { get; set; }
    }
}