using PruebaTecnicaNTTDATA.Entity.Connector;
using PruebaTecnicaNTTDATA.Entity.Models;

namespace PruebaTecnicaNTTDATA.Core.Facades
{
    public class ReporteFacade : FacadeBase
    {
        public ReporteFacade(ApplicationDBContext prmContext) : base(prmContext)
        {
        }

        public async Task<object> generatedReport(DateTime? fechaInicio,DateTime? fechaFin,int? clienteId)
        {
            using (ConnectorRepository conector = new ConnectorRepository(Context) )
            {
                List<Movimientos> lsTMovimientos = (List<Movimientos>) await conector.MovimientosRepository().GetByfechaAndCliente(fechaInicio.Value, fechaFin.Value, clienteId??0);
                List<object> lst = new List<object>();
                foreach (Movimientos movimiento in lsTMovimientos)
                {
                    lst.Add(new
                    {
                        fecha = movimiento.Fecha,
                        cliente = movimiento.Cuentas.Clientes.Persona.Nombre,
                        numero_cuenta = movimiento.Cuentas.NumeroCuenta,
                        tipo_cuenta = CuentasFacade.mapTipoCuenta[movimiento.Cuentas.TipoCuenta],
                        saldo_inicial = movimiento.Cuentas.SaldoInicial,
                        estado = movimiento.Cuentas.Estado,
                        movimiento = movimiento.Valor,
                        saldo_disponible = movimiento.Saldo
                    }); 
                }
                return lst;
            }
        }
         
    }
}
