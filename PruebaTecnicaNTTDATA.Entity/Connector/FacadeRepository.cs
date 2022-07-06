using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaNTTDATA.Entity.Connector
{
    public class FacadeRepository<IRepository,IContext> :  IDisposable where IRepository : class where IContext : DbContext
    {
        /// <summary>
        /// Current database context
        /// </summary>
        private readonly IContext context;


        private IRepository objRepository;

        public FacadeRepository(IContext prmContext)
        {
            context = prmContext;
        }


        public void Dispose()
        {
            context.Dispose();
        }

    }
}
