using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models
{
    [Table("ConsumerGasEquipments")]
    public class ConsumerGasEquipment
    {
        [Required]
        public Guid ConsumerId { get; set; }

        [Required]
        public Guid GasEquipmentId { get; set; }

        [ForeignKey(nameof(ConsumerId))]
        public virtual Consumer Consumer { get; set; }

        [ForeignKey(nameof(GasEquipmentId))]
        public virtual GasEquipment GasEquipment { get; set; }
    }
}