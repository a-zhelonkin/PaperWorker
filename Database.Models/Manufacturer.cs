using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Base;

namespace Database.Models
{
    /// <summary>
    /// Завод-изготовитель
    /// </summary>
    [Table("Manufacturers")]
    public class Manufacturer : NamedEntity
    {
        /// <summary>
        /// Набор газового оборудования
        /// </summary>
        public virtual ICollection<GasEquipment> GasEquipments { get; set; }
    }
}