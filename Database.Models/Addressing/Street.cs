using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Base;

namespace Database.Models.Addressing
{
    /// <summary>
    /// Улица
    /// </summary>
    [Table("Streets")]
    public class Street : NamedEntity
    {
        [Required]
        public Guid LocalityId { get; set; }

        [ForeignKey(nameof(LocalityId))]
        public virtual Locality Locality { get; set; }

        public virtual ICollection<Structure> Structures { get; set; }
    }
}