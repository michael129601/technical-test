using Microsoft.EntityFrameworkCore;
using PruebaTecnicaNTTDATA.Entity.Connector;
using PruebaTecnicaNTTDATA.Entity.Models;


namespace PruebaTecnicaNTTDATA.Entity.Repositories.Implements
{
    public class CuentasRepository :  GenericRepository<Cuentas, ApplicationDBContext>
    {
        public CuentasRepository(ApplicationDBContext context) : base(context)
        {
        }

         
        public async Task<IEnumerable<Cuentas>> GetAll()
        {
            return await dbset.Include(b => b.Clientes).ThenInclude(c=>c.Persona).ToListAsync();
        }

        public async Task<Cuentas> GetById(int prmId) {
            return await dbset.Include(b => b.Clientes).ThenInclude(c => c.Persona).FirstOrDefaultAsync(i => i.Id == prmId);
        }

        public async Task<Cuentas> GetByNumeroCuenta(int prmNumCuenta)
        {
            return await dbset.Include(b => b.Clientes).ThenInclude(c => c.Persona).FirstOrDefaultAsync(i => i.NumeroCuenta == prmNumCuenta);
        }



    }
}
