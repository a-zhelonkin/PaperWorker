using System;
using System.ComponentModel.DataAnnotations.Schema;
using Core;
using Database.Models.Base;

namespace Database.Models
{
    [Table("GasEquipments")]
    public class GasEquipment : Entity
    {
        public GasEquipmentType Type { get; set; }

        public string Mark { get; set; }

        public Guid ManufacturerId { get; set; }

        public DateTime ManufactureDate { get; set; }

        [ForeignKey(nameof(ManufacturerId))]
        public virtual Manufacturer Manufacturer { get; set; }
    }
}