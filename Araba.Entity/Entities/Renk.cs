using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Araba.Entity.Entities
{ [Table("Renkler")]
  public   class Renk
    {
        [Key]
        public int ID { get; set; }

        [StringLength(25)]
        [Required]
        public string AD { get; set; }

        public virtual List<Arabam> Arabalar { get; set; } = new List<Arabam>();
    }
}
