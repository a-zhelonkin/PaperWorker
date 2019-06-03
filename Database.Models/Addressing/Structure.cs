using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Base;

namespace Database.Models.Addressing
{
    /// <summary>
    /// Строение
    /// </summary>
    [Table("Structures")]
    public class Structure : Entity
    {
        [Required]
        public Guid StreetId { get; set; }

        [Required]
        private int Number { get; set; }

        [ForeignKey(nameof(StreetId))]
        public virtual Street Street { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}