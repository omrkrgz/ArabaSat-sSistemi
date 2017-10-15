using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Araba.Entity.Entities
{
    [Table("Markalar")]
    public class Marka
    {
        [Key]
        public int ID { get; set; }
        [StringLength(25)]
        [Required]
        public string Ad { get; set; }

        public virtual List<Arabam> Arabalar { get; set; } = new List<Arabam>();
    }
}
