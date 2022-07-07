using PruebaTecnicaNTTDATA.Core.DTOs;
using PruebaTecnicaNTTDATA.Core.ExceptionHandle;
using PruebaTecnicaNTTDATA.Entity.Connector;
using PruebaTecnicaNTTDATA.Entity.Models;


namespace PruebaTecnicaNTTDATA.Core.Facades
{
    public class CuentasFacade : FacadeBase
    {
        
        private string[] tipoCuentaPermitidos ;

        public static readonly Dictionary<string, string> mapTipoCuenta = new Dictionary<string, string>() {
                {"C","Corriente"},
                {"A","Ahorro"}
        };
        
        protected void cargaInicialMapTiposCuenta()
        {
            mapTipoCuenta.Add("C", "Corriente");
            mapTipoCuenta.Add("A", "Ahorro");
        }
        public CuentasFacade(ApplicationDBContext prmContext) : base(prmContext)
        {
           // cargaInicialMapTiposCuenta();
            tipoCuentaPermitidos = mapTipoCuenta.Keys.ToArray();
        }

        public bool IsValidateTipoCuenta(string prmTipoCuenta)
        {
            return Array.Exists(tipoCuentaPermitidos, element => element.Equals(prmTipoCuenta));
        }

        public bool IsNotvalidateSaldo(double? prmSaldo)
        {
            return prmSaldo < 0;
        }

        public object GetMapperDTOCuentas(Cuentas cuenta)
        {
            return new
            {
                numero_cuenta = cuenta.NumeroCuenta,
                tipo_label = mapTipoCuenta[cuenta.TipoCuenta],
                tipo = cuenta.TipoCuenta,
                saldo_inicial = cuenta.SaldoInicial,
                estado = cuenta.Estado,
                cliente = cuenta.Clientes.Persona.Nombre,
                clienteId = cuenta.ClienteId,
                id = cuenta.Id

            };
         }

        public void ValidateOrFails(double? prmSaldo,string? prmTipoCuenta) {
            if (prmSaldo != null && IsNotvalidateSaldo(prmSaldo)) throw new CuentasException(400, "el saldo de la cuenta no puede ser menor a 0");
            if (!String.IsNullOrEmpty(prmTipoCuenta) && !IsValidateTipoCuenta(prmTipoCuenta)) throw new CuentasException(400, "el Tipo de Cuenta solo puede ser [A: Ahorro , C: Corriente]");
        }

        public async Task<object> Create(CuentasDTO prmCuentas)
        {
            using (ConnectorRepository conector = new ConnectorRepository(Context))
            {

                Clientes cliente = await conector.ClientesRepository().GetById(prmCuentas.clienteId);
                if (cliente == null) throw new CuentasException(404, "Cliente no Encontrado");
                ValidateOrFails(prmCuentas.saldo_inicial, prmCuentas.tipo);
                return await conector.CuentasRepository().Insert(new Cuentas
                {
                   Clientes = cliente,
                   Estado = true,
                   NumeroCuenta = prmCuentas.numero_cuenta,
                   SaldoInicial = prmCuentas.saldo_inicial,
                   TipoCuenta = prmCuentas.tipo
                });

            }
        }


        public async Task<object> Update(CuentasUpdateDTO prmCliente, int prmId)
        {
            using (ConnectorRepository conector = new ConnectorRepository(Context))
            {

                Cuentas cuenta = await getCuentaByIdOrFails(conector, prmId);
                
                ValidateOrFails( prmCliente.saldo_inicial, prmCliente.tipo);
                cuenta.Estado = prmCliente.estado ?? cuenta.Estado;
                cuenta.TipoCuenta = prmCliente.tipo;
                cuenta.SaldoInicial = prmCliente.saldo_inicial;

                return await conector.CuentasRepository().Update(cuenta);

            }
        }

        public async Task<object> GetAll()
        {
            using (ConnectorRepository conector = new ConnectorRepository(Context))
            {

                List<Cuentas> lstModels = (List<Cuentas>)await conector.CuentasRepository().GetAll();

                List<object> lstDtos = new List<object>();

                foreach (Cuentas cuenta in lstModels)
                {
                    lstDtos.Add(GetMapperDTOCuentas(cuenta));
                }
                return lstDtos;

            }
        }

        public async Task<object> GetById(int prmId)
        {
            using (ConnectorRepository conector = new ConnectorRepository(Context))
            {
                Cuentas cuenta = await getCuentaByIdOrFails(conector, prmId);

                List<object> lstDtos = new List<object>();

                lstDtos.Add(GetMapperDTOCuentas(cuenta));

                return lstDtos;
            }
        }

        public async Task<int> Delete(int prmId)
        {
            using (ConnectorRepository conector = new ConnectorRepository(Context))
            {
                int code= await conector.CuentasRepository().Delete(prmId);
                if (code == -1) throwExceptionCuentaNotFound();
                return code;
            }
        }

        public async Task<Cuentas> getCuentaByIdOrFails(ConnectorRepository conector , int prmID)
        {
            Cuentas cuenta = await conector.CuentasRepository().GetById(prmID);
            if (cuenta == null) throwExceptionCuentaNotFound();
            return cuenta;

        }

        private void throwExceptionCuentaNotFound()
        {
            ThrowExceptionCuentas(404, "Cuenta No encontrada");
        }


        private void ThrowExceptionCuentas(int prmCodigo,string prmMessage)
        {
            throw new CuentasException(prmCodigo, prmMessage);
        }


    }
}
