using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Account;
using Database.Models.Base;

namespace Database.Models
{
    [Table("MaintenanceCards")]
    public class MaintenanceCard : Entity
    {
        public Guid UserId { get; set; }

        public Guid ConsumerId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        [ForeignKey(nameof(ConsumerId))]
        public virtual Consumer Consumer { get; set; }

        public virtual ICollection<Maintenance> Maintenances { get; set; }
    }
}