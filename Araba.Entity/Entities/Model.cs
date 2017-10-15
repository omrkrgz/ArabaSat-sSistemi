using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Araba.Entity.Entities
{
    [Table("Modeller")]
    public  class Model
    {
        [Key]
        public int ID { get; set; }
       
        [Required]
        public int Yıl { get; set; }

        public virtual List<Arabam> Arabalar { get; set; } = new List<Arabam>();
    }
}
