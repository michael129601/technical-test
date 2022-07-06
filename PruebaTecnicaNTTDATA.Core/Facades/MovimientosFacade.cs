using PruebaTecnicaNTTDATA.Core.DTOs;
using PruebaTecnicaNTTDATA.Core.ExceptionHandle;
using PruebaTecnicaNTTDATA.Entity.Connector;
using PruebaTecnicaNTTDATA.Entity.Models;


namespace PruebaTecnicaNTTDATA.Core.Facades
{
    public class MovimientosFacede : FacadeBase
    {

        private readonly int cantidadMaxRetiroDiaria = 1000;

        private string[] tipoMovimientos;

        private Dictionary<string, string> mapTipoMovimiento = new Dictionary<string, string>();

        protected void cargaInicialMapTiposMovimientos()
        {
            mapTipoMovimiento.Add("C", "Credito");
            mapTipoMovimiento.Add("D", "Debito");
        }

        public MovimientosFacede(ApplicationDBContext prmContext) : base(prmContext)
        {
            cargaInicialMapTiposMovimientos();
            tipoMovimientos = mapTipoMovimiento.Keys.ToArray();
        }

        public async Task<Cuentas> getCuentaOrFailsAsync(ConnectorRepository con, int prmNumeroCuenta)
        {
            Cuentas cuenta = await con.CuentasRepository().GetByNumeroCuenta(prmNumeroCuenta);
            if (cuenta == null) throw new MovimientosException(404, "Cuenta no Encontrada");
            return cuenta;
        }

        public bool isTipoMovimintoValido(string prmTipoMovimiento)
        {
            return Array.Exists(tipoMovimientos, element => element.Equals(prmTipoMovimiento));
        }

        private void validateTipoMovimientoOrFails(string prmTipoMovimiento)
        {
            if (!isTipoMovimintoValido(prmTipoMovimiento))
                throw new MovimientosException(400, "Tipo de moviemiento no Permitido");
        }

        private void validateSaldoOrFails(Cuentas cuenta, double valor)
        {
            int code = 200;
            if (cuenta.SaldoInicial == 0)
                throw new MovimientosException(code, "Saldo no disponible");
            if ((cuenta.SaldoInicial - valor) < 0)
                throw new MovimientosException(code, "Saldo insuficiente");
        }

        public void validateMaximoRetiroDiarioOrFails( int prmCuentaId, double valor,double? valorDiario)
        {
           
            if ((valorDiario + valor) > cantidadMaxRetiroDiaria)
                throw new MovimientosException(200, "Cupo diario Excedido");

        }

        public double? GetSaldoActualMovimiento(ConnectorRepository conector,Cuentas cuenta,string tipoMovimiento,double valor)
        {
            validateTipoMovimientoOrFails(tipoMovimiento);

            double? saldoTotal = cuenta.SaldoInicial + conector.MovimientosRepository().GetTotalSum(cuenta.Id);

            if (tipoMovimiento.Equals("D"))
            {
                validateSaldoOrFails(cuenta, valor);

                if ((saldoTotal - valor) < 0)
                    throw new MovimientosException(200, "Saldo insuficiente");

                double? valorDiario = conector.MovimientosRepository().GetTotalDebitosDateNow(DateTime.Now, cuenta.Id);
                validateMaximoRetiroDiarioOrFails(cuenta.Id, valor, valorDiario);
            }

            return  tipoMovimiento.Equals("D") ? saldoTotal - valor : saldoTotal + valor;
        }

        public async Task<object> Create(MovimientoDTO prmMovimientos)
        {
            using (ConnectorRepository conector = new ConnectorRepository(Context))
            {

                Cuentas cuenta = await getCuentaOrFailsAsync(conector, prmMovimientos.numero_cuenta);

                double? saldo = GetSaldoActualMovimiento(conector,cuenta, prmMovimientos.tipo_movimiento, prmMovimientos.valor);

                return await conector.MovimientosRepository().Insert(new Movimientos
                {
                    Cuentas = cuenta,
                    Valor = prmMovimientos.tipo_movimiento.Equals("D") ? prmMovimientos.valor * (-1) : prmMovimientos.valor,
                    Fecha = DateTime.Now,
                    Saldo = saldo,
                    TipoMovimiento = prmMovimientos.tipo_movimiento
                });

            }
        }

        public async Task<object> Update(int prmId, MovimientosUpdateDTO prmMovimientos)
        {
            using (ConnectorRepository conector = new ConnectorRepository(Context))
            {
                Movimientos movimiento = await conector.MovimientosRepository().GetById(prmId);
                if (movimiento == null) ThrowMovimientosNotFOund();

                double? saldo = GetSaldoActualMovimiento(conector, movimiento.Cuentas, prmMovimientos.tipo_movimiento, prmMovimientos.valor);
                movimiento.Valor = prmMovimientos.tipo_movimiento.Equals("D") ? prmMovimientos.valor * (-1) : prmMovimientos.valor;
                movimiento.TipoMovimiento = prmMovimientos.tipo_movimiento;
                movimiento.Saldo = saldo;
                movimiento.Fecha = DateTime.Now;
                return conector.MovimientosRepository().Update(movimiento);
            }
        }

        public async Task<object> GetAll()
        {
            using (ConnectorRepository conector = new ConnectorRepository(Context))
            {

                List<Movimientos> lstModels = (List<Movimientos>)await conector.MovimientosRepository().GetAll();

                List<object> lstDtos = new List<object>();

                foreach (Movimientos movimiento in lstModels)
                {
                    lstDtos.Add(GetMapperDTOMovimientos(movimiento));
                }
                return lstDtos;

            }
        }

      

        public async Task<object> GetById(int prmId)
        {
            using (ConnectorRepository conector = new ConnectorRepository(Context))
            {
                Movimientos movimiento = await conector.MovimientosRepository().GetById(prmId);
                if (movimiento == null) ThrowMovimientosNotFOund();
                return GetMapperDTOMovimientos(movimiento);
            }
        }

        public object GetMapperDTOMovimientos(Movimientos movimiento)
        {
            return new
            {
                cliente = movimiento.Cuentas.Clientes.Persona.Nombre,
                numero_cuenta = movimiento.Cuentas.NumeroCuenta,
                tipo = mapTipoMovimiento[movimiento.TipoMovimiento],
                saldo = movimiento.Saldo,
                fecha = movimiento.Fecha,
                valor = movimiento.Valor
            };
        }

        public async Task<int> Delete(int prmId)
        {
            using (ConnectorRepository conector = new ConnectorRepository(Context))
            {
                int code = await conector.MovimientosRepository().Delete(prmId);
                if (code == -1) ThrowMovimientosNotFOund();
                return code;
            }
        }

        public void ThrowMovimientosNotFOund()
        {
            throw new MovimientosException(404, "Movimiento no encontrado");
        }
    }
}
