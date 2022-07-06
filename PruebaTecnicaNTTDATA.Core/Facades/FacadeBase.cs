using PruebaTecnicaNTTDATA.Entity.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaNTTDATA.Core.Facades
{
    public abstract class FacadeBase
    {
      
        protected ApplicationDBContext Context { get; set; }

      
        public FacadeBase(ApplicationDBContext prmContext)
        {
            Context = prmContext;
        }
    }
}
