using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Base;

namespace Database.Models.Addressing
{
    /// <summary>
    /// Населенный пункт (город, поселок, деревня)
    /// </summary>
    [Table("Localities")]
    public class Locality : NamedEntity
    {
        [Required]
        public Guid TerritoryId { get; set; }

        [ForeignKey(nameof(TerritoryId))]
        public virtual Territory Territory { get; set; }

        public virtual ICollection<Street> Streets { get; set; }
    }
}