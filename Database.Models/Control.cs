using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Account;
using Database.Models.Base;

namespace Database.Models
{
    /// <summary>
    /// Управление
    /// </summary>
    [Table("Controls")]
    public class Control : Entity
    {
        public int Number { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}