using System;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaNTTDATA.Entity.Connector;
using PruebaTecnicaNTTDATA.Entity.Models;

namespace PruebaTecnicaNTTDATA.Entity.Repositories.Implements
{
    public class ClientesRepository : GenericRepository<Clientes, ApplicationDBContext>
    {
        public ClientesRepository(ApplicationDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Clientes>> GetAll()
        {
            return await dbset.Include(b=> b.Persona).ToListAsync() ;
        }

        public async Task<Clientes> GetById(int prmId) => await dbset.Include(b => b.Persona).FirstOrDefaultAsync(i => i.Clienteid == prmId);
    }
}
