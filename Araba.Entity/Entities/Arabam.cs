using Araba.Entity.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Araba.Entity.Entities
{
    [Table("Arabalar")]

    public class Arabam
    {
        [Key]
        public int ID { get; set; }
        public string Adres { get; set; }
        [Column(TypeName = "date")]
        public DateTime EklenmeTarihi { get; set; } = DateTime.Now;
        public decimal Fiyat { get; set; }
        public string Kilometre { get; set; }
        public string Aciklama { get; set; }
        public string Enlem { get; set; }
        public string Boylam { get; set; }
        [StringLength(66)]
        public string Baslik { get; set; }
        public bool YayindaMi { get; set; } = false;
        public DateTime? OnaylanmaTarihi { get; set; }
        public string KullaniciID { get; set; }
        public int YakitTurleriID { get; set; }
        public int MarkalarID { get; set; }
        public int DurumlarID { get; set; }
        public int ModellerID { get; set; }
        public int ViteslerID { get; set; }
        public int RenklerID { get; set; }


        [ForeignKey("KullaniciID")]
        public virtual ApplicationUser Sahibi { get; set; }

        [ForeignKey("DurumlarID")]
        public virtual Durum Durumlar { get; set; }

        [ForeignKey("YakitTurleriID")]
        public virtual YakitTuru YakıtSistemi { get; set; }

        [ForeignKey("MarkalarID")]
        public virtual Marka Markalar { get; set; }

        [ForeignKey("ModellerID")]
        public virtual Model Modeller { get; set; }

        [ForeignKey("ViteslerID")]
        public virtual Vites Vitesler { get; set; }

        [ForeignKey("RenklerID")]
        public virtual Renk Renkler { get; set; }

        public virtual List<Fotograf> Fotograflar { get; set; } = new List<Fotograf>();
    }
}
