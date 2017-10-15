using Araba.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Araba.BLL.Repository
{
   public class Repository
    {
        public class ArabamRepo : RepositoryBase<Arabam, int> { }
        public class FotografRepo : RepositoryBase<Fotograf, int> { }
        public class DurumRepo : RepositoryBase<Durum, int> { }
        public class MarkaRepo : RepositoryBase<Marka, int> { }
        public class ModelRepo : RepositoryBase<Model, int> { }
        public class RenkRepo : RepositoryBase<Renk, int> { }
        public class VitesRepo : RepositoryBase<Vites, int> { }
        public class YakitTuruRepo : RepositoryBase<YakitTuru, int> { }

    }
}
