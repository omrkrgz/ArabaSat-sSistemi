using Araba.Entity.Entities;
using Araba.Entity.IdentityModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Araba.DAL
{
 public   class ArabaContext: IdentityDbContext<ApplicationUser>
    {
        public ArabaContext()
            :base("name=ArabaCon")
        {
       
    }
        public virtual DbSet<Arabam> Arabalar { get; set; }
        public virtual DbSet<YakitTuru> YakitTurleri { get; set; }
        public virtual DbSet<Durum> Durumlar { get; set; }
        public virtual DbSet<Marka> Markalar { get; set; }
        public virtual DbSet<Model> Modeller { get; set; }
        public virtual DbSet<Fotograf> Fotograflar { get; set; }
        public virtual DbSet<Renk> Renkler { get; set; }
        public virtual DbSet<Vites> Vitesler { get; set; }





    }
}
