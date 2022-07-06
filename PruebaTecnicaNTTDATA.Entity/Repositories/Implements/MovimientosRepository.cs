using Microsoft.EntityFrameworkCore;
using PruebaTecnicaNTTDATA.Entity.Connector;
using PruebaTecnicaNTTDATA.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaNTTDATA.Entity.Repositories.Implements
{
    public class MovimientosRepository : GenericRepository<Movimientos, ApplicationDBContext>
    {
        public MovimientosRepository(ApplicationDBContext context) : base(context)
        {
        }

        public double? GetTotalDebitosDateNow(DateTime fecha,int cuentaID)
        {
            return dbset.Where(b => b.Fecha.Value.Date == fecha.Date && b.CuentasId== cuentaID && b.TipoMovimiento=="D").Sum(s=>s.Valor*(-1));
        }

        public double? GetTotalSum( int cuentaID)
        {
            return dbset.Where(b =>  b.CuentasId == cuentaID).Sum(s => s.Valor);
        }

        public async Task<IEnumerable<Movimientos>> GetAll()
        {
            return await dbset.Include(b => b.Cuentas).ThenInclude(c => c.Clientes).ThenInclude(c => c.Persona).ToListAsync();
        }

        public async Task<Movimientos> GetById(int prmId)
        {
            return await dbset.Include(b => b.Cuentas).ThenInclude(c => c.Clientes).ThenInclude(c => c.Persona).FirstOrDefaultAsync(i => i.Id == prmId);
        }

        public async Task<IEnumerable<Movimientos>> GetByfechaAndCliente(DateTime fechaInicio,DateTime fechaFin, int idCliente)
        {
            return await dbset.
                Include(b => b.Cuentas).
                ThenInclude(c => c.Clientes).
                ThenInclude(c => c.Persona).
                Where(t=>t.Fecha.Value.Date >= fechaInicio.Date && t.Fecha.Value.Date <= fechaFin.Date && t.Cuentas.ClienteId==idCliente).
                ToListAsync();
        }


    }
}
